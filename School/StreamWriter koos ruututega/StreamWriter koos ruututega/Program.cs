using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriter_koos_ruututega
{
    class Program
    {
        static string path = "data.txt";
        static void Main(string[] args)
        {
            bool mainSwitch = false;
            bool mainSwitchCurrent = false;
            if (!File.Exists(path))
                File.Create(path).Dispose();
            while (true)
            {
                Console.WriteLine("[1]> Sisesta arv\n" +
                                  "[2]> Lülita otsakirjutamine [{0}]\n" +
                                  "[3]> Ava fail\n" +
                                  "[4]> Ava faili asukoht\n" +
                                  "[5]> Puhasta fail [LINES: {1} | SIZE: {2}]", mainSwitchCurrent.ToString().ToUpper(), File.ReadLines(@"data.txt").Count(), Size());
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.D1:
                        Arv(mainSwitchCurrent);
                        break;
                    case ConsoleKey.D2:
                        mainSwitchCurrent = Overwrite(ref mainSwitch);
                        break;
                    case ConsoleKey.D3:
                        Process.Start(path);
                        break;
                    case ConsoleKey.D4:
                        Process.Start("explorer.exe", "/select, " + path);
                        break;
                    case ConsoleKey.D5:
                        File.WriteAllText(path, String.Empty);
                        break;
                }
                Console.Clear();
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
            int kordus = int.Parse(Console.ReadLine().Trim());
            using (StreamWriter writer = new StreamWriter(path, mainSwitchCurrent))
            {
                for (int i = 0; i < kordus; i++)
                {
                    writer.WriteLine("{0, 6:N0}^2 = {1, 6:N0}", i + 1, Math.Pow(i + 1, 2));
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
