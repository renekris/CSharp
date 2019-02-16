using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Console Clicker, Made by Renekris";
            int bars = 0, x = 1;
            Console.WriteLine("Welcome to Console Clicker - WIP\n\n");
            Console.ReadKey();
            ConsoleKeyInfo cki;
        //Menu
        menu:
            Console.Clear();
            Console.WriteLine("~~Main screen!~~");
            Console.WriteLine("Enter - collect bars \nEsc - store");
            cki = Console.ReadKey();
            while (cki.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                if (cki.Key == ConsoleKey.Enter)
                {
                    bars += 1 * x;
                    Console.WriteLine("Press enter to earn bars ~{0}\nPress esc to go back to the menu.", bars);
                }
                
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    goto menu;
                }
                System.Threading.Thread.Sleep(9);
            }
            //Store
            while (cki.Key == ConsoleKey.Escape)
            {
                store:
                Console.Clear();
                Console.WriteLine("~~Welcome to the store~~\nYou have about ~{0} bars.\nEsc to menu\nEnter a number to buy\n", bars);
                Console.WriteLine("1. 2x enter power");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    if (bars >= 50)
                    {
                        x = 2;
                        bars = bars - 50;
                        Console.Clear();
                        Console.WriteLine("You have just bought 2x power\n~{0} bars remaining.\n\nEsc to go back.", bars);
                        Console.ReadKey();
                        goto store;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You dont have enough bars!");
                        Console.ReadKey();
                        goto store;
                    }
                }
                else if (cki.Key == ConsoleKey.Escape)
                {
                    goto menu;
                }
            }
        }
    }
}

