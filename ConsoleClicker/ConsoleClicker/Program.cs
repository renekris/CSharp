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
            int powerx = 1, count1 = 0, countPowerX = 0, countBarsLimit = 0, actionTiming = 50, menuSelection = 0, countActionTime = 0, sideMain = 0, clicks = 0, realClicks = 0;
            float barsLimit = 50f, price1f = 50f, price2f = 100f, price3f = 10f, bars = 0f, totalBars = 0f, price4f = 20f;
            bool pressedESC = false, isSecret = false, side = false, pressedDown = false, pressedUp = false, barOnGround = false;
            string boughtIt1 = null, barOnGroundString = null;
            Console.TreatControlCAsInput = true;
            Console.Title = "Console Clicker, Made by Renekris";
            Console.WriteLine("Welcome to Console Clicker - WIP\n\nProgramming by Renekris\nBig thanks to: Gio, Juškin\n\n\n\u0020\u263a\u0020\u252c\u2510\u0020\u0020\u0020\u2591\u2591\u2591\u2591\u000a\u002f\u007c\u2514\u2524\u0020\u0020\u2593\u2593\u2593\u2593\u2593\u2593\u2593\u000a\u002f\u0020\u005c\u0020\u0020\u2592\u2592\u2592\u2593\u2593\u2593\u2593\u2592\u2592");
            Console.ReadKey();
        menu:
            Console.Clear();
            Console.WriteLine("~~~Welcome~~~");
            Console.WriteLine("\u2191 / \u2193 Arrows to Collect Bars \nESC / M - Market");
            if (isSecret == true)
            {
                Console.WriteLine("S - Secret menu");
            }
            
            ConsoleKey press = Console.ReadKey(true).Key;
            switch (press)
            {
                case ConsoleKey.Enter:
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

                case ConsoleKey.Add:
                    bars = 10000;
                    goto menu;
                default:
                    goto menu;
            }
            //Bars
            while (menuSelection == 1)
            {
            
                Console.Clear();
                Console.WriteLine("Press the arrows shown below, to earn Bars.\nPress ESC to go back to the menu.\n");
                sideMain = 0;
                side = false;
            bars:
                if (bars < barsLimit)
                {
                    Console.WriteLine("~{0:n2}/{1:n2} Bars", bars, barsLimit);
                }
                //Pressed down
                if (side == false)
                {
                    realClicks++;
                    Console.WriteLine("Press \u2191 +{0}\n", powerx);
                    if (sideMain == 1 && pressedDown == true && barsLimit > bars)
                    {
                        //Bars 5/6
                        Console.WriteLine("           \nO--=-O-=--O\n    '-'    \n     v     \n    / )     \n    ~ z    \n           ");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 4/6
                        Console.WriteLine("           \n   ._O_.   \nO--<-+->--O\n     X     \n    / \\    \n    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 3/6
                        Console.WriteLine("           \n           \n   ,_O_,   \nO--(---)--O\n    >'>     \n    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 2/6
                        Console.WriteLine("           \n           \n           \n   ,-O-,    \nO--=---=--O\n    2\"2   ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 1/6
                        Console.WriteLine("           \n           \n    _._    \n   / O \\   \n   \\| |/   \nO--+=-=+--O");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        sideMain = 1;
                        pressedDown = false;
                        barOnGround = false;
                    }
                    else if (sideMain == 0 || sideMain == 1)
                    {
                        //Add here the start position.
                        //Bars 1/6 MAIN
                        if (pressedDown == false || pressedUp == false)
                        {
                            Console.WriteLine("           \n     O     \n   /- -\\  \n  ´  H  `   \n    / \\     \n   =   =   \nO---------O");
                            barOnGround = true;
                            sideMain = 1;
                        }
                        else
                            Console.WriteLine("           \n           \n    _._    \n   / O \\   \n   \\| |/   \nO--+=-=+--O");
                        if (barsLimit > bars)
                        {
                            if (pressedDown == false)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 8);
                                ClearCurrentConsoleLine();
                            }
                            else
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 7);
                                ClearCurrentConsoleLine();
                            }
                            
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 8);
                            Console.WriteLine("You got tired, go to the Market to increase your cap limit{0}", barOnGroundString);
                            ClearCurrentConsoleLine();
                        }
                        ClearCurrentConsoleLine();
                        sideMain = 1;
                    }
                }
                //Pressed up
                else if (side == true)
                {
                    realClicks++;
                    Console.WriteLine("Press \u2193 +{0}\n", powerx);
                    if (sideMain == 1 && pressedUp == true && barsLimit > bars)
                    {
                        //Bars 2/6
                        Console.WriteLine("           \n           \n            \n   ,-O-,   \nO--=---=--O\n    2\"2    \n            ");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 3/6
                        Console.WriteLine("           \n           \n   ,_O_,    \nO--(---)--O\n    >'>     \n    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 4/6
                        Console.WriteLine("           \n   ._O_.   \nO--<-+->--O\n     X     \n    / \\    \n    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 5/6
                        Console.WriteLine("           \nO--=-O-=--O\n    '-'     \n     v     \n    / )     \n    ~ z    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 6/6
                        Console.WriteLine("O--,---,--O\n   \\ O /   \n    - -     \n     -     \n    / \\    \n   =   =   ");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        sideMain = 1;
                        pressedUp = false;
                        barOnGround = false;
                    }
                    else if (sideMain == 1)
                    {
                        //Bars 6/6
                        Console.WriteLine("O--,---,--O\n   \\ O /   \n    - -     \n     -     \n    / \\    \n   =   =   ");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        sideMain = 1;
                        barOnGround = false;
                    }
                }
                //Amount to clear after hitting the Bar cap.
                if (bars < barsLimit)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                }
                else
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                press = Console.ReadKey(true).Key;
                ClearCurrentConsoleLine();
                //Bar Values
                switch (press)
                {
                    case ConsoleKey.Escape:
                        pressedESC = true;
                        if (barOnGround == true)
                        {
                            goto menu;
                        }
                        else
                        {
                            barOnGroundString = ", You have to put it back on the ground to leave";
                            goto bars;
                        }
                    case ConsoleKey.UpArrow:
                        if (press == ConsoleKey.UpArrow && count1 == 0 && barsLimit > bars)
                        {
                            side = true;
                            bars += 1 * powerx;
                            totalBars += 1 * powerx;
                            count1 = 1;
                            pressedUp = true;
                            clicks++;
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
                            pressedDown = true;
                            clicks++;
                            Thread.Sleep(10);
                            goto bars;
                        }
                        else
                            goto bars;
                    case ConsoleKey.Add:
                        bars += 10000;
                        goto bars;
                    default:
                        sideMain = 0;
                        goto bars;
                }
            }
            //Market
            while (menuSelection == 2)
            {
                store:
                Console.Clear();
                Console.WriteLine("~~Welcome to the store~~\nYou have about ~{0:n2} bars.\nESC to menu\nEnter a number to buy\n", bars);
                Console.WriteLine("1.\tIncreases the amount of Bars you gain\n\tYour current multiplier: {2}\n\tYou have bought {1}/10 of this\n\t~{0:n2} Bars\n", price1f, countPowerX, powerx);
                Console.WriteLine("2.\tGives you access to your overall stats\n\t~{0:n2} Bars, {1}\n", price2f, boughtIt1);
                Console.WriteLine("3.\tIncreases you maximum Bars limit\n\tYour current Bar limit: {0:n2}\n\tYou have bought {2}/50 of this\n\t~{1:n2} Bars\n", barsLimit, price3f, countBarsLimit);
                Console.WriteLine("4.\tDecrease the time that it takes to gain Bars\n\tYour current action time: {0}ms\n\tYou have bought {1}/25 of this\n\t~{2:n2} Bars\n", actionTiming, countActionTime, price4f);
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
                            Console.WriteLine("You have just bought += 1x power.\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                            price2f = 0;
                            boughtIt1 = "You have bought it already";
                            Console.WriteLine("You have just bought a secret.\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
                            Console.ReadKey();
                            goto store;
                        }
                        else if (isSecret == true)
                        {
                            Console.Clear();
                            Console.WriteLine("You have bought it already");
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
                            Console.WriteLine("You have just increased your Bars limit.\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                        //Bar Gaining Action Time
                    case ConsoleKey.D4:
                        if (bars >= price4f && countActionTime < 25)
                        {
                            countActionTime++;
                            bars = bars - price4f;
                            price4f = price4f * 1.10f;
                            actionTiming = actionTiming - 1;
                            Console.Clear();
                            Console.WriteLine("You have just increased your action time.\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                Console.WriteLine("Current Bars: {0:n2}", bars);
                Console.WriteLine("Total Bars collected: {0:n2}", totalBars);
                Console.WriteLine("Clicks in total: {1}({0})\n", clicks, realClicks);
                Console.WriteLine("Any key to go back.");
                Console.ReadKey();
                goto menu;
            }
        }
    }
}

