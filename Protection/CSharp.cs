using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Media;
using OpCodes = dnlib.DotNet.Emit.OpCodes;

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
        public static String ForiegnText(int length)
        {
            const string chars = "诶比西迪伊艾弗吉艾尺艾杰开艾勒艾马艾娜哦屁吉吾艾儿艾";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void Start()
        {
            Console.Clear();
            Program.Logo();
            Console.Write("\n\nEnter Path To C# Executable=> ");
            string path = Console.ReadLine();
            if (path.Contains("\"")) { path = path.Replace("\"", ""); }

            byte[] array = File.ReadAllBytes(path);
            AssemblyDef assemblyDef = AssemblyDef.Load(array);
            ModuleDefMD moduleDefMD = ModuleDefMD.Load(array);

            Console.WriteLine("[+] Read Executable Successfully");
            Watermark(moduleDefMD);
            AddStringMethod(moduleDefMD);
            obfuscate_strings(moduleDefMD);
            MethodRename(moduleDefMD);
            namespaceRenamer(moduleDefMD);
            FieldRename(moduleDefMD);

            moduleDefMD.Write(assemblyDef.Name + "-obfuscated.exe");
            Console.WriteLine("[+] Obfuscated Successfully!\nPress Any Key To Continue...");
            Console.ReadKey();
            Console.Clear();
            Program.Start();

        }
        public static void FieldRename(ModuleDefMD moduleDef)
        {
            foreach (var types in moduleDef.Types)
            {
                foreach (var field in types.Fields)
                {
                    field.Name = ForiegnText(field.Name.Length + 20);
                }
            }
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
                    methodDef.Name = JunkData(300);
                }
            }
        }
        public static void Watermark(ModuleDefMD module)
        {
            
            module.Name = "ObfuscatorAIO - https://github.com/123Studios";
        }
            
        public static void obfuscate_strings(ModuleDef md) //From Net-Obfuscate - BinaryScary
        {

            foreach (var type in md.GetTypes())
            {
                // methods in type
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody) continue;
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {

                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            String regString = method.Body.Instructions[i].Operand.ToString();
                            String encString = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(regString));
                            method.Body.Instructions[i].OpCode = OpCodes.Nop; 
                            method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, md.Import(typeof(System.Text.Encoding).GetMethod("get_UTF8", new Type[] { })))); // Load string onto stack
                            method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, encString)); 
                            method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, md.Import(typeof(System.Convert).GetMethod("FromBase64String", new Type[] { typeof(string) })))); // call method FromBase64String with string parameter loaded from stack, returned value will be loaded onto stack
                            method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, md.Import(typeof(System.Text.Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) })))); // call method GetString with bytes parameter loaded from stack 
                            i += 4; 
                        }
                    }
                    
                }
            }
        }
        public static void namespaceRenamer(ModuleDefMD moduleDef)
        {
            foreach (TypeDef typeDef in moduleDef.GetTypes())
            {
                typeDef.Namespace = JunkData(90000);
            }
        }

            public static void AddStringMethod(ModuleDefMD module)
        {
            foreach (TypeDef typeDef in module.Types)
            {
                bool isGlobalModuleType = typeDef.IsGlobalModuleType;
                if (!isGlobalModuleType)
                {
                    for (int i = 0; i < random.Next(30, 60); i++)
                    {
                        CorLibTypeSig @string = typeDef.Module.CorLibTypes.String;
                        MethodDef methodDef = new MethodDefUser(JunkData(2000), MethodSig.CreateStatic(@string), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
                        {
                            Body = new CilBody()
                        };
                        typeDef.Methods.Add(methodDef);
                        for (int j = 0; j < random.Next(10, 33); j++)
                        {
                            methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4, random.Next(99999999, 999999999)));
                        }
                        methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                    }
                }
            }
        }
    }
}
