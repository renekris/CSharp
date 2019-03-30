using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elutee
{
    class Program
    {
        static void Main(string[] args)
        {
            const int aastamax = 60;
            int aastaCurrent = 0;
            int kõrvalepanek = 5;
            int kõrvalepanekCurrent = 0;
            Console.Title = "Kuidas rikkaks saada";
            Console.WriteLine("Kuidas rikkaks saada!\nAlustan 17 aastasena");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i <= aastamax; i++)
            {
                Console.Clear();
                aastaCurrent++;
                Console.WriteLine("Praegune aasta: {0}\n", aastaCurrent + 17);
                kõrvalepanekCurrent += kõrvalepanek;
                Console.WriteLine("Kõrvalolev raha: {0}", kõrvalepanekCurrent);
                Event(i);
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        static string Event(int i)
        {
            Random rng = new Random();
            int majandusKriis = rng.Next(0, 60);
            int majandusKriis2 = rng.Next(0, 60);
            string result = "";
            switch (i)
            {
                case 0:
                    result = "Aasta 1";
                    break;
                case 1:
                    result = "Aasta 2";
                    break;
                default:
                    result = "ERROR";
                    break;
            }
            return result;
        }
    }
}
