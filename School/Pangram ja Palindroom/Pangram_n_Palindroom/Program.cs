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
            string[] palPamArray = new[]
            {
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
            Console.SetWindowSize(Console.WindowWidth + 30,Console.WindowHeight);
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<string> previousList = new List<string>();
            bool enteredBefore = false;
            string result = "", enteredStr = "";
            while (true)
            {
                //Stringi sisestamine
                Console.Write("Pangram lausel on kõik tähed olemas mis on tähestikus samuti" +
                              "\nPalindroom lause on mõlemat pidi lugedes sama." +
                              "\nSisestades \"0000\", Kirjutab välja erinevaid Pangramme ja Palindroome" +
                              "\nSisesta string mida kontrollida:");
                //Kontrollib kas while loop on lõpetanud > 1 kord
                if (enteredBefore)
                {
                    Console.WriteLine("\n\n\n\n~~Previously entered~~");
                    PreviousDisplay(enteredStr, ref previousList);
                    Console.SetCursorPosition(32, 3);
                }
                enteredStr = Console.ReadLine();
                Console.Clear();
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
                    //Kontrollib kas sisestatud on pangram
                    else if (Pangram(enteredStr))
                    {
                        result = "See on Pangram";
                    }
                    //Kontrollib kas sisestatud on palindroom 
                    else if (Palindroom(enteredStr))
                    {
                        result = "See on Palindroom";
                    }
                }
                //kirjutab sisestatud stringi + vastuse
                Console.WriteLine("Entered string: [>{0}<]\n{1}", enteredStr, result);
                enteredBefore = true;
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void PreviousDisplay(string enteredStr, ref List<string> previousList)
        {
            previousList.Add(enteredStr);
            foreach (var VARIABLE in previousList)
            {
                Console.WriteLine(VARIABLE);
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
             * Sisestatud stringil asetatakse space-id mitte millegagi, ehk, "Never odd or even" -> "Neveroddoreven".
             * Peale seda tehakse sellel kõik tähed lowercase "Neveroddoreven" -> "neveroddoreven".
             * Siis see keeratakse tagurpidi ja see võrdleb ise ennast "neveroddoreven" == "neveroddoreven".
             * Kui tõene, siis returnib true, else false.
             */
            inputString = Regex.Replace(inputString, "[\\W]", "");
            return inputString.ToLower().SequenceEqual(inputString.ToLower().Reverse());
        }
    }
}
