using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObfuscatorAIO
{
    class CSharp
    {
        private static Random random = new Random();
        public static String JunkData(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static void Start()
        {
            Console.Clear();
            Program.Logo();
            Console.Write("\n\nEnter Path To C# Executable=> ");
            string path = Console.ReadLine();

            byte[] array = File.ReadAllBytes(path);
            AssemblyDef assemblyDef = AssemblyDef.Load(array);
            ModuleDefMD moduleDefMD = ModuleDefMD.Load(array);

            Console.WriteLine("[+] Read Executable Successfully");
            obfuscate_strings(moduleDefMD);
            MethodRename(moduleDefMD);
            moduleDefMD.Write(assemblyDef.Name + "-obfuscated.exe");
            Console.WriteLine("[+] Obfuscated Successfully!\nPress Any Key To Continue...");
            Console.ReadKey();
            Console.Clear();
            Program.Start();

        }
        public static void MethodRename(ModuleDefMD moduleDef)
        {
            foreach (TypeDef typeDef in moduleDef.GetTypes())
            {
                foreach (MethodDef methodDef in from x in typeDef.Methods
                                                where !x.IsConstructor && !x.IsVirtual
                                                select x)
                {
                    bool flag = methodDef.Name == "1                             2                                       3                                4                                 5                            6                         7                                  8                                 9 ";
                    if (flag)
                    {
                        return;
                    }
                    methodDef.Name = JunkData(300 + 20);
                }
            }
        }
        public static void obfuscate_strings(ModuleDef md) //Taken From Net-Obfuscate Created By BinaryScary
        {
            //foreach (var type in md.Types) // only gets parent(non-nested) classes

            // types(namespace.class) in module
            foreach (var type in md.GetTypes())
            {
                // methods in type
                foreach (MethodDef method in type.Methods)
                {
                    // empty method check
                    if (!method.HasBody) continue;
                    // iterate over instructions of method
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        // check for LoadString opcode
                        // CIL is Stackbased (data is pushed on stack rather than register)
                        // ref: https://en.wikipedia.org/wiki/Common_Intermediate_Language
                        // ld = load (push onto stack), st = store (store into variable)
                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            // c# variable has for loop scope only
                            String regString = method.Body.Instructions[i].Operand.ToString();
                            String encString = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(regString));
                            // methodology for adding code: write it in plain c#, compile, then view IL in dnspy
                            method.Body.Instructions[i].OpCode = OpCodes.Nop; // errors occur if instruction not replaced with Nop
                            method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, md.Import(typeof(System.Text.Encoding).GetMethod("get_UTF8", new Type[] { })))); // Load string onto stack
                            method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, encString)); // Load string onto stack
                            method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, md.Import(typeof(System.Convert).GetMethod("FromBase64String", new Type[] { typeof(string) })))); // call method FromBase64String with string parameter loaded from stack, returned value will be loaded onto stack
                            method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, md.Import(typeof(System.Text.Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) })))); // call method GetString with bytes parameter loaded from stack 
                            i += 4; //skip the Instructions as to not recurse on them
                        }
                    }
                    //method.Body.KeepOldMaxStack = true;
                }
            }
        }
    }
}
