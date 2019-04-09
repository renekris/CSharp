using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriter_koos_ruututega
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Tekita programmi abil fail,
             * milles oleksid arvud ja nende ruudud
             * ühest kahekümneni.
             */
            while (true)
            {
                Console.WriteLine("[1]> Sisesta arv\n" +
                                  "[2]> Ava fail kuhu kirjutas");
                Console.Clear();
                Console.Write("Sisesta mitmendani:");
                int kordus = int.Parse(Console.ReadLine());
                using (StreamWriter writer = new StreamWriter(@"data.txt"))
                {
                    for (int i = 0; i < kordus; i++)
                    {
                        writer.WriteLine("{0, 6:G25}E2 = {1, 6:G25}", i + 1, Math.Pow(i + 1, 2));
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
        }
    }
}
