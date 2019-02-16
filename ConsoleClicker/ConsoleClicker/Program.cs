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
            int powerx = 1, count1 = 0;
            float price1f = 50f, bars = 0f;
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
            Console.WriteLine("~~~Welcome~~~");
            Console.WriteLine("<-/-> Arrows to Collect Bars \nESC - Store");
            cki = Console.ReadKey();
            while (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.LeftArrow)
            {
                bars:
                Console.Clear();
                Console.WriteLine("Press <- and -> arrows to earn Bars ~{0:n2}\nPress ESC to go back to the menu.", bars);
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    goto menu;
                }
                System.Threading.Thread.Sleep(9);
                if (cki.Key == ConsoleKey.LeftArrow && count1 == 0)
                {
                    bars += 1 * powerx;
                    count1 = 1;
                    goto bars;
                }

                if (cki.Key == ConsoleKey.RightArrow && count1 == 1)
                {
                    bars += 1 * powerx;
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
                Console.WriteLine("~~Welcome to the store~~\nYou have about ~{0:n2} bars.\nESC to menu\nEnter a number to buy\n", bars);
                Console.WriteLine("1.\t+= 1x enter power\n\t~{0:n2} Bars\n\n", price1f);
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    if (bars >= price1f)
                    {
                        bars = bars - price1f;
                        price1f = price1f * 1.21f;
                        powerx += 1;
                        Console.Clear();
                        Console.WriteLine("You have just bought += 1x power\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
                        Console.ReadKey();
                        goto store;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough Bars!");
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

