using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObfuscatorAIO
{
    class PHP
    {

        public static string compiled;
        private static Random random = new Random();
        public static string junk;
        public static String JunkUnicode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
            Console.WriteLine("PHP Obfuscation Is Currently Scuffed May Not Work Till Next Update.");
            Console.Write("\n\nEnter Path To PHP File=> ");
            string path = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            /*/
            sb.AppendLine($"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }" + $"\nfunction {JunkData(30)}()" + "{\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\";" + "\necho \"" + JunkUnicode(500) + "\"; }");
            Console.WriteLine("[+] Added Junk Attributes.");
            junk += sb;
            /*/

            byte[] bytes; //The Code From Here Is Garbage Will Fix Soon
            string file = File.ReadAllText(path);

            bytes = Encoding.ASCII.GetBytes(file);
            var base64 = Convert.ToBase64String(bytes);
            compiled = "<?php\neval(base64_decode(\'" + base64 + "\'));\n?>";
            {

                string[] outName = path.Split('.');
                File.WriteAllText(Environment.CurrentDirectory + "/" + outName + "-obfuscated.php", compiled);
                Console.WriteLine("[+] Successfully Obfuscated!. Output: " + Environment.CurrentDirectory + "/" + outName + "-obfuscated.php");
                Console.ReadKey();
                Console.Clear();
                Program.Start();
            }

        }
    }
}
