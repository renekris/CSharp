using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriter_koos_ruututega
{

    class Program
    {
        static int exponent = 2;
        static string path = "data.txt";
        static void Main(string[] args)
        {
            Console.Title = "StreamWriter^2 by Renekris";
            bool mainSwitch = false;
            bool mainSwitchCurrent = false;
            if (!File.Exists(path))
                File.Create(path).Dispose();
            while (true)
            {
                Console.WriteLine("[1]> Sisesta arv\n" +
                                  "[2]> Moonda astendajat [^{0}]\n" +
                                  "[3]> Lülita otsakirjutamine [{1}]\n" +
                                  "[4]> Ava fail\n" +
                                  "[5]> Ava faili asukoht\n" +
                                  "[6]> Puhasta fail [LINES: {2} | SIZE: {3}]", exponent, mainSwitchCurrent.ToString().ToUpper(), File.ReadLines(@"data.txt").Count(), Size());
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Arv(mainSwitchCurrent);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        ExponentChange();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        mainSwitchCurrent = Overwrite(ref mainSwitch);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Process.Start(path);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Process.Start("explorer.exe", "/select, " + path);
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        File.WriteAllText(path, String.Empty);
                        break;
                }
                Console.Clear();
            }
        }
        static void ExponentChange()
        {
            Console.Clear();
            Console.Write("Astendaja:");
            if (!int.TryParse(Console.ReadLine().Trim(), out exponent))
            {
                exponent = 2;
            }
        }
        static string Size()
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(path).Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##}{1}", len, sizes[order]);
        }
        static bool Overwrite(ref bool mainSwitch)
        {
            if (mainSwitch)
            {
                mainSwitch = false;
                return false;
            }
            else
            {
                mainSwitch = true;
                return true;
            }
        }

        static void Arv(bool mainSwitchCurrent)
        {
            Console.Clear();
            Console.Write("Sisesta mitmendani:");
            if (int.TryParse(Console.ReadLine().Trim(), out int kordus))
            {
                using (StreamWriter writer = new StreamWriter(path, mainSwitchCurrent))
                {
                    for (int i = 0; i < kordus; i++)
                    {
                        writer.WriteLine("{0, 6:N0}^{1} = {2, 6:N0}", i + 1, exponent, Math.Pow(i + 1, exponent));
                    }
                    writer.Close();
                }

                using (StreamReader reader = new StreamReader(path))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = reader.ReadLine();
                    }
                    reader.Close();
                }
                Console.ReadKey();
            }
        }
    }
}
