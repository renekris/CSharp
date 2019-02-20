using System;
using System.Diagnostics;
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
            Console.OutputEncoding = Encoding.Unicode;
            int powerx = 1, count1 = 0, countPowerX = 0, countBarsLimit = 0, actionTiming = 50, menuSelection, countActionTime = 0, sideMain = 1, foo = 0, clicks = 0, realClicks = 0;
            float barsLimit = 50f, price1F = 50f, price2F = 100f, price3F = 10f, bars = 0f, totalBars = 0f, price4F = 20f;
            bool isSecret = false, side, pressedDown = false, pressedUp = false, pressedDefault = false;
            string boughtIt1 = null;
            Console.TreatControlCAsInput = true;
            Console.Title = "Console Clicker, Made by Renekris";
            Console.WriteLine("Welcome to Console Clicker - WIP\nUnfortunately there are a couple of bugs present with the animation\n\nProgramming by Renekris/Rene Kristofer Pohlak\nBig thanks to: Gio, Juškin, for giving me ideas to work with\n\n\n\u0020\u263a\u0020\u252c\u2510\u0020\u0020\u0020\u2591\u2591\u2591\u2591\u000a\u002f\u007c\u2514\u2524\u0020\u0020\u2593\u2593\u2593\u2593\u2593\u2593\u2593\u000a\u002f\u0020\u005c\u0020\u0020\u2592\u2592\u2592\u2593\u2593\u2593\u2593\u2592\u2592");
            Console.ReadKey();
        menu:
            Console.Clear();
            Console.WriteLine("Welcome to Console Clicker~~\n\nThis is a game made by Renekris,\nTo start playing, you must press the (\u2191 / \u2193) arrow keys.\nWith Bars you can buy different upgrades to earn Bars quicker.\n");
            Console.WriteLine("Press the arrow to collect Bars\n>\u2191 / \u2193\n");
            if (isSecret)
            {
                Console.WriteLine("This is where your overall statistics go\n0 - Statistics Menu\n");
            }
            Console.WriteLine("Market is for normal upgrades\n>1. - Market\n");
            Console.WriteLine("Supermarket is for super upgrades\n>2 - SuperMarket\n");
            Console.WriteLine("Slot Machine is for testing your luck\n>3 - Slot Machine\n");
            Console.WriteLine("This is a link to my Github,\nif you want to keep up with the progress of the development\n>G - Project's Github (github.com/renekris/CSharp)");
            ConsoleKey press = Console.ReadKey(true).Key;
            switch (press)
            {
                //Github
                case ConsoleKey.G:
                    Process.Start("https://github.com/renekris/CSharp");
                    goto menu;
                //Game start
                case ConsoleKey.Enter:
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    menuSelection = 1;
                    break;
                //Secret menu/Stat menu
                case ConsoleKey.D0:
                    if (isSecret)
                    {
                        menuSelection = 3;
                    }
                    else
                    {
                        goto menu;
                    }
                    break;
                //Market
                case ConsoleKey.D1:
                    menuSelection = 2;
                    break;
                //SuperMarket
                case ConsoleKey.D2:
                    menuSelection = 4;
                    break;
                //SlotMachine
                case ConsoleKey.D3:
                    menuSelection = 5;
                    break;
                //Cheat / debug
                case ConsoleKey.Add:
                    bars += 10000;
                    goto menu;
                default:
                    goto menu;
            }
            //Bars
            while (menuSelection == 1)
            {
                Console.Clear();
                Console.WriteLine("Press the arrows shown below, to earn Bars.\nPress ESC to go back to the menu.\n");
                sideMain = 1;
                side = false;
            bars:
                Console.WriteLine("~{0:n2}/{1:n2} Bars", bars, barsLimit);
                if (side == false && barsLimit > bars)
                {
                    //PressedDown
                    Console.WriteLine("Press \u2191 +{0}\n", powerx);
                    if (sideMain == 1 || pressedDefault)
                    {
                        //Bars 1/6 MAIN
                        Console.WriteLine("           \n           \n    _._    \n   / O \\   \n   \\| |/   \nO--+=-=+--O");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        sideMain = 0;
                        foo += 1;
                    }
                    else if (sideMain == 0 && pressedDown)
                    {
                        realClicks++;
                        //Bars 5/6
                        Console.WriteLine("           \nO--=-O-=--O\n    '-'    \n     v     \n    / )     \n    ~ z    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
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
                        sideMain = 0;
                        pressedDown = false;
                        foo += 1;
                        if (foo > 2)
                        {
                            sideMain = 1;
                            foo = 0;
                            goto bars;
                        }
                    }
                }
                else if (side && barsLimit > bars)
                {
                    Console.WriteLine("Press \u2193 +{0}\n", powerx);
                    if (sideMain == 0 && pressedUp)
                    {
                        realClicks++;
                        //Bars 2/6
                        Console.WriteLine("           \n           \n            \n   ,-O-,   \nO--=---=--O\n    2\"2    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
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
                        sideMain = 0;
                        pressedUp = false;
                        pressedDefault = false;
                        foo -= 1;
                    }
                    else if (sideMain == 0 || pressedDefault)
                    {
                        //Bars 6/6
                        Console.WriteLine("O--,---,--O\n   \\ O /   \n    - -     \n     -     \n    / \\    \n   =   =   ");
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        sideMain = 0;
                        foo -= 1;
                    }
                }
                //Amount ot clear after hitting the Bar cap.
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
                        goto menu;
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
                        pressedDefault = true;
                        sideMain = 1;
                        goto bars;
                }
            }
            //Market
            while (menuSelection == 2)
            {
            store:
                Console.Clear();
                Console.WriteLine("~~Welcome to the store~~\nYou have about ~{0:n2} bars.\nESC to menu\nEnter a number to buy\n", bars);
                Console.WriteLine("1.\tIncreases the amount of Bars you gain\n\tYour current multiplier: {2}\n\tYou have bought {1}/10 of this\n\t~{0:n2} Bars\n", price1F, countPowerX, powerx);
                Console.WriteLine("2.\tGives you access to your overall stats\n\t~{0:n2} Bars {1}\n", price2F, boughtIt1);
                Console.WriteLine("3.\tIncreases you maximum Bars limit\n\tYour current Bar limit: {0:n2}\n\tYou have bought {2}/50 of this\n\t~{1:n2} Bars\n", barsLimit, price3F, countBarsLimit);
                Console.WriteLine("4.\tDecrease the time that it takes to gain Bars\n\tYour current action time: {0}ms\n\tYou have bought {1}/25 of this\n\t~{2:n2} Bars\n", actionTiming, countActionTime, price4F);
                press = Console.ReadKey(true).Key;
                switch (press)
                {
                    //Power upgrade
                    case ConsoleKey.D1:
                        if (bars >= price1F && countPowerX < 10)
                        {
                            countPowerX++;
                            bars = bars - price1F;
                            price1F = price1F * 1.21f;
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
                        if (bars >= price2F && isSecret == false)
                        {
                            Console.Clear();
                            isSecret = true;
                            bars = bars - price2F;
                            price2F = 0;
                            boughtIt1 = ", You have bought it already";
                            Console.WriteLine("You have just bought a secret.\n~{0:n2} Bars remaining.\n\nESC to go back.", bars);
                            Console.ReadKey();
                            goto store;
                        }
                        else if (isSecret)
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
                        if (bars >= price3F && countBarsLimit < 50)
                        {
                            countBarsLimit++;
                            bars = bars - price3F;
                            price3F = price3F * 1.25f;
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
                        if (bars >= price4F && countActionTime < 25)
                        {
                            countActionTime++;
                            bars = bars - price4F;
                            price4F = price4F * 1.10f;
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
            
            while (menuSelection == 4)
            {
                Console.Clear();
                Console.WriteLine("Supermarket is still WIP(Work in Progress)");
                Console.ReadKey();
                goto menu;
            }

            while (menuSelection == 5)
            {
                //temp setup, bound to change
                const string seven = "7", oneBar = "−", twoBars = "=", threeBars = "≡", diamond = "₿", cherry = "₪", dupe = "□";
                Random rng = new Random();
                Console.Clear();
                Console.WriteLine("Welcome to the Slot Machine!\n");
                Console.WriteLine("Testing {0} {1} {2} {3} {4} {5} {6}", seven, oneBar, twoBars, threeBars, diamond, cherry, dupe);
                Console.ReadKey();
                int slotMachineCounterRng = rng.Next(5, 10);
                for (int slotMachineIndex = 0; slotMachineIndex < slotMachineCounterRng; slotMachineIndex++)
                {

                    int slotMachineMainRng = rng.Next(1, 72);
                    //for (int slotMachineLength = 0; slotMachineLength < 3; slotMachineLength++)
                    //Dupes >□< filled
                    if ((slotMachineMainRng >= 1 && slotMachineMainRng <= 3) || 
                        (slotMachineMainRng >= 5 && slotMachineMainRng <= 9) || 
                        (slotMachineMainRng >= 13 && slotMachineMainRng <= 19) ||
                        (slotMachineMainRng >= 22 && slotMachineMainRng <= 26) ||
                        (slotMachineMainRng >= 28 && slotMachineMainRng <= 32) ||
                        (slotMachineMainRng >= 36 && slotMachineMainRng <= 39) ||
                        (slotMachineMainRng >= 41 && slotMachineMainRng <= 42) ||
                        (slotMachineMainRng >= 44 && slotMachineMainRng <= 51) ||
                        (slotMachineMainRng >= 55 && slotMachineMainRng <= 59) ||
                        (slotMachineMainRng >= 61 && slotMachineMainRng <= 65) ||
                        (slotMachineMainRng >= 68 && slotMachineMainRng <= 70))
                    {
                        Console.WriteLine("dupe");
                        Console.ReadKey();
                    }
                    //Sevens >7< filled
                    else if (slotMachineMainRng == 4 || slotMachineMainRng == 43)
                    {
                        Console.WriteLine("sevens");
                        Console.ReadKey();
                    }
                    //One Bar >−< filled
                    else if ((slotMachineMainRng >= 10 && slotMachineMainRng <= 12) ||
                             (slotMachineMainRng >= 33 && slotMachineMainRng <= 35) ||
                             (slotMachineMainRng >= 52 && slotMachineMainRng <= 54) ||
                             (slotMachineMainRng >= 71 && slotMachineMainRng <= 72))
                    {
                        Console.WriteLine("one bar");
                        Console.ReadKey();
                    }
                    //Two Bar >=< filled
                    else if ((slotMachineMainRng >= 66 && slotMachineMainRng <= 67))
                    {
                        Console.WriteLine("two bar");
                        Console.ReadKey();
                    }
                    //Three Bar >≡< filled
                    else if (slotMachineMainRng == 40)
                    {
                        Console.WriteLine("three bar");
                        Console.ReadKey();
                    }
                    //Cherry >₪< filled
                    else if ((slotMachineMainRng >= 20 && slotMachineMainRng <= 21))
                    {
                        Console.WriteLine("cherry");
                        Console.ReadKey();
                    }
                    //Diamond >₿<
                    else if (slotMachineMainRng == 27 || slotMachineMainRng == 60)
                    {
                        Console.WriteLine("diamond");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}