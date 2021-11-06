using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObfuscatorAIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        public static void Start()
        {
            Logo();
            Console.WriteLine("\nHTML, And JavaScript Obfuscation Is Coming Soon Aswell With Stronger Obfuscation Methods.\nI am not responsible for malicious use of this program.\n\n1.)PHP\n2.)Batch/MS-DOS Scripting Obfuscation\n3.)URL Obfuscation\n4.)C-Sharp Obfuscation");
            Console.Write("\nPlease Select An Option =>");
            switch(Console.ReadLine())
            {
                case "1":
                    PHP.Start();
                break;
                case "2":
                    Batch.Start();
                break;
                case "3":
                    URL.Start();
                break;
                case "4":
                    CSharp.Start();
                break;
            }
        }
        public static void Logo() { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("    ____  __    ____                      __             ___    ________ \n" + @"   / __ \/ /_  / __/_  ________________ _/ /_____  _____/   |  /  _/ __ \  " + "\n " + @" / / / / __ \/ /_/ / / / ___/ ___/ __ `/ __/ __ \/ ___/ /| |  / // / / /" + "\n " + "/ /_/ / /_/ / __/ /_/ (__  ) /__/ /_/ / /_/ /_/ / /  / ___ |_/ // /_/ / " + "\n " + @"\____/_.___/_/  \__,_/____/\___/\__,_/\__/\____/_/  /_/  |_/___/\____/    Created By 123Studios" + "\n\n"); Console.ForegroundColor = ConsoleColor.White; }
    }
}