using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elutee
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Random rng = new Random();
            int majandusCount = 0, majandusKriis = 0;
            const int aastamax = 42;
            int aastaCurrent = 0;
            int kõrvalepanekCurrent = 0;
            Console.Title = "Kuidas rikkaks saada";
            Console.WriteLine("Kuidas rikkaks saada!\nAlustan 17 aastasena");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i <= aastamax; i++)
            {
                Console.Clear();
                aastaCurrent++;
                Console.WriteLine("Praegune aasta: {0} | Kõrvalolev raha: €{1:N0}\n", aastaCurrent + 17, RahaGain(aastaCurrent, ref kõrvalepanekCurrent));
                EventCourse(i, ref majandusKriis, majandusCount, ref kõrvalepanekCurrent);
                if (kõrvalepanekCurrent > 1000000)
                {
                    break;
                }
                Console.ReadKey();
            }

            Console.WriteLine("Oled teeninud > €1,000,000" +
                              "\nLähed nüüd pensionile.");
            Console.ReadKey();
        }

        static int RahaGain(int aastaCurrent, ref int kõrvalepanekCurrent)
        {
            if (aastaCurrent > 1)
            {
                Random rng = new Random();
                int kõrvalepanek = rng.Next(13420, 36320);
                return kõrvalepanekCurrent += kõrvalepanek;
            }

            return 0;
        }

        static void EventCourse(int i, ref int majandusCount, int majandusKriis, ref int kõrvalepanekCurrent)
        {
            Random rng = new Random();
            int addNext = rng.Next(50000, 100000);
            Event(i, majandusKriis, majandusCount);

            if (i + 17 > 39 && i + 17 < 43)
            {
                Console.WriteLine("Majandus kriis!\n+ {0}", addNext);
                kõrvalepanekCurrent += addNext;
            }
        }

        static void Event(int i, int majandusKriis, int majandusCount)
        {
            string[] töödStrings = new[] { "Andmeturbeinspektori", "C# programmeerija", "Andmetungia", "IT spetsialisti", "Tarkvaraarendaja" };
            Random rng = new Random();
            switch (i + 17)
            {
                case 17:
                    Console.WriteLine("Oled kooli lõpetanud ja valid tööd. Said omale {0} töö", töödStrings[rng.Next(0, 4)]);
                    break;
                case 18:
                    Console.WriteLine("test");
                    break;
                default:
                    break;
            }
        }
    }
}
