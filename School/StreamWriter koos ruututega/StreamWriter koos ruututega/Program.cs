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
            using (StreamWriter writer = new StreamWriter(@"data.txt", mainSwitchCurrent))
            {
                for (int i = 0; i < kordus; i++)
                {
                    writer.WriteLine("{0, 6:G6}^2 = {1, 6:G10}", i + 1, Math.Pow(i + 1, 2));
                }
                writer.Close();
            }

            using (StreamReader reader = new StreamReader(@"data.txt"))
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
        static void Main(string[] args)
        {
            bool mainSwitch = false;
            bool mainSwitchCurrent = false;
            /*
             * Tekita programmi abil fail,
             * milles oleksid arvud ja nende ruudud
             * ühest kahekümneni.
             */

            while (true)
            {
                Console.WriteLine("[1]> Sisesta arv\n" +
                                  "[2]> Ava fail\n" +
                                  "[3]> Lülita otsakirjutamine [{0}]\n" +
                                  "[4]> Puhasta fail [LINES: {1}]", mainSwitchCurrent.ToString().ToUpper(), File.ReadLines(@"data.txt").Count()); 
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.D1:
                        Arv(mainSwitchCurrent);
                        break;
                    case ConsoleKey.D2:
                        Process.Start("data.txt");
                        break;
                    case ConsoleKey.D3:
                        mainSwitchCurrent = Overwrite(ref mainSwitch);
                        break;
                    case ConsoleKey.D4:
                        File.WriteAllText("data.txt", String.Empty);
                        break;
                }
                Console.Clear();
            }
        }
    }
}
