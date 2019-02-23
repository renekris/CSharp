using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Juku_Koolipäev
{
    class Program
    {
        static void ColorGreen(string inputString)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(inputString);
            Console.ResetColor();
        }
        static void ColorBlue(string inputString)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(inputString);
            Console.ResetColor();
        }
        static void ColorDarkBlue(string inputString)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(inputString);
            Console.ResetColor();
        }
        static void ColorRed(string inputString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inputString);
            Console.ResetColor();
        }

        static void jukuValues(float jukuEnergia)
        {
            Console.WriteLine("Juku Energia: {0:P0}", jukuEnergia);
            if (jukuEnergia >= 0.50)
            {
                ColorGreen("Juku on energiline!\n");
            }
            else if (jukuEnergia <= 0.49 && jukuEnergia >= 0.15)
            {
                ColorBlue("Juku on kerges masenduses ja ta tuju on kehv.\n");
            }
            else if (jukuEnergia <= 0.14 && jukuEnergia >= 0.01)
            {
                ColorDarkBlue("Juku on depresiivsuse äärel!\n");
            }
            else if (jukuEnergia < 0.01)
            {
                ColorRed("Jukul on seest valus ja ta on suremas depresiivsusest!\n");
            }
        }

        static void JukuHinne(int hinne)
        {
            if (hinne == 1)
            {
                Console.WriteLine("Juku sai endale hinde X");
            }
            else
            {
                Console.WriteLine("Juku sai endale hinde {0}", hinne);
            }
        }

        static void JukuSwitchCase(ref float jukuEnergia, int hinne)
        {
            switch (hinne)
            {
                case 1:
                    jukuEnergia -= 0.75f;
                    break;
                case 2:
                    jukuEnergia -= 0.50f;
                    break;
                case 3:
                    jukuEnergia -= 0.40f;
                    break;
                case 4:
                    jukuEnergia -= 0.30f;
                    break;
                case 5:
                    jukuEnergia -= 0.20f;
                    break;
                default:
                    jukuEnergia -= 1f;
                    break;
            }
        }
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.OutputEncoding = Encoding.Unicode;
            int selectionMenu = 0, sündmus, hinne;
            float jukuEnergia = 1f;
            string[] syndimus = { "tunnikontroll", "kontrolltöö", "kodutööde esitamine" };
            while (true)
            {
                if (selectionMenu == 0)
                {
                    jukuValues(jukuEnergia);
                    Console.WriteLine("Sa oled just kooli jõudnud ja sa oled täiesti ärkvel!\n\n" +
                                      "Tänane tunniplaan on:\n" +
                                      "1. tund | Programmeerimine\n" +
                                      "2. tund | Eesti keel\n" +
                                      "3. tund | Inglise keel\n" +
                                      "3. tund | Lõuna\n" +
                                      "4. tund | Keemia\n" +
                                      "5. tund | Matemaatika\n" +
                                      "6. tund | Operatsiooni süsteemide alused");
                    Console.ReadKey();
                    Console.Clear();
                    selectionMenu = 1;
                }
                if (selectionMenu == 1)
                {
                    //rng
                    sündmus = rng.Next(0, 3);
                    hinne = rng.Next(1, 6);
                    //switch case | decreases the energy
                    JukuSwitchCase(ref jukuEnergia, hinne);
                    //juku energia number | juku olukord
                    jukuValues(jukuEnergia);
                    Console.WriteLine("Esimene tund on Programmeerimine\nÕpetaja ütles jukule, et täna on {0}", syndimus[sündmus]);
                    //1-5 hinne jukule
                    JukuHinne(hinne);
                    Console.ReadKey();
                    Console.Clear();
                    selectionMenu = 2;
                }

                if (selectionMenu == 2)
                {
                    //rng
                    sündmus = rng.Next(0, 3);
                    hinne = rng.Next(1, 6);
                    //switch case | decreases the energy
                    JukuSwitchCase(ref jukuEnergia, hinne);
                    //juku energia number | juku olukord
                    jukuValues(jukuEnergia);
                    Console.WriteLine("Teine tund on Eesti Keel\nÕpetaja ütles jukule, et täna on {0}", syndimus[sündmus]);
                    //1-5 hinne jukule
                    JukuHinne(hinne);
                    Console.ReadKey();
                    Console.Clear();
                    selectionMenu = 2;
                }
            }
        }
    }
}
