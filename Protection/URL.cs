using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObfuscatorAIO
{
    class URL //This Is An Old Code Scrap The Code Is Really Garbage.
    {
        public static void Start()
        {
            Console.Clear();
            Program.Logo();

            Console.WriteLine("Disclaimer: This program does not obfuscate IPV6 addresses.\n");
            Console.WriteLine("\n1.)Obfuscate URL\n2.)Obfuscate IP");
            Console.Write("\nPlease Select Option=> ");
            string option = Console.ReadLine();
            WebClient wc = new WebClient();
            try
            {
                switch (option)
                {
                    case "1":
                        Console.Write("\nPlease Enter URL=> ");
                        string url = Console.ReadLine();
                        Uri myUri = new Uri(url);

                        var ip = Dns.GetHostAddresses(myUri.Host)[0];
                        string ip1 = ip.ToString();
                        Console.WriteLine("[+] IP: " + ip1);
                        string[] arr = ip1.Split('.');

                        string partIP = arr[0];
                        string partIP1 = arr[1];
                        string partIP2 = arr[2];
                        string partIP3 = arr[3];

                        string out1 = Convert.ToByte(partIP).ToString("x2");
                        string out2 = Convert.ToByte(partIP1).ToString("x2");
                        string out3 = Convert.ToByte(partIP2).ToString("x2");
                        string out4 = Convert.ToByte(partIP3).ToString("x2");
                        string output = $"http://0x{out1}.0x{out2}.0x{out3}.0x{out4}";

                        Console.WriteLine("[+] Obfuscated IP: " + output + "\nPress Any Key To Continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Write("\nPlease Enter IP=> ");
                        string iptest = Console.ReadLine();

                        Console.WriteLine("[+] IP: " + iptest);
                        string[] arr1 = iptest.Split('.');

                        string partIP00 = arr1[0];
                        string partIP11 = arr1[1];
                        string partIP22 = arr1[2];
                        string partIP33 = arr1[3];

                        string out11 = Convert.ToByte(partIP00).ToString("x2");
                        string out22 = Convert.ToByte(partIP11).ToString("x2");
                        string out33 = Convert.ToByte(partIP22).ToString("x2");
                        string out44 = Convert.ToByte(partIP33).ToString("x2");
                        string output1 = $"http://0x{out11}.0x{out22}.0x{out33}.0x{out44}";

                        Console.WriteLine("[+] Obfuscated IP: " + output1 + "\nPress Any Key To Continue...");
                        Console.ReadKey();

                        break;
                }
            }
            catch { Console.WriteLine("An Error Occured!"); Console.ReadKey(); }
            Console.Clear();
            Program.Start();
        }
    }
}

