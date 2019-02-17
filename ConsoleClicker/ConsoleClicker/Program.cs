using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

    

namespace ConsoleClicker
{

    class Program
    {
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int powerx = 1, count1 = 0, countPowerX = 0, countBarsLimit = 0;
            float barsLimit = 50f, price1f = 50f, price2f = 100f, price3f = 10, bars = 0f, totalBars = 0f, menuSelection = 0, timedx = 0f;
            bool isSecret = false, side = false;
            Console.TreatControlCAsInput = true;
            Console.Title = "Console Clicker, Made by Renekris";
            Console.WriteLine("Welcome to Console Clicker - WIP\n\n \u004f\u0020\u252c\u00ac\u0020\u0020\u0020\u0020\u0020\u0020\u2591\u2591\u2591\u2591\n\u002f\u007c\u2514\u2563\u0020\u0020\u0020\u0020\u2593\u2593\u2593\u2593\u2593\u2593\u2593\u0020\u000a\u002f\u0020\u005c\u0020\u0020\u0020\u0020\u2592\u2592\u2592\u2593\u2593\u2593\u2593\u2592\u2592\u0020\u0020");
            Console.ReadKey();
        menu:
            Console.Clear();
            Console.WriteLine("~~~Welcome~~~");
            Console.WriteLine("\u2191 / \u2193 Arrows to Collect Bars \nESC / M - Market\n");
            if (isSecret == true)
            {
                Console.WriteLine("S - Secret menu");
            }
            
            ConsoleKey press = Console.ReadKey(true).Key;
            switch (press)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    menuSelection = 1;
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.M:
                    menuSelection = 2;
                    break;
                case ConsoleKey.S:
                    if (isSecret == true)
                    {
                        menuSelection = 3;
                    }
                    else
                    {
                        goto menu;
                    }
                    break;
                default:
                    goto menu;
            }
            //Bars
            while (menuSelection == 1)
            {
            
                Console.Clear();
                Console.WriteLine("Press the arrows shown below, to earn Bars.\nPress ESC to go back to the menu.\n");
            bars:
                Console.WriteLine("~{0:n2}/{1:n2} Bars", bars, barsLimit);
                if (side == false)
                {
                    Console.WriteLine("Press \u2191 +{0}\n", powerx);
                    Console.WriteLine("           \n           \n    _._     \n   / O \\     \n   \\| |/     \nO--+=-=+--O");
                    //Console.WriteLine("   ._O_.    \nO--<-+->--O\n     X     \n    / \\     \n   - -");
                    
                }
                else if (side == true)
                {
                    Console.WriteLine("Press \u2193 +{0}\n", powerx);
                    Console.WriteLine("O--,---,--O\n   \\ O /    \n    - -    \n     -    \n    / \\      \n   =   =    ");
                    
                }
                Console.SetCursorPosition(0, Console.CursorTop - 9);
                press = Console.ReadKey(true).Key;
                ClearCurrentConsoleLine();
                //Bar Values
                switch (press)
                {
                    case ConsoleKey.Escape:
                        goto menu;
                    case ConsoleKey.UpArrow:
                        if (press == ConsoleKey.UpArrow && count1 == 0 && barsLimit > bars)
                        {
                            side = true;
                            bars += 1 * powerx;
                            totalBars += 1 * powerx;
                            count1 = 1;
                            Thread.Sleep(10);
                            goto bars;
                        }
                        else
                            goto bars;
                    case ConsoleKey.DownArrow:
                        if (press == ConsoleKey.DownArrow && count1 == 1 && barsLimit > bars)
                        {
                            side = false;
                            bars += 1 * powerx;
                            totalBars += 1 * powerx;
                            count1 = 0;
                            Thread.Sleep(10);
                            goto bars;
                        }
                        else
                            goto bars;
                    default:
                        goto bars;
                }
            }
            //Market
            while (menuSelection == 2)
            {
                store:
                Console.Clear();
                Console.WriteLine("~~Welcome to the store~~\nYou have about ~{0:n2} bars.\nESC to menu\nEnter a number to buy\n", bars);
                Console.WriteLine("1.\t+= 1x enter power\n\t~{0:n2} Bars\n\tYou have bought {1}/10 of this\n\n", price1f, countPowerX);
                Console.WriteLine("2.\tSecret\n\t~{0:n2} Bars\n\n", price2f);
                Console.WriteLine("3.\tBars limit currently: {0:n2}\n\t~{1:n2} Bars\n\tYou have bought {2}/50 of this", barsLimit, price3f, countBarsLimit);
                press = Console.ReadKey(true).Key;
                switch (press)
                {
                    //Power upgrade
                    case ConsoleKey.D1:
                        if (bars >= price1f && countPowerX < 10)
                        {
                            countPowerX++;
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
                    //Secret upgrade
                    case ConsoleKey.D2:
                        if (bars >= price2f && isSecret == false)
                        {
                            Console.Clear();
                            isSecret = true;
                            bars = bars - price2f;
                            Console.WriteLine("You have just bought a secret.\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                    //Bar Counter Limit Upgrade
                    case ConsoleKey.D3:
                        if (bars >= price3f && countBarsLimit < 50)
                        {
                            countBarsLimit++;
                            bars = bars - price3f;
                            price3f = price3f * 1.25f;
                            barsLimit = barsLimit * 1.25f;
                            Console.Clear();
                            Console.WriteLine("You have just increased your Bars limit\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                    case ConsoleKey.Escape:
                        goto menu;
                    default:
                        goto store;
                }
            }
            //Secret menu
            while (menuSelection == 3)
            {
                Console.Clear();
                Console.WriteLine("This is the secret menu\nThis is where your statistics go.\n");
                Console.WriteLine("Current bars: {0:n2}", bars);
                Console.WriteLine("Total bars: {0:n2}\n", totalBars);
                Console.WriteLine("Any key to go back.");
                Console.ReadKey();
                goto menu;
            }
        }
    }
}

