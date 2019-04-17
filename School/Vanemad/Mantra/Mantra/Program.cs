using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mantra
{
    class Program
    {
        private static string path = @"data.txt";
        private static bool fileHas;
        static void Main(string[] args)
        {
            while (true)
            {
                
                if (!File.Exists(path))
                    File.Create(path).Dispose();

                Console.WriteLine("Sisesta Mantra:");
                string mantraReadLine = Console.ReadLine();

                retry:
                Console.Clear();
                Console.WriteLine("Sisesta Kogus:");
                if (int.TryParse(Console.ReadLine(), out int multiples))
                {
                    Console.Clear();
                    string mantra = MantraCheck(mantraReadLine);
                    if (fileHas)
                        Console.WriteLine("Mantra on failist loetud!");
                    else
                        MantraWrite(mantraReadLine);
                    for (int i = 0; i < multiples; i++)
                        Console.WriteLine(mantra);
                }
                else
                    goto retry;

                Console.ReadKey();
                fileHas = false;
                Console.Clear();
            }
        }

        static void MantraWrite(string mantraReadLine)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(mantraReadLine);
            }
        }
        static string MantraCheck(string mantra)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while (!reader.EndOfStream && reader.Peek() > -1)
                    if ((line = reader.ReadLine()) == mantra)
                    {
                        fileHas = true;
                        return mantra = line;
                    }
                return mantra;
            }
        }
    }
}
