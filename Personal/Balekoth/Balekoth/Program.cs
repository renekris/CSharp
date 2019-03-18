using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            Console.WriteLine(" ════════════════════════════════════════════════════════════════════════════════════════════════════\n");
            Console.WriteLine("  ▀█████████▄     ▄████████  ▄█          ▄████████    ▄█   ▄█▄  ▄██████▄      ███        ▄█    █▄   ");
            Console.WriteLine("    ███    ███   ███    ███ ███         ███    ███   ███ ▄███▀ ███    ███ ▀█████████▄   ███    ███  ");
            Console.WriteLine("    ███    ███   ███    ███ ███         ███    █▀    ███▐██▀   ███    ███    ▀███▀▀██   ███    ███  ");
            Console.WriteLine("   ▄███▄▄▄██▀    ███    ███ ███        ▄███▄▄▄      ▄█████▀    ███    ███     ███   ▀  ▄███▄▄▄▄███▄▄");
            Console.WriteLine("  ▀▀███▀▀▀██▄  ▀███████████ ███       ▀▀███▀▀▀     ▀▀█████▄    ███    ███     ███     ▀▀███▀▀▀▀███▀ ");
            Console.WriteLine("    ███    ██▄   ███    ███ ███         ███    █▄    ███▐██▄   ███    ███     ███       ███    ███  ");
            Console.WriteLine("    ███    ███   ███    ███ ███▌    ▄   ███    ███   ███ ▀███▄ ███    ███     ███       ███    ███  ");
            Console.WriteLine("  ▄█████████▀    ███    █▀  █████▄▄██   ██████████   ███   ▀█▀  ▀██████▀     ▄████▀     ███    █▀   ");
            Console.WriteLine("                            ▀                        ▀                                              ");
            Console.WriteLine(" ════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            MiddleWriteLine("By");
            MiddleWrite("Rene Kristofer Pohlak");
            Console.ResetColor();
        }

        static void MiniTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            MiddleWriteLine("────────────────────────────");
            MiddleWriteLine("| ╔╗ ╔═╗╦  ╔═╗╦╔═╔═╗╔╦╗╦ ╦ |");
            MiddleWriteLine("~| ╠╩╗╠═╣║  ║╣ ╠╩╗║ ║ ║ ╠═╣ |~");
            MiddleWriteLine("| ╚═╝╩ ╩╩═╝╚═╝╩ ╩╚═╝ ╩ ╩ ╩ |");
            MiddleWriteLine("────────────────────────────");
            Console.WriteLine();
            Console.ResetColor();
        }

        static void Loading()
        {
            DialogResult loadBoxResult;
            loadBoxResult = MessageBox.Show("Do you want to load your latest save?", "Loading.", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (loadBoxResult == DialogResult.OK)
            {
                Console.WriteLine("Loading your latest save");
            }
        }

        static void Saving(string userName)
        {
            DialogResult loadBoxResult;
            loadBoxResult = MessageBox.Show("Do you want to save your progress?", "Saving.", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (loadBoxResult == DialogResult.OK)
            {
                Console.Clear();
                MiniTitle();
                Console.WriteLine("Saving your game");
                string path = @"../../GameSave.txt";
                try
                {
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                        TextWriter tw = new StreamWriter(path);
                        tw.WriteLine(userName);
                        tw.Close();
                    }
                    else if (File.Exists(path))
                    {
                        TextWriter tw = new StreamWriter(path);
                        tw.WriteLine(userName);
                        tw.Close();
                    }
                }
                catch (AccessViolationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        static void WindowBuffer(int height, int width)
        {
            Console.BufferWidth = Console.WindowWidth = width;
            Console.BufferHeight = Console.WindowHeight = height;
        }

        static void Main(string[] args)
        {
            Console.Title = "BALEKOTH";
            int mainMenuSel = 0;
            string[] randomUser = { "Skeleton", "Human", "Goblin", "Elf" };
            Random rng = new Random();
            int userRandom = rng.Next(0, randomUser.Length);
            int hpNumber = rng.Next(50, 100);
            int strNumber = rng.Next(3, 12);
            int intNumber = rng.Next(3, 12);
            int wisNumber = rng.Next(3, 12);
            int dexNumber = rng.Next(3, 12);
            int conNumber = rng.Next(3, 12);
            int chaNumber = rng.Next(3, 12);
            //Title
            WindowBuffer(17, 102);
            Title();
            Console.ReadKey();
            Console.Clear();
            WindowBuffer(Console.WindowHeight, 35);

            //Introduction
            MiniTitle();
            MiddleWriteLine("Welcome to the land of Balekoth!");
            MiddleWriteLine("There are more than a hundred");
            MiddleWriteLine("dungeons and caves in this land.");
            MiddleWriteLine("Be the one to conquer them all");
            MiddleWriteLine("and become the master of dungeons");
            MiddleWriteLine("and caves.");
            MiddleWriteLine("");
            Console.WriteLine("What is your name traveler?");
            string userName = Console.ReadLine();
            Saving(userName);
            Console.ReadKey();

            //Generated character sheet
            CharacterSheet(hpNumber, randomUser, userRandom, strNumber, intNumber, wisNumber, dexNumber, conNumber, chaNumber);
            Console.ReadKey();

            //Main Menu
            MiniTitle();

            MiddleWriteLine("[1]        Adventure");
            MiddleWriteLine("[2]           Market");
            MiddleWriteLine("[3]       Guild Room");
            MiddleWriteLine("[4]  Character Sheet");
            ConsoleKey press = Console.ReadKey(false).Key;
            switch (press)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    mainMenuSel = 1;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    mainMenuSel = 2;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    mainMenuSel = 3;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    mainMenuSel = 4;
                    break;
            }

            if (mainMenuSel == 1)
            {
                MiniTitle();
                Console.WriteLine("You have encountered a skeleton on your travels");

                MiniTitle();
                string[] enemyStrings = { "Skeleton", "Goblin", "Zombie", "Wolf", "Ghoul", "Ogre", "Mummy" };
                bool isKilled = false;
                int userHealth = hpNumber;
                int enemyHealth = rng.Next(5, 25);
                int enemyRandom = rng.Next(0, enemyStrings.Length);
                do
                {
                    MiniTitle();
                    Console.SetCursorPosition((Console.WindowWidth - (2 + enemyStrings[enemyRandom].Length)) / 2, Console.CursorTop);
                    Console.WriteLine("!{0}!", enemyStrings[enemyRandom]);
                    Console.SetCursorPosition((Console.WindowWidth - (9 + enemyHealth.ToString().Length)) / 2, Console.CursorTop);
                    Console.WriteLine("Enemy HP: {0}\n", enemyHealth);
                    Console.SetCursorPosition((Console.WindowWidth - (8 + userHealth.ToString().Length)) / 2, Console.CursorTop);
                    Console.WriteLine("Your HP: {0}", userHealth);
                    MiddleWriteLine("Any key to attack!");
                    Console.ReadKey();
                    int enemySTR = rng.Next(2, 8);
                    userHealth -= enemySTR;
                    enemyHealth -= strNumber;
                } while (enemyHealth > 0);

                MiddleWriteLine("Enemy dead");
                Console.ReadKey();
            }

            if (mainMenuSel == 2)
            {
                Console.WriteLine("");
            }

            if (mainMenuSel == 3)
            {
                Console.WriteLine("");
            }

            if (mainMenuSel == 4)
            {
                Console.WriteLine("");
            }

            Console.ReadKey();
            Console.Clear();

        }

        static void CharacterSheet(int hpNumber, string[] randomUser, int userRandom, int strNumber, int intNumber, int wisNumber, int dexNumber, int conNumber, int chaNumber)
        {

            //Character sheet generation
            MiniTitle();
            MiddleWriteLine("This is your character sheet:");
            Console.WriteLine();

            Console.SetCursorPosition((Console.WindowWidth - (5 + randomUser[userRandom].Length)) / 2, Console.CursorTop);
            Console.Write("Race: ");
            Console.Write("{0}\n", randomUser[userRandom]);
            Console.SetCursorPosition((Console.WindowWidth - (3 + hpNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("HP: ");
            Console.Write("{0}\n\n", hpNumber);

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
