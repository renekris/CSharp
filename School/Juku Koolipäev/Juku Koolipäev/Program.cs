using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            float jukuEnergia = 1f;
            while (true)
            {
                Console.WriteLine("Juku Energia: {0:P0}", jukuEnergia);
                if (jukuEnergia >= 0.50)
                {
                    ColorGreen("Juku on energiline!");
                }
                else if (jukuEnergia <= 0.49 && jukuEnergia >= 0.15)
                {
                    ColorBlue("Juku on kerges masenduses ja ta tuju on kehv.");
                }
                else if (jukuEnergia <= 0.14 && jukuEnergia >= 0.01)
                {
                    ColorDarkBlue("Juku on depresiivsuse äärel");
                }
                else if (jukuEnergia < 0.01)
                {
                    ColorRed("Jukul on seest valus ja ta on suremas depresiivsusest");
                }

                jukuEnergia -= 0.01f;
                
                Console.WriteLine("Sa oled just kooli jõudnud ja sa oled täiesti ärkvel!");
                Console.ReadKey();
            }
        }
    }
}
