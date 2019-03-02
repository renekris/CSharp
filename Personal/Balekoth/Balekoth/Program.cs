using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balekoth
{
    class Program
    {
        static void MiddleWriteLine(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }
        static void MiddleWrite(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.Write(s);
        }
        static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            MiddleWriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();
            MiddleWriteLine("▀█████████▄     ▄████████  ▄█          ▄████████    ▄█   ▄█▄  ▄██████▄      ███        ▄█    █▄   ");
            MiddleWriteLine("  ███    ███   ███    ███ ███         ███    ███   ███ ▄███▀ ███    ███ ▀█████████▄   ███    ███  ");
            MiddleWriteLine("  ███    ███   ███    ███ ███         ███    █▀    ███▐██▀   ███    ███    ▀███▀▀██   ███    ███  ");
            MiddleWriteLine(" ▄███▄▄▄██▀    ███    ███ ███        ▄███▄▄▄      ▄█████▀    ███    ███     ███   ▀  ▄███▄▄▄▄███▄▄");
            MiddleWriteLine("▀▀███▀▀▀██▄  ▀███████████ ███       ▀▀███▀▀▀     ▀▀█████▄    ███    ███     ███     ▀▀███▀▀▀▀███▀ ");
            MiddleWriteLine("  ███    ██▄   ███    ███ ███         ███    █▄    ███▐██▄   ███    ███     ███       ███    ███  ");
            MiddleWriteLine("  ███    ███   ███    ███ ███▌    ▄   ███    ███   ███ ▀███▄ ███    ███     ███       ███    ███  ");
            MiddleWriteLine("▄█████████▀    ███    █▀  █████▄▄██   ██████████   ███   ▀█▀  ▀██████▀     ▄████▀     ███    █▀   ");
            MiddleWriteLine("                          ▀                        ▀                                              ");
            MiddleWriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            MiddleWriteLine("~Written by Rene Kristofer Pohlak~");
            Console.ResetColor();
        }

        static void MiniTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            MiddleWriteLine("────────────────────────────");
            MiddleWriteLine("| ╔╗ ╔═╗╦  ╔═╗╦╔═╔═╗╔╦╗╦ ╦ |");
            MiddleWriteLine("~| ╠╩╗╠═╣║  ║╣ ╠╩╗║ ║ ║ ╠═╣ |~");
            MiddleWriteLine("| ╚═╝╩ ╩╩═╝╚═╝╩ ╩╚═╝ ╩ ╩ ╩ |");
            MiddleWriteLine("────────────────────────────");
            Console.WriteLine();
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            string[] randomUser = { "Skeleton", "Human", "Goblin", "Elf" };
            Random rng = new Random();
            int userRandom = rng.Next(0, randomUser.Length);
            int strNumber = rng.Next(3, 12);
            int intNumber = rng.Next(3, 12);
            int wisNumber = rng.Next(3, 12);
            int dexNumber = rng.Next(3, 12);
            int conNumber = rng.Next(3, 12);
            int chaNumber = rng.Next(3, 12);
            //Title
            Title();
            Console.ReadKey();
            Console.Clear();

            //Introduction
            MiniTitle();
            MiddleWriteLine("Welcome to the land of the Balekoth!");
            MiddleWriteLine("There are more than a hundred dungeons and caves in this land.");
            MiddleWriteLine("Be the one to conquer them all and become the master of dungeons and caves.");
            MiddleWriteLine("");
            Console.ReadKey();
            Console.Clear();

            //Generated character sheet
            CharacterSheet(randomUser, userRandom, strNumber, intNumber, wisNumber, dexNumber, conNumber, chaNumber);
            Console.ReadKey();
            Console.Clear();

            //Main Menu
            MiniTitle();

            MiddleWriteLine("[1] Market\n");
            MiddleWriteLine("[2] Guild Room\n");
            MiddleWriteLine("[3] Adventure\n");
            MiddleWriteLine("[4] Character Sheet");
            Console.ReadKey();
        }

        static void CharacterSheet(string[] randomUser, int userRandom, int strNumber, int intNumber, int wisNumber, int dexNumber, int conNumber , int chaNumber)
        {

            //Character sheet generation
            MiniTitle();
            MiddleWriteLine("This is your generated character sheet:");
            Console.WriteLine();

            Console.SetCursorPosition((Console.WindowWidth - (5 + randomUser[userRandom].Length)) / 2, Console.CursorTop);
            Console.Write("Race: ");
            Console.Write("{0}\n", randomUser[userRandom]);


            Console.SetCursorPosition((Console.WindowWidth - (4 + strNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("STR: ");
            Console.Write("{0}\n", strNumber);

            Console.SetCursorPosition((Console.WindowWidth - (4 + intNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("INT: ");
            Console.Write("{0}\n", intNumber);

            Console.SetCursorPosition((Console.WindowWidth - (4 + wisNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("WIS: ");
            Console.Write("{0}\n", wisNumber);

            Console.SetCursorPosition((Console.WindowWidth - (4 + dexNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("DEX: ");
            Console.Write("{0}\n", dexNumber);

            Console.SetCursorPosition((Console.WindowWidth - (4 + conNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("CON: ");
            Console.Write("{0}\n", conNumber);

            Console.SetCursorPosition((Console.WindowWidth - (4 + chaNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("CHA: ");
            Console.Write("{0}\n", chaNumber);
        }
    }
}
