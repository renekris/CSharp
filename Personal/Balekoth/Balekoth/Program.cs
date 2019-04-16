using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Balekoth
{
    class Program : Oftenlib
    {
        
        static void Loading()
        {
            DialogResult loadBoxResult;
            loadBoxResult = MessageBox.Show("Do you want to load your latest save?", "Loading.", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (loadBoxResult == DialogResult.OK)
            {

                Console.WriteLine("Loading your latest save");
            }
        }

        static void Saving()
        {
            DialogResult loadBoxResult = MessageBox.Show("Do you want to save your progress?", "Saving.", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            Console.Clear();
            
            
            if (loadBoxResult == DialogResult.OK)
            {
                GetSettings.Save();
                Console.WriteLine("Saved!");
            }
            else
                Console.WriteLine("Resuming without saving");
        }

        static Properties.Settings GetSettings = new Properties.Settings();
        static Random rng = new Random();
        static void Main(string[] args) 
        {
            Console.Title = "BaleKoth";
            int mainMenuSel = 0;
            string[] randomRace = { "Skeleton", "Human", "Goblin", "Elf" };
            int userRace = rng.Next(0, randomRace.Length);
            int hpNumber = rng.Next(50, 100);
            int strNumber = rng.Next(3, 12);
            int intNumber = rng.Next(3, 12);
            int wisNumber = rng.Next(3, 12);
            int dexNumber = rng.Next(3, 12);
            int lukNumber = rng.Next(3, 12);
            int chaNumber = rng.Next(3, 12);
            int statPoints = rng.Next(20, 30);
            //Title
            WindowBuffer(17, 102);
            Title();
            Console.ReadKey();
            Console.Clear();
            WindowBuffer(Console.WindowHeight, 35);

            //Introduction
            MiniTitle();
            Console.WriteLine("Welcome to the land of Balekoth!\n" +
                "There are more than a hundred\n" +
                "dungeons and caves in this land.\n" +
                "Be the one to conquer them all\n" +
                "and become the master of dungeons\n" +
                "and caves.\n\n" +
                "What is your name traveler?");
            string userName = Console.ReadLine();
            Saving();
            Console.ReadKey();

            //Generated character sheet
            CharacterSheet(hpNumber, randomRace, userRace, strNumber, intNumber, wisNumber, dexNumber, lukNumber, chaNumber);
            Console.ReadKey();

            //Main Menu
            MiniTitle();

            Console.WriteLine("[1]> Adventure");
            Console.WriteLine("[2]> Market");
            Console.WriteLine("[3]> Guild Room");
            Console.WriteLine("[4]> Character Sheet");
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
                while (true)
                {
                    MiniTitle();
                    Console.WriteLine("You have encountered a monster");
                    Console.ReadKey();
                    Console.Clear();
                    MonsterAttack(hpNumber, strNumber);
                }
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

            }

            Console.ReadKey();
            Console.Clear();

        }

        static void MonsterAttack(int hpNumber, int strNumber)
        {
            MiniTitle();
            string[] enemyStrings = { "Skeleton", "Goblin", "Zombie", "Wolf", "Ghoul", "Ogre", "Mummy" };
            bool isKilled = false;
            int userHealth = hpNumber;
            int enemyHealth = rng.Next(50, 100);
            int enemyRandom = rng.Next(0, enemyStrings.Length);
            do
            {
                MiniTitle();
                Console.SetCursorPosition((Console.WindowWidth - (2 + enemyStrings[enemyRandom].Length)) / 2, Console.CursorTop);
                Console.WriteLine("*{0}*", enemyStrings[enemyRandom]);
                Console.SetCursorPosition((Console.WindowWidth - (9 + enemyHealth.ToString().Length)) / 2, Console.CursorTop);
                Console.WriteLine("Enemy HP: {0}\n", enemyHealth);
                Console.SetCursorPosition((Console.WindowWidth - (8 + userHealth.ToString().Length)) / 2, Console.CursorTop);
                Console.WriteLine("Your HP: {0}", userHealth);
                Console.WriteLine("Esc to run away, any key to attack");
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.Escape:
                        return;
                }
                int enemySTR = rng.Next(2, 8);
                userHealth -= enemySTR;
                enemyHealth -= strNumber;
            } while (enemyHealth > 0);

            Console.WriteLine("Enemy dead");
            SoundPlayer kill_enemy = new SoundPlayer("sounds/kill_enemy.wav");
            kill_enemy.Play();
            Console.ReadKey();
        }
        static void CharacterSheet(int hpNumber, string[] randomRace, int userRace, int strNumber, int intNumber, int wisNumber, int dexNumber, int lukNumber, int chaNumber)
        {

            //Character sheet generation
            MiniTitle();
            Console.WriteLine("This is your character sheet:");
            Console.WriteLine();

            Console.SetCursorPosition((Console.WindowWidth - (5 + randomRace[userRace].Length)) / 2, Console.CursorTop);
            Console.Write("Race: ");
            Console.Write("{0}\n", randomRace[userRace]);
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

            Console.SetCursorPosition((Console.WindowWidth - (4 + lukNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("CON: ");
            Console.Write("{0}\n", lukNumber);

            Console.SetCursorPosition((Console.WindowWidth - (4 + chaNumber.ToString().Length)) / 2, Console.CursorTop);
            Console.Write("CHA: ");
            Console.Write("{0}\n", chaNumber);
        }
    }
}