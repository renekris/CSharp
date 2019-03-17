using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Pangram_n_Palindroom
{
    class Program
    {
        static void Main(string[] args)
        {
            //Teen konsooli pikemasks, sest kui kirjutada "0000", siis array text overflowib
            Console.SetWindowSize(Console.WindowWidth + 30, Console.WindowHeight);
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<string> previousList = new List<string>();
            bool enteredBefore = false;
            string result, enteredStr = "";
            int counter = 0;
            while (true)
            {
                result = "N/A";
                Console.Write("Pangram lausel on kõik tähed olemas mis on tähestikus samuti. Näiteks: \"The quick brown fox jumps over the lazy dog\"" +
                              "\nPalindroom lause on mõlemat pidi lugedes sama. Näiteks: \"sos\" või \"tacocat\" " +
                              "\nSisestades \"0000\", Kirjutab välja erinevaid Pangramme ja Palindroome" +
                              "\nSisesta string mida kontrollida:");
                ColorExample();
                //Kontrollib kas while loop on lõpetanud > 1 kord
                PreviouslyEnteredDisplay(enteredBefore, enteredStr, previousList, counter);
                //Stringi sisestamine
                enteredStr = Console.ReadLine();
                Console.Clear();
                //Kontrollib sisestatud stringi
                MainCheck(ref enteredStr, ref result);
                //Kirjutab sisestatud stringi + vastuse
                if (enteredStr != "0000")
                {
                    Console.WriteLine("Entered string: [>{0}<]\n{1}", enteredStr, result);
                }
                enteredBefore = true;
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void MainCheck(ref string enteredStr, ref string result)
        {
            //Testimise array
            string[] palPamArray = new[]
            {
                "The quick brown fox jumps over the lazy dog",
                "Vamp fox held quartz duck just by wing",
                "The five boxing wizards jump quickly",
                "Waxy and quivering jocks fumble pizza",
                "A very bad quack might jinx zippy fowls",
                "Heavy boxes perform quick waltzes and jigs",
                "A quick movement of the enemy will jeopardize six gunboats",
                "A man, a plan, a cat, a ham, a yak, a yam, a hat, a canal-Panama!",
                "A new order began, a more Roman age bred Rowena.",
                "A nut for a jar of tuna.",
                "A Santa dog lived as a devil God at NASA.",
                "A Toyota’s a Toyota.",
                "Aibohphobia (fear of palindromes)",
                "Amy, must I jujitsu my ma?",
                "Are Mac ‘n’ Oliver ever evil on camera?",
                "Oh, wet Alex - a jar, a fag! Up, disk, curve by! Man Oz, Iraq, Arizona, my Bev? Ruck's id-pug, a far Ajax, elate? Who?",
                "Bewareth gifts; a pyre – vex a tide; Lo! Jack no mazes... \"You quoy!\" sez a monk.  Cajoled, I tax every past fighter – a web!",
                "'Cwm, fjard-knob glyphs vext quiz. I - U QT. 'x' Ev! Sh, Pyl! (G'bonk!) Dra' J-F m' W.C.'"
            };
            if (enteredStr == "0000")
            {
                foreach (var VARIABLE in palPamArray)
                {
                    string temp = "None";
                    if (Pangram(VARIABLE) && Palindroom(VARIABLE))
                    {
                        temp = "Pangram + Palindroom";
                    }
                    else if (Pangram(VARIABLE))
                    {
                        temp = "Pangram";
                    }
                    else if (Palindroom(VARIABLE))
                    {
                        temp = "Palindroom";
                    }
                    Console.WriteLine("{0} = {1}", temp, VARIABLE);
                }
            }
            else
            {
                if (Palindroom(enteredStr) && Pangram(enteredStr))
                {
                    result = "See on Palindroom ja Pangram";
                }
                else if (Pangram(enteredStr))
                {
                    result = "See on Pangram";
                }
                else if (Palindroom(enteredStr))
                {
                    result = "See on Palindroom";
                }
            }
        }
        static void ColorExample()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(67, 1);
            Console.Write("t     t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(68, 1);
            Console.Write("a   a");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(69, 1);
            Console.Write("c c");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(70, 1);
            Console.Write("o");
            Console.ResetColor();
            Console.SetCursorPosition(32, 3);
        }
        static void PreviouslyEnteredDisplay(bool enteredBefore, string enteredStr, List<string> previousList, int counter)
        {
            if (enteredBefore)
            {
                Console.WriteLine("\n\n\n\n>~Previously entered~<");
                previousList.Add(enteredStr);
                foreach (var VARIABLE in previousList)
                {
                    counter++;
                    Console.WriteLine("{0}. >{1}<", counter, VARIABLE);
                }
                Console.SetCursorPosition(32, 3);
            }
        }
        static bool Pangram(string inputString)
        {
            /*
             * Töötab lausega milles on > (rohkem kui) 26 erinevat karakterit.
             * Ehk Pangram alamprogrammi for loop lisab booli arrayse true,
             * kui karakter on olemas. Lõpus kontrollib, kas on rohkem kui 26 karakterit,
             * kui on, siis returnib true, else false.
             */

            bool[] fullBools = new bool[26];
            int boolIndex = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if ('A' <= inputString[i] && inputString[i] <= 'Z')
                {
                    boolIndex = inputString[i] - 'A';
                }
                else if ('a' <= inputString[i] && inputString[i] <= 'z')
                {
                    boolIndex = inputString[i] - 'a';
                }

                fullBools[boolIndex] = true;
            }

            for (int i = 0; i <= 25; i++)
            {
                if (fullBools[i] == false)
                {
                    return (false);
                }
            }

            return (true);
        }

        static bool Palindroom(string inputString)
        {
            /*
             * Sisestatud stringil asetatakse non-word karakterid mitte millegagi, ehk, "[]Never, odd!or even." -> "Neveroddoreven".
             * Peale seda tehakse sellel kõik tähed lowercase "Neveroddoreven" -> "neveroddoreven".
             * Siis see keeratakse tagurpidi ja see võrdleb ise ennast "neveroddoreven" == "neveroddoreven".
             * Kui tõene, siis returnib true, else false.
             */
            if (inputString != "")
            {
            inputString = Regex.Replace(inputString, "[\\W]", "");
            return inputString.ToLower().SequenceEqual(inputString.ToLower().Reverse());
            }

            return false;
        }
    }
}
