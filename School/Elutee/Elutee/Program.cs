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
            const int aastamax = 42;
            int teenimineMin = 0, 
                teenimineMax = 0,
                majandusKriis = 0,
                aastaCurrent = 0,
                kõrvalepanekCurrent = 0;
            Console.Title = "Kuidas rikkaks saada";
            Console.WriteLine("Rikkaks saamise elujoon!\nAlustan 17 aastasena");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i <= aastamax; i++)
            {
                Console.Clear();
                aastaCurrent++;
                Console.WriteLine("Praegune eluaasta: {0} | Kõrvalolev raha: €{1:N0}\n", aastaCurrent + 17, RahaGain(aastaCurrent, ref kõrvalepanekCurrent, teenimineMax, teenimineMin));
                EventCourse(i, ref majandusKriis, ref kõrvalepanekCurrent, ref teenimineMin, ref teenimineMax);
                if (kõrvalepanekCurrent > 1000000)
                {
                    Console.WriteLine("Oled teeninud > €1,000,000. Lähed nüüd pensionile.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("   Jätka   \n  [SPACE]");
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("  >Jätka<  \n  [SPACE]");
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 5);
                Console.WriteLine(" >>Jätka<< \n  [SPACE]");
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 5);
                Console.WriteLine(">>>Jätka<<<\n  [SPACE]");
                Console.ReadKey();
            }
            Console.WriteLine("Sa oled 60a vana ja sul pole ikka veel 1,000,000. Elu läbi!");
            Console.ReadKey();
        }

        static int RahaGain(int aastaCurrent, ref int kõrvalepanekCurrent, int teenimineMax, int teenimineMin)
        {
            if (aastaCurrent > 1)
            {
                Random rng = new Random();
                int kõrvalepanek = rng.Next(teenimineMin, teenimineMax);
                return kõrvalepanekCurrent += (kõrvalepanek * 12) - 500;
            }

            return 0;
        }

        static void EventCourse(int i, ref int majandusKriis, ref int kõrvalepanekCurrent, ref int teenimineMin, ref int teenimineMax)
        {
            Random rng = new Random();
            string temp = "";
            int kink = 0;
            string[] töödStrings = new[] { "Andmeturbeinspektori", "C# programmeerija", "Andmetungia", "IT spetsialisti", "Tarkvaraarendaja" };
            string[] keelStrings = new[] { "Python", "C++", "Javascripti", "Java", "PHP" };
            MajandusEvent(i, majandusKriis, ref kõrvalepanekCurrent);
            switch (i + 17)
            {
                case 17:
                    temp = töödStrings[rng.Next(0, 5)];
                    Console.WriteLine("Oled kooli lõpetanud ja valid tööd. Said omale {0} töö", temp);
                    break;
                case 20:
                case 30:
                case 40:
                case 50:
                case 60:
                    kink = rng.Next(500, 1000);
                    Console.WriteLine("Sinul on juubel, sa saad lähedastelt €{0:N0}", kink);
                    break;
                case 22:
                    int tempint = rng.Next(400, 1500);
                    Console.WriteLine("Uue telefoni ostmiseks läks maksma €{0:N0}", tempint);
                    kõrvalepanekCurrent -= tempint;
                    break;
                case 31:
                    temp = keelStrings[rng.Next(0, 5)];
                    Console.WriteLine("Lähed kooli edasi õppima, valisid {0} keele", temp);
                    break;
                case 32:
                    temp = töödStrings[rng.Next(0, 5)];
                    Console.WriteLine("Oled selgeks õppinud veel ühe programmeerimise keele ja valid uue töö. Sa valisid {0} töö", temp);
                    break;
                case 41:
                    tempint = rng.Next(5000, 20000);
                    Console.WriteLine("Keskea kriis, kulutad €{0:N0}, et ennast rahustada", tempint);
                    kõrvalepanekCurrent -= tempint;
                    break;
                case 46:
                    tempint = rng.Next(5000, 20000);
                    Console.WriteLine("Sinu auto parandamiseks läks maksma €{0:N0}", tempint);
                    kõrvalepanekCurrent -= tempint;
                    break;
                case 52:
                    tempint = rng.Next(60000, 80000);
                    Console.WriteLine("Uue maja ostmiseks läks maksma €{0:N0}", tempint);
                    kõrvalepanekCurrent -= tempint;
                    break;
            }
            switch (temp)
            {
                case "Andmeturbeinspektori":
                    teenimineMin = 1400;
                    teenimineMax = 1680;
                    break;
                case "C# programmeerija":
                    teenimineMin = 1900;
                    teenimineMax = 3600;
                    break;
                case "Andmetungia":
                    teenimineMin = 2100;
                    teenimineMax = 2400;
                    break;
                case "IT spetsialisti":
                    teenimineMin = 1900;
                    teenimineMax = 2600;
                    break;
                case "Tarkvaraarendaja":
                    teenimineMin = 1900;
                    teenimineMax = 2300;
                    break;
            }

            kõrvalepanekCurrent += kink;
        }

        static void MajandusEvent(int i, int majandusKriis, ref int kõrvalepanekCurrent)
        {
            Random rng = new Random();
            int addNext = rng.Next(30000, 60000);
            if (i + 17 > 39 && i + 17 < 43)
            {
                Console.WriteLine("Majandus kriis!\nSa teenisid €{0:N0} extra", addNext);
                kõrvalepanekCurrent += addNext;
            }
        }
    }
}
