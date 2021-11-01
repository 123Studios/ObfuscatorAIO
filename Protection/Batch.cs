using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObfuscatorAIO
{
    class Batch
    {
        private static Random random = new Random();

        public static String JunkString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static void Start()
        {
            Console.Clear();
            Program.Logo();
            Console.Write("\n\nEnter Path To Batch/MS-DOS Script File=> ");
            string code = File.ReadAllText(Console.ReadLine());
            string bruh = code = string.Concat(code.Select(x => Char.IsLetterOrDigit(x) ? "%" + JunkString(6) + "%" + x : x.ToString())).TrimStart();
            string name = JunkString(3);
            File.WriteAllText(Environment.CurrentDirectory + "/" + name + ".bat", code);
            Console.WriteLine("[+] Finished Obfuscating File - " + Environment.CurrentDirectory + @"\" + name + ".bat");
            Console.ReadKey();
            Console.Clear();
            Program.Start();

        }
    }
}
