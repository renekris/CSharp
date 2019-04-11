using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Sisesta: ");
                string entered = Console.ReadLine();
                Console.SetCursorPosition(0, 2);
                Console.Write("Numbrid: ");
                foreach (var VARIABLE in entered)
                {
                    switch (VARIABLE.ToString().ToUpper())
                    {
                        case "A":
                        case "B":
                        case "C":
                            Console.Write("2");
                            break;
                        case "D":
                        case "E":
                        case "F":
                            Console.Write("3");
                            break;
                        case "G":
                        case "H":
                        case "I":
                            Console.Write("4");
                            break;
                        case "J":
                        case "K":
                        case "L":
                            Console.Write("5");
                            break;
                        case "M":
                        case "N":
                        case "O":
                            Console.Write("6");
                            break;
                        case "P":
                        case "Q":
                        case "R":
                        case "S":
                            Console.Write("7");
                            break;
                        case "T":
                        case "U":
                        case "V":
                            Console.Write("8");
                            break;
                        case "W":
                        case "X":
                        case "Y":
                        case "Z":
                            Console.Write("9");
                            break;
                        case " ":
                            Console.Write(" ");
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
