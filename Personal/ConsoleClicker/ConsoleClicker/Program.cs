using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace ConsoleClicker
{
    class Program
    {
        static string SlotMachine(int slotMachineMainRng)
        {
            const string seven = "7",
                oneBar = "−",
                twoBars = "=",
                threeBars = "≡",
                diamond = "◊",
                cherry = "₪",
                jackPot = "₿",
                wild = "¥";
            //Jackpot
            //One Bar >−< filled
            //25%
            if (slotMachineMainRng >= 0 && slotMachineMainRng <= 25)
            {
                return oneBar;
            }
            //Two Bar >=< filled
            //21%
            if (slotMachineMainRng >= 26 && slotMachineMainRng <= 47)
            {
                return twoBars;
            }
            //Three Bar >≡< filled
            //17%
            if (slotMachineMainRng >= 47 && slotMachineMainRng <= 64)
            {
                return threeBars;
            }
            //Cherry >₪< filled
            //14%
            if (slotMachineMainRng >= 65 && slotMachineMainRng <= 79)
            {
                return cherry;
            }
            //Sevens >7< filled
            //9%
            if (slotMachineMainRng >= 80 && slotMachineMainRng <= 89)
            {
                return seven;
            }
            //Diamond >₿<
            //6%
            if (slotMachineMainRng >= 90 && slotMachineMainRng <= 96)
            {
                return diamond;
            }
            //jackpot
            //3%
            if (slotMachineMainRng >= 97 && slotMachineMainRng <= 100)
            {
                return jackPot;
            }
            //WILD
            //20%
            if (slotMachineMainRng >= 101 && slotMachineMainRng <= 121)
            {
                return wild;
            }
            return null;
        }

        static string slotMachineDisplay(string slotMachineSlots1, string slotMachineSlots2, string slotMachineSlots3)
        {
            string slotFirst = "|" + slotMachineSlots1 + " ¦ " + slotMachineSlots2 + " ¦ " + slotMachineSlots3 + "|";
            return slotFirst;
        }

        static void ClearCurrentConsoleLine()
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
            float barsLimit = 50f, price1F = 50f, price2F = 100f, price3F = 10f, bars = 0f, totalBars = 0f, price4F = 20f, totalTokens = 0;
            bool isSecret = false, side, pressedDown = false, pressedUp = false, pressedDefault = false;
            string boughtIt1 = null;
            Console.TreatControlCAsInput = true;
            Console.Title = "Console Clicker, Made by Renekris";
            Console.WriteLine("Welcome to Console Clicker - WIP\n" +
                              "Unfortunately there are a couple of bugs present with the animation\n" +
                              "\nProgramming by Renekris/Rene Kristofer Pohlak\n" +
                              "Big thanks to: Gio, Juškin, for giving me ideas to work with\n\n\n" +
                              "\u0020\u263a\u0020\u252c\u2510\u0020\u0020\u0020\u2591\u2591\u2591\u2591\u000a\u002f\u007c\u2514\u2524\u0020\u0020\u2593\u2593\u2593\u2593\u2593\u2593\u2593\u000a\u002f\u0020\u005c\u0020\u0020\u2592\u2592\u2592\u2593\u2593\u2593\u2593\u2592\u2592");
            Console.ReadKey();
        menu:
            Console.Clear();
            Console.WriteLine("Welcome to Console Clicker~~\n\n" +
                              "This is a game made by Renekris,\n" +
                              "To start playing, you must press the ([\u2191] / [\u2193]) arrow keys.\n" +
                              "With Bars you can buy different upgrades to earn Bars quicker.\n");
            Console.WriteLine("Press the arrows to collect Bars\n" +
                              "[\u2191] / [\u2193]\n");
            if (isSecret)
            {
                Console.WriteLine("This is where your overall statistics go\n" +
                                  "[0] - Statistics Menu\n");
            }
            Console.WriteLine("Market is for normal upgrades\n" +
                              "[1] - Market\n");
            Console.WriteLine("Supermarket is for super upgrades\n" +
                              "[2] - SuperMarket\n");
            Console.WriteLine("Slot Machine is for testing your luck\n" +
                              "[3] - Slot Machine\n");
            Console.WriteLine("This is a link to my Github,\n" +
                              "if you want to keep up with the progress of the development\n" +
                              "[G] - Project's Github (github.com/renekris/CSharp)");
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
                Console.WriteLine("Press the arrows shown below, to earn Bars.\n" +
                                  "[ESC] to go back to the menu.\n");
                sideMain = 1;
                side = false;
            bars:
                Console.WriteLine("~[{0:n2}]/[{1:n2}] Bars", bars, barsLimit);
                if (side == false && barsLimit > bars)
                {
                    //PressedDown
                    Console.WriteLine("Press [\u2191] +{0}\n", powerx);
                    if (sideMain == 1 || pressedDefault)
                    {
                        //Bars 1/6 MAIN
                        Console.WriteLine("           \n" +
                                          "           \n" +
                                          "    _._    \n" +
                                          "   / O \\   \n" +
                                          "   \\| |/   \n" +
                                          "O--+=-=+--O");
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
                        Console.WriteLine("           \n" +
                                          "O--=-O-=--O\n" +
                                          "    '-'    \n" +
                                          "     v     \n" +
                                          "    / )     \n" +
                                          "    ~ z    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 4/6
                        Console.WriteLine("           \n" +
                                          "   ._O_.   \n" +
                                          "O--<-+->--O\n" +
                                          "     X     \n" +
                                          "    / \\    \n" +
                                          "    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 3/6
                        Console.WriteLine("           \n" +
                                          "           \n" +
                                          "   ,_O_,   \n" +
                                          "O--(---)--O\n" +
                                          "    >'>     \n" +
                                          "    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 2/6
                        Console.WriteLine("           \n" +
                                          "           \n" +
                                          "           \n" +
                                          "   ,-O-,    \n" +
                                          "O--=---=--O\n" +
                                          "    2\"2   ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 1/6
                        Console.WriteLine("           \n" +
                                          "           \n" +
                                          "    _._    \n" +
                                          "   / O \\   \n" +
                                          "   \\| |/   \n" +
                                          "O--+=-=+--O");
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
                    Console.WriteLine("Press [\u2193] +{0}\n", powerx);
                    if (sideMain == 0 && pressedUp)
                    {
                        realClicks++;
                        //Bars 2/6
                        Console.WriteLine("           \n" +
                                          "           \n" +
                                          "            \n" +
                                          "   ,-O-,   \n" +
                                          "O--=---=--O\n" +
                                          "    2\"2    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 3/6
                        Console.WriteLine("           \n" +
                                          "           \n" +
                                          "   ,_O_,    \n" +
                                          "O--(---)--O\n" +
                                          "    >'>     \n" +
                                          "    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 4/6
                        Console.WriteLine("           \n" +
                                          "   ._O_.   \n" +
                                          "O--<-+->--O\n" +
                                          "     X     \n" +
                                          "    / \\    \n" +
                                          "    - -    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 5/6
                        Console.WriteLine("           \n" +
                                          "O--=-O-=--O\n" +
                                          "    '-'     \n" +
                                          "     v     \n" +
                                          "    / )     \n" +
                                          "    ~ z    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 6);
                        Thread.Sleep(actionTiming);
                        ClearCurrentConsoleLine();
                        //Bars 6/6
                        Console.WriteLine("O--,---,--O\n" +
                                          "   \\ O /   \n" +
                                          "    - -     \n" +
                                          "     -     \n" +
                                          "    / \\    \n" +
                                          "   =   =   ");
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
                        Console.WriteLine("O--,---,--O\n" +
                                          "   \\ O /   \n" +
                                          "    - -     \n" +
                                          "     -     \n" +
                                          "    / \\    \n" +
                                          "   =   =   ");
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
                        {
                            goto bars;
                        }
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
                Console.WriteLine("~~Welcome to the store~~\n" +
                                  "You have about ~{0:n2} bars.\n" +
                                  "[ESC] to menu\n" +
                                  "Enter a number to buy\n", bars);
                Console.WriteLine("[1]\tIncreases the amount of Bars you gain\n" +
                                  "\tYour current multiplier: {2}\n" +
                                  "\tYou have bought {1}/10 of this\n" +
                                  "\t~{0:n2} Bars\n", price1F, countPowerX, powerx);
                Console.WriteLine("[2]\tGives you access to your overall stats\n" +
                                  "\t~{0:n2} Bars {1}\n", price2F, boughtIt1);
                Console.WriteLine("[3]\tIncreases you maximum Bars limit\n" +
                                  "\tYour current Bar limit: {0:n2}\n" +
                                  "\tYou have bought {2}/50 of this\n" +
                                  "\t~{1:n2} Bars\n", barsLimit, price3F, countBarsLimit);
                Console.WriteLine("[4]\tDecrease the time that it takes to gain Bars\n" +
                                  "\tYour current action time: {0}ms\n" +
                                  "\tYou have bought {1}/25 of this\n" +
                                  "\t~{2:n2} Bars\n", actionTiming, countActionTime, price4F);
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
                            Console.WriteLine("You have just bought += 1x power.\n" +
                                              "~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                            Console.WriteLine("You have just bought a secret.\n" +
                                              "~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                            Console.WriteLine("You have just increased your Bars limit.\n" +
                                              "~{0:n2} Bars remaining.\n\nESC to go back.", bars);
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
                            Console.WriteLine("You have just increased your action time.\n" +
                                              "~{0:n2} Bars remaining.\n\n" +
                                              "ESC to go back.", bars);
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
                int rollTotalCounter = 0;
                bool slotSomeBug = false;
                Random rng = new Random();
                const string oneBar = "−",
                    twoBars = "=",
                    threeBars = "≡",
                    cherry = "₪",
                    seven = "7",
                    diamond = "◊",
                    jackPot = "₿",
                    wild = "¥";
                string
                    slotMachineSlotsTop1 = null,
                    slotMachineSlotsTop2 = null,
                    slotMachineSlotsTop3 = null,
                    slotMachineSlotsMain1 = null,
                    slotMachineSlotsMain2 = null,
                    slotMachineSlotsMain3 = null,
                    slotMachineSlotsBottom1 = null,
                    slotMachineSlotsBottom2 = null,
                    slotMachineSlotsBottom3 = null,
                    slotAnimation1 = "|× ¦ × ¦ ×|",
                    slotAnimation2 = "|× ¦ × ¦ ×|",
                    slotAnimation3 = "|× ¦ × ¦ ×|";
                string[] barStrings = { oneBar, twoBars, threeBars };
                float slotMachineBet = 0f, receivedTokens = 0f, slotProfit = 0f;
                slotMenu:
                //Asks for the bet
                Console.Clear();
                Console.WriteLine("Welcome to the Slot Machine!\n[ESC] to leave");
                Console.WriteLine("Testing {0} {1} {2} {3} {4} {5} {6}, this is where the values go\n", oneBar, twoBars, threeBars, cherry, seven, diamond, jackPot);
                Console.WriteLine("Start the Slot Machine\n" +
                                  "[1] / [ENTER] Start the slot\n\n" +
                                  "You can bet on the Slot Machine\n" +
                                  "[2] / [INSERT] Insert a bet, current bet: {0}", slotMachineBet);

                #region Switch Case
                press = Console.ReadKey(true).Key;
                switch (press)
                {
                    //Bet changing
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                    case ConsoleKey.Enter:
                        menuSelection = 2;
                        break;
                    //Start the slot
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.Insert:
                    case ConsoleKey.D1:
                        menuSelection = 1;
                        break;
                    case ConsoleKey.Escape:
                        goto menu;
                    default:
                        goto slotMenu;
                }
                #endregion
                if (menuSelection == 1 || slotMachineBet <= 0f)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the bet:");
                    if (slotSomeBug)
                    {
                        Console.ReadLine();
                    }
                    var slotTryParse = float.TryParse(Console.ReadLine(), out float betResult);
                    if (slotTryParse)
                    {
                        slotSomeBug = true;
                        slotMachineBet = betResult;
                    }
                    goto slotMenu;
                }
                //RNG and getting the symbols
                if (menuSelection == 2)
                {
                    slotMachineRoll:
                    rollTotalCounter++;
                    string slotDisplay1, slotDisplay2, slotDisplay3;
                    Console.Clear();
                    Console.WriteLine("Welcome to the Slot Machine!\n");
                    Console.WriteLine("Testing {0} {1} {2} {3} {4} {5} {6}\n\n", oneBar, twoBars, threeBars, cherry, seven, diamond, jackPot);
                    int slotMachineRollAmount = rng.Next(20, 50);
                    //Animation
                    Console.WriteLine("\n   .-------.");
                    Console.WriteLine("[/{-JACKPOT-}\\]");
                    Console.WriteLine(".=============.    ");
                    Console.WriteLine("| {0} | __", slotAnimation1);
                    Console.WriteLine("|>{0}<|( ⸗)", slotAnimation2);
                    Console.WriteLine("| {0} | ||", slotAnimation3);
                    Console.WriteLine("|˻┌─────────┐˼|_||");
                    Console.WriteLine("| ´‾‾‾‾‾‾‾‾‾` |--'");
                    Console.WriteLine("| xxx ::::::: |");
                    Console.WriteLine("| ooo ::::::: |");
                    Console.WriteLine("| $$$ ::::::: |");
                    Console.WriteLine("|      __ === |");
                    Console.WriteLine("|_____/__\\____|");
                    Thread.Sleep(500);
                    Console.SetCursorPosition(23, Console.CursorTop - 14);
                    ClearCurrentConsoleLine();
                    for (int slotMachineIndex = 0; slotMachineIndex < slotMachineRollAmount; slotMachineIndex++)
                    {
                        //Rng
                        int slotMachineMainRng = rng.Next(0, 100);

                        //slotDisplay1
                        slotMachineSlotsTop1 = SlotMachine(slotMachineMainRng);
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsTop2 = SlotMachine(slotMachineMainRng);
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsTop3 = SlotMachine(slotMachineMainRng);
                        slotDisplay1 = slotMachineDisplay(slotMachineSlotsTop1, slotMachineSlotsTop2, slotMachineSlotsTop3);
                        //slotDisplay2 MAIN
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsMain1 = SlotMachine(slotMachineMainRng);
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsMain2 = SlotMachine(slotMachineMainRng);
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsMain3 = SlotMachine(slotMachineMainRng);
                        slotDisplay2 = slotMachineDisplay(slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                        //slotDispaly3
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsBottom1 = SlotMachine(slotMachineMainRng);
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsBottom2 = SlotMachine(slotMachineMainRng);
                        slotMachineMainRng = rng.Next(0, 100);
                        slotMachineSlotsBottom3 = SlotMachine(slotMachineMainRng);
                        slotDisplay3 = slotMachineDisplay(slotMachineSlotsBottom1, slotMachineSlotsBottom2, slotMachineSlotsBottom3);
                        //Slot Display is 1 char long
                        Console.WriteLine("\n   .-------.");
                        Console.WriteLine("[/{-JACKPOT-}\\]");
                        Console.WriteLine(".=============. __");
                        Console.WriteLine("| {0} |( ⸗)", slotDisplay1);
                        Console.WriteLine("|>{0}<| || ", slotDisplay2);
                        Console.WriteLine("| {0} | || ", slotDisplay3);
                        Console.WriteLine("|˻┌─────────┐˼|_||");
                        Console.WriteLine("| ´‾‾‾‾‾‾‾‾‾` |--'");
                        Console.WriteLine("| xxx ::::::: |");
                        Console.WriteLine("| ooo ::::::: |");
                        Console.WriteLine("| $$$ ::::::: |");
                        Console.WriteLine("|      __ === |");
                        Console.WriteLine("|_____/__\\____|");
                        Thread.Sleep(50);
                        //Slot Machine is 13 + 1 char in height
                        Console.SetCursorPosition(0, Console.CursorTop - 14);
                        ClearCurrentConsoleLine();
                    }
                    slotAnimation1 = "|" + slotMachineSlotsTop1 + " ¦ " + slotMachineSlotsTop2 + " ¦ " + slotMachineSlotsTop3 + "|";
                    slotAnimation2 = "|" + slotMachineSlotsMain1 + " ¦ " + slotMachineSlotsMain2 + " ¦ " + slotMachineSlotsMain3 + "|";
                    slotAnimation3 = "|" + slotMachineSlotsBottom1 + " ¦ " + slotMachineSlotsBottom2 + " ¦ " + slotMachineSlotsBottom3 + "|";
                    //If statements for prizes/rewards
                    #region Rewards
                    /*
                    wild = "¥" 1f
                    oneBar = "−" 1f
                    twoBars = "=" 2f
                    threeBars = "≡" 4f
                    cherry = "₪" 10f
                    seven = "7" 25f
                    diamond = "◊" 50f
                    jackPot = "₿" 100f
                    */
                    ////////////////////////////
                    //use this as the formula = 'receivedTokens' += 'slotMachineBet' * 2.33... = (3 / (oneBarMult + twoBarMult + threeBarMult))
                    const float oneBarMult = 1f,
                        twoBarMult = 2f,
                        threeBarMult = 4f,
                        cherryMult = 10f,
                        sevenMult = 25f,
                        diamondMult = 50f,
                        jackPotMult = 100f,
                        wildMult = 1f;
                    ////////////////////////////
                    if (barStrings.Contains(slotMachineSlotsMain1) && barStrings.Contains(slotMachineSlotsMain2) && barStrings.Contains(slotMachineSlotsMain3))
                    {
                        receivedTokens = slotMachineBet * 0.50f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only one bars
                    if (slotMachineSlotsMain1 == oneBar && slotMachineSlotsMain2 == oneBar && slotMachineSlotsMain3 == oneBar)
                    {
                        receivedTokens = slotMachineBet * 1f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only two bars
                    if (slotMachineSlotsMain1 == twoBars && slotMachineSlotsMain2 == twoBars && slotMachineSlotsMain3 == twoBars)
                    {
                        receivedTokens = slotMachineBet * 2f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only three bars
                    if (slotMachineSlotsMain1 == threeBars && slotMachineSlotsMain2 == threeBars && slotMachineSlotsMain3 == threeBars)
                    {
                        receivedTokens = slotMachineBet * 4f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only cherries
                    if (slotMachineSlotsMain1 == cherry && slotMachineSlotsMain2 == cherry && slotMachineSlotsMain3 == cherry)
                    {
                        receivedTokens = slotMachineBet * 10f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only sevens
                    if (slotMachineSlotsMain1 == seven && slotMachineSlotsMain2 == seven && slotMachineSlotsMain3 == seven)
                    {
                        receivedTokens = slotMachineBet * 25f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only diamonds
                    if (slotMachineSlotsMain1 == diamond && slotMachineSlotsMain2 == diamond && slotMachineSlotsMain3 == diamond)
                    {
                        receivedTokens = slotMachineBet * 50f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only jackPots
                    if (slotMachineSlotsMain1 == jackPot && slotMachineSlotsMain2 == jackPot && slotMachineSlotsMain3 == jackPot)
                    {
                        receivedTokens = slotMachineBet * 100f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    //Only wild
                    if (slotMachineSlotsMain1 == wild && slotMachineSlotsMain2 == wild && slotMachineSlotsMain3 == wild)
                    {
                        receivedTokens = slotMachineBet * 1f;
                        bars += receivedTokens;
                        Console.SetCursorPosition(21, 10);
                        Console.WriteLine("You got {0} | {1} | {2}", slotMachineSlotsMain1, slotMachineSlotsMain2, slotMachineSlotsMain3);
                    }
                    #endregion
                    if (receivedTokens > 0f)
                    {
                        Console.SetCursorPosition(21, 11);
                        Console.WriteLine("= {0:F1} Tokens~", receivedTokens);
                        totalTokens += receivedTokens;
                    }
                    slotProfit += (receivedTokens - slotMachineBet);
                    receivedTokens = 0f;
                    Console.SetCursorPosition(21, 14);
                    Console.WriteLine("Total Profit: {0:F1} | Total Rolls: {1:F0}", slotProfit, rollTotalCounter);
                    Console.SetCursorPosition(21, 15);
                    Console.WriteLine("Current bet: {0}", slotMachineBet);
                    Console.SetCursorPosition(21, 16);
                    Console.WriteLine("[1] / [ENTER] to run again.");
                    Console.SetCursorPosition(21, 17);
                    Console.WriteLine("[ESC] / [BACKSPACE] to go back");
                    press = Console.ReadKey(true).Key;
                    switch (press)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                        case ConsoleKey.Enter:
                            goto slotMachineRoll;
                        case ConsoleKey.Backspace:
                        case ConsoleKey.Escape:
                            goto slotMenu;
                            default:
                                goto slotMenu;
                    }
                }
            }
        }
    }
}