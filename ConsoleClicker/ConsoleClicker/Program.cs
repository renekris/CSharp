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
            ConsoleKeyInfo cki;
            //ConsoleKey ch = Console.ReadKey(false).Key;
            //switch (ch)
            //{
            //    case ConsoleKey.Backspace:
            //        break;
            //    case ConsoleKey.Tab:
            //        break;
            //    case ConsoleKey.Clear:
            //        break;
            //    case ConsoleKey.Enter:
            //        break;
            //}
            int bars = 0, x = 1, count1 = 0;
            Console.TreatControlCAsInput = true;
            Console.Title = "Console Clicker, Made by Renekris";
            Console.WriteLine("Welcome to Console Clicker - WIP\n\n");
            Console.ReadKey();
            
        //Menu
        menu:
            //while (true)
            //{
            //    var ch = Console.ReadKey(false).Key;
            //    switch (ch)
            //    {
            //        case ConsoleKey.Escape:
            //            ShutdownRobot();
            //            return;
            //        case ConsoleKey.UpArrow:
            //            MoveRobotUp();
            //            break;
            //        case ConsoleKey.DownArrow:
            //            MoveRobotDown();
            //            break;
            //    }
            //}

            

            Console.Clear();
            Console.WriteLine("~~Main screen!~~");
            Console.WriteLine("Enter - collect bars \nEsc - store");
            cki = Console.ReadKey();
            while (cki.Key == ConsoleKey.Enter)
            {
                bars:
                Console.Clear();
                Console.WriteLine("Press <- and -> arrows to earn bars ~{0}\nPress esc to go back to the menu.", bars);
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    goto menu;
                }
                System.Threading.Thread.Sleep(9);
                if (cki.Key == ConsoleKey.LeftArrow && count1 == 0)
                {
                    bars += 1 * x;
                    count1 = 1;
                    goto bars;
                }

                if (cki.Key == ConsoleKey.RightArrow && count1 == 1)
                {
                    bars += 1 * x;
                    count1 = 0;
                    goto bars;
                }
                else {
                    goto bars;
                }
            }
            //Store
            while (cki.Key == ConsoleKey.Escape)
            {
                store:
                Console.Clear();
                Console.WriteLine("~~Welcome to the store~~\nYou have about ~{0} bars.\nEsc to menu\nEnter a number to buy\n", bars);
                Console.WriteLine("1.\t2x enter power\n\t~50 bars\n\n");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    if (bars >= 50)
                    {
                        x += 1;
                        bars = bars - 50;
                        Console.Clear();
                        Console.WriteLine("You have just bought += 1x power\n~{0} bars remaining.\n\nEsc to go back.", bars);
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

