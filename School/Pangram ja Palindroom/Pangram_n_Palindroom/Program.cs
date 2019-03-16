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
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<string> previousList = new List<string>();
            bool enteredBefore = false;
            string result = "", enteredStr = "";
            while (true)
            {
                //Stringi sisestamine
                Console.Write("Sisesta string:");
                //Kontrollib kas while loop on lõpetanud > 1 kord
                if (enteredBefore)
                {
                    Console.WriteLine("\n\n\n\n~~Previously entered~~");
                    PreviousDisplay(enteredStr, ref previousList);
                    Console.SetCursorPosition(15, 0);
                }
                enteredStr = Console.ReadLine();
                Console.Clear();
                //Puhastab konsooli ja kirjutab 'sisesta string' uuesti
                Console.Write("Sisesta string:{0}\n", enteredStr);
                //Kontrollib kas sisestatud on pangram
                if (Palindroom(enteredStr) && Pangram(enteredStr))
                {
                    result = "See on Palindroom ja Pangram";
                }
                else if (Pangram(enteredStr))
                {
                    result = "See on Pangram";
                }
                //Kontrollib kas sisestatud on palindroom 
                else if (Palindroom(enteredStr))
                {
                    result = "See on Palindroom";
                }
                //kirjutab sisestatud stringi + vastuse
                Console.WriteLine("[>{0}<]\n{1}", enteredStr, result);
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
            return inputString.Replace(" ", "").ToLower().SequenceEqual(inputString.Replace(" ", "").ToLower().Reverse());
        }
    }
}
