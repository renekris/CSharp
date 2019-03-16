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
            //string enteredStr1 = "a b c d e f g h i j k l m n o p q r s š z ž t u v w õ ä ö ü x y";
            //string lettersEst = "a b c d e f g h i j k l m n o p q r s z t u v w õ ä ö ü x y";
            //string[] lettersSplit = lettersEng.Split(new char[] { ' ' });
            //List<string> lettersList = new List<string>();
            //var match = enteredStr.IndexOfAny(new char[] {'*', '&', '#'}) != -enteredStr.Length;
            //for (int i = 0; i < lettersSplit.Length; i++)
            //{
            //    Console.Write("{0}", lettersSplit[i]);
            //}
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            string result;
        start:
            Console.Write("Sisesta string:");
            string enteredStr = Console.ReadLine();
            if (Pangram(enteredStr))
            {
                result = "See on Pangram";
            }
            else
            {
                result = "Ei ole Pangram";
            }
            Console.WriteLine(enteredStr + "\n{0}\n", result);
            goto start;
        }

        static bool Pangram(string inputString)
        {
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
    }
}
