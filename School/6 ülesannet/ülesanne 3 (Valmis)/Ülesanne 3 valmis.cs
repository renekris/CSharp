using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int nul = 0, uks = 0, rng;
            Random resultaat = new Random();
            Console.WriteLine("16 Õpilase tulemused:");
            for (int i = 0; i < 16; i++)
            {
                rng = resultaat.Next(0, 2);
                Console.WriteLine("{0}. Õpilase tulemus: {1}", i + 1, rng);
                if (rng == 0)
                {
                    nul++;
                }
                else if (rng == 1)
                {
                    uks++;
                }

            }
            Console.WriteLine("Läbisid:{0} Kukkusid läbi:{1}", nul, uks);
            if (nul >= 8)
            {
                Console.WriteLine("Õpetajas saavad boonust!");
            }
            else
            {
                Console.WriteLine("Õpetajad ei saa boonust kuna üle poole klassi kukkusid läbi!");  
            }
            Console.ReadKey();
        }
    }
}
