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
        static void SetCursorMiddle(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }
        static string SlotMachine(int slotMachineMainRng)
        {
            const string seven = "7",
                oneBar = "−",
                twoBars = "=",
                threeBars = "≡",
                diamond = "◊",
                cherry = "₪",
                jackPot = "₿";
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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Title = "Console Clicker, Made by Renekris";
            Console.WriteLine("  ▄████▄   ▒█████   ███▄    █   ██████  ▒█████   ██▓    ▓█████       \r\n▒██▀ ▀█  ▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ ▒██▒  ██▒▓██▒    ▓█   ▀       \r\n▒▓█    ▄ ▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   ▒██░  ██▒▒██░    ▒███         \r\n▒▓▓▄ ▄██▒▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒▒██   ██░▒██░    ▒▓█  ▄       \r\n▒ ▓███▀ ░░ ████▓▒░▒██░   ▓██░▒██████▒▒░ ████▓▒░░██████▒░▒████▒      \r\n░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░░ ▒░▒░▒░ ░ ▒░▓  ░░░ ▒░ ░      \r\n  ░  ▒     ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░  ░ ▒ ▒░ ░ ░ ▒  ░ ░ ░  ░      \r\n░        ░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  ░ ░ ░ ▒    ░ ░      ░         \r\n░ ░          ░ ░           ░       ░      ░ ░      ░  ░   ░  ░      \r\n░               ▄████▄   ██▓     ██▓ ▄████▄   ██ ▄█▀▓█████  ██▀███  \r\n               ▒██▀ ▀█  ▓██▒    ▓██▒▒██▀ ▀█   ██▄█▒ ▓█   ▀ ▓██ ▒ ██▒\r\n               ▒▓█    ▄ ▒██░    ▒██▒▒▓█    ▄ ▓███▄░ ▒███   ▓██ ░▄█ ▒\r\n               ▒▓▓▄ ▄██▒▒██░    ░██░▒▓▓▄ ▄██▒▓██ █▄ ▒▓█  ▄ ▒██▀▀█▄  \r\n               ▒ ▓███▀ ░░██████▒░██░▒ ▓███▀ ░▒██▒ █▄░▒████▒░██▓ ▒██▒\r\n               ░ ░▒ ▒  ░░ ▒░▓  ░░▓  ░ ░▒ ▒  ░▒ ▒▒ ▓▒░░ ▒░ ░░ ▒▓ ░▒▓░\r\n                 ░  ▒   ░ ░ ▒  ░ ▒ ░  ░  ▒   ░ ░▒ ▒░ ░ ░  ░  ░▒ ░ ▒░\r\n               ░          ░ ░    ▒ ░░        ░ ░░ ░    ░     ░░   ░ \r\n               ░ ░          ░  ░ ░  ░ ░      ░  ░      ░  ░   ░     \r\n               ░                    ░                               ");
            Console.ResetColor();
            Console.WriteLine("\nProgramming by Renekris / Rene Kristofer Pohlak.\n");
            Console.WriteLine("Big thanks to: Gio, Juškin, for giving me ideas to work with!");

            Console.ReadKey();
        menu:
            Console.Clear();
            Console.WriteLine("Welcome to Console Clicker~\n\n" +
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
                        {
                            goto bars;
                        }
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
                Random rng = new Random();
                const string oneBar = "−",
                    twoBars = "=",
                    threeBars = "≡",
                    cherry = "₪",
                    seven = "7",
                    diamond = "◊",
                    jackPot = "₿";
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
                    slotAnimation3 = "|× ¦ × ¦ ×|",
                    slotRewards1 = null, slotRewards2 = null, slotRewards3 = null;
                float slotMachineBet = 0f,
                    receivedTokens,
                    slotProfit = 0f;
            slotMenu:
            float betResult;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                SetCursorMiddle("╔═╗╦  ╔═╗╔╦╗╔═╗  ╔╦╗╔═╗╔═╗╦ ╦╦╔╗╔╔═╗");
                SetCursorMiddle("╚═╗║  ║ ║ ║ ╚═╗  ║║║╠═╣║  ╠═╣║║║║║╣ ");
                SetCursorMiddle("╚═╝╩═╝╚═╝ ╩ ╚═╝  ╩ ╩╩ ╩╚═╝╩ ╩╩╝╚╝╚═╝");
                Console.ResetColor();
                SetCursorMiddle("[ESC] to leave");
                Console.WriteLine("\n");
                SetCursorMiddle("Start the Slot Machine");
                SetCursorMiddle("[1] / [ENTER] Start the slot");
                Console.WriteLine("\n");
                SetCursorMiddle("You can bet on the Slot Machine");
                SetCursorMiddle("[2] / [INSERT] Insert a bet");
                #region Switch Case
                press = Console.ReadKey(true).Key;
                switch (press)
                {
                    //Bet changing
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                    case ConsoleKey.Insert:
                        menuSelection = 1;
                        break;
                    //Start the slot
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                    case ConsoleKey.Enter:
                        menuSelection = 2;
                        break;
                    case ConsoleKey.Escape:
                        goto menu;
                    default:
                        goto slotMenu;
                }
                #endregion
                if (menuSelection == 1 || slotMachineBet <= 0f)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        SetCursorMiddle("╔═╗╦  ╔═╗╔╦╗╔═╗  ╔╦╗╔═╗╔═╗╦ ╦╦╔╗╔╔═╗");
                        SetCursorMiddle("╚═╗║  ║ ║ ║ ╚═╗  ║║║╠═╣║  ╠═╣║║║║║╣ ");
                        SetCursorMiddle("╚═╝╩═╝╚═╝ ╩ ╚═╝  ╩ ╩╩ ╩╚═╝╩ ╩╩╝╚╝╚═╝");
                        Console.ResetColor();
                        Console.WriteLine("");
                        SetCursorMiddle("Enter the bet:");
                        Console.SetCursorPosition(68, 4);
                        float.TryParse(Console.ReadLine(), out betResult);
                        slotMachineBet = betResult;
                        goto slotMenu;
                    }
                }
                //RNG and getting the symbols
                if (menuSelection == 2)
                {
                    float slotRewardsAmount1 = 0f, slotRewardsAmount2 = 0f, slotRewardsAmount3 = 0f;
                    slotMachineRoll:
                    rollTotalCounter++;
                    bars -= slotMachineBet;
                    string slotDisplay1, slotDisplay2, slotDisplay3;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    SetCursorMiddle("╔═╗╦  ╔═╗╔╦╗╔═╗  ╔╦╗╔═╗╔═╗╦ ╦╦╔╗╔╔═╗");
                    SetCursorMiddle("╚═╗║  ║ ║ ║ ╚═╗  ║║║╠═╣║  ╠═╣║║║║║╣ ");
                    SetCursorMiddle("╚═╝╩═╝╚═╝ ╩ ╚═╝  ╩ ╩╩ ╩╚═╝╩ ╩╩╝╚╝╚═╝");
                    Console.ResetColor();
                    SetCursorMiddle("Winning Table");
                    SetCursorMiddle("- = 1|= = 2");
                    SetCursorMiddle("≡ = 4|₪ = 7");
                    SetCursorMiddle("7 = 15|◊ = 25");
                    SetCursorMiddle("₿ = 50");
                    SetCursorMiddle("^JACK^POT^");
                    int slotMachineRollAmount = rng.Next(20, 50);
                    //Animation
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("                 _          __\r\n          ,-----' |   _   <'__`)\r\n          | //  : | -'     )o \\\\\r\n          | //  : |  ---   \\__;`\r\n          | //  : | -._      |\\`\\\r\n          `-----._|     __  // ( \\|\r\n           _/___\\_    //)_`//  | ||]\r\n     _____[_______]_[~~-_ (.L_/  ||\r\n    [____________________]' `\\_,/'/\r\n      ||| /          |||  ,___,'./\r\n      ||| \\          |||,'______|\r\n      ||| /          /|| I==||\r\n      ||| \\       __/_||  __||__\r\n  -----||-/------`-._/||-o--o---o---\r\n    ~~~~~'");
                    Console.SetCursorPosition(52, 9);
                    SetCursorMiddle("");
                    SetCursorMiddle(".-------.");
                    SetCursorMiddle("[/{-JACKPOT-}\\]");
                    SetCursorMiddle(".=============.");
                    Console.SetCursorPosition(52, 13);
                    Console.WriteLine("| {0} | __", slotAnimation1);
                    Console.SetCursorPosition(52, 14);
                    Console.WriteLine("|>{0}<|( ⸗)", slotAnimation2);
                    Console.SetCursorPosition(52, 15);
                    Console.WriteLine("| {0} | ||", slotAnimation3);
                    Console.SetCursorPosition(52, 16);
                    Console.WriteLine("|˻┌─────────┐˼|_||");
                    Console.SetCursorPosition(52, 17);
                    Console.WriteLine("| ´‾‾‾‾‾‾‾‾‾` |--'");
                    SetCursorMiddle("| xxx ::::::: |");
                    SetCursorMiddle("| ooo ::::::: |");
                    SetCursorMiddle("| $$$ ::::::: |");
                    SetCursorMiddle("|      __ === |");
                    SetCursorMiddle("|_____/__\\____|");
                    Thread.Sleep(500);
                    Console.SetCursorPosition(23, Console.CursorTop - 14);
                    ClearCurrentConsoleLine();
                    for (int slotMachineIndex = 0; slotMachineIndex < slotMachineRollAmount; slotMachineIndex++)
                    {
                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine("                 _          __\r\n          ,-----' |   _   <'__`)\r\n          | //  : | -'     )o \\\\\r\n          | //  : |  ---   \\__;`\r\n          | //  : | -._      |\\`\\\r\n          `-----._|     __  // ( \\|\r\n           _/___\\_    //)_`//  | ||]\r\n     _____[_______]_[~~-_ (.L_/  ||\r\n    [____________________]' `\\_,/'/\r\n      ||| /          |||  ,___,'./\r\n      ||| \\          |||,'______|\r\n      ||| /          /|| I==||\r\n      ||| \\       __/_||  __||__\r\n  -----||-/------`-._/||-o--o---o---\r\n    ~~~~~'");
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
                        Console.SetCursorPosition(52, 9);
                        SetCursorMiddle("");
                        SetCursorMiddle(".-------.");
                        SetCursorMiddle("[/{-JACKPOT-}\\]");
                        SetCursorMiddle(".=============.");
                        Console.SetCursorPosition(52, 13);
                        Console.WriteLine("| {0} |( ⸗)", slotDisplay1);
                        Console.SetCursorPosition(52, 14);
                        Console.WriteLine("|>{0}<| || ", slotDisplay2);
                        Console.SetCursorPosition(52, 15);
                        Console.WriteLine("| {0} | || ", slotDisplay3);
                        Console.SetCursorPosition(52, 16);
                        Console.WriteLine("|˻┌─────────┐˼|_||");
                        Console.SetCursorPosition(52, 17);
                        Console.WriteLine("| ´‾‾‾‾‾‾‾‾‾` |--'");
                        SetCursorMiddle("| xxx ::::::: |");
                        SetCursorMiddle("| ooo ::::::: |");
                        SetCursorMiddle("| $$$ ::::::: |");
                        SetCursorMiddle("|      __ === |");
                        SetCursorMiddle("|_____/__\\____|");
                        Thread.Sleep(50);
                        //Slot Machine is 13 + 1 char in height
                        Console.SetCursorPosition(0, Console.CursorTop - 14);
                        ClearCurrentConsoleLine();
                    }
                    slotAnimation1 = "|" + slotMachineSlotsTop1 + " ¦ " + slotMachineSlotsTop2 + " ¦ " + slotMachineSlotsTop3 + "|";
                    slotAnimation2 = "|" + slotMachineSlotsMain1 + " ¦ " + slotMachineSlotsMain2 + " ¦ " + slotMachineSlotsMain3 + "|";
                    slotAnimation3 = "|" + slotMachineSlotsBottom1 + " ¦ " + slotMachineSlotsBottom2 + " ¦ " + slotMachineSlotsBottom3 + "|";
                    const float oneBarMult = 1f,
                        twoBarMult = 2f,
                        threeBarMult = 4f,
                        cherryMult = 7f,
                        sevenMult = 15f,
                        diamondMult = 25f,
                        jackPotMult = 50f;
                    //If statements for prizes/rewards
                    #region Rewards
                    switch (slotMachineSlotsMain1)
                    {
                        case oneBar:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = oneBarMult;
                            break;
                        case twoBars:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = twoBarMult;
                            break;
                        case threeBars:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = threeBarMult;
                            break;
                        case cherry:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = cherryMult;
                            break;
                        case seven:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = sevenMult;
                            break;
                        case diamond:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = diamondMult;
                            break;
                        case jackPot:
                            slotRewards1 = slotMachineSlotsMain1;
                            slotRewardsAmount1 = jackPotMult;
                            break;
                    }
                    switch (slotMachineSlotsMain2)
                    {
                        case oneBar:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = oneBarMult;
                            break;
                        case twoBars:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = twoBarMult;
                            break;
                        case threeBars:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = threeBarMult;
                            break;
                        case cherry:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = cherryMult;
                            break;
                        case seven:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = sevenMult;
                            break;
                        case diamond:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = diamondMult;
                            break;
                        case jackPot:
                            slotRewards2 = slotMachineSlotsMain2;
                            slotRewardsAmount2 = jackPotMult;
                            break;
                    }
                    switch (slotMachineSlotsMain3)
                    {
                        case oneBar:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = oneBarMult;
                            break;
                        case twoBars:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = twoBarMult;
                            break;
                        case threeBars:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = threeBarMult;
                            break;
                        case cherry:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = cherryMult;
                            break;
                        case seven:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = sevenMult;
                            break;
                        case diamond:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = diamondMult;
                            break;
                        case jackPot:
                            slotRewards3 = slotMachineSlotsMain3;
                            slotRewardsAmount3 = jackPotMult;
                            break;
                    }
                    //Main calculation of rewards
                    if ((slotMachineSlotsMain1 == slotMachineSlotsMain2) && (slotMachineSlotsMain2 == slotMachineSlotsMain3) && (slotMachineSlotsMain1 == slotMachineSlotsMain3))
                    {
                        receivedTokens = ((slotRewardsAmount1 + slotRewardsAmount2 + slotRewardsAmount3) * slotMachineBet) / 5;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("                               )\r\n                         )   __    (\r\n                        __  (~(    __\r\n                       (~(   \\O\\   )~)\r\n                        )O)   )_) (O(\r\n                       (_(__ (     )_) )\r\n                          )~)__      __\r\n                         /O/ )~)  ) (~(\r\n                        (_( (O(  __  \\O\\\r\n                          )  )_)(~(   \\_\\\r\n                         __      )O)   (  \r\n                 _      (~(   __(_(    __ \r\n          ,-----' |    _ \\O\\<'~_`)   ) )~)\r\n          | //  : |  -'   )_))^ \\\\  __(O( \r\n          | //  : |   ---    >__;` (~( )_)\r\n          | //  : |  -._     /\\_\\   \\O\\ \r\n          `-----._|     __  /__( \\|  )_)\r\n           _/___\\_    //)_`/( (| ||]\r\n     _____[_______]_[~~-_ (.L)O) ||\r\n    [____________________]' (_(,/(~(\r\n      ||| /          )~)  ,___,'./\\O\\\r\n      ||| \\         (O(|,'______|( )_)\r\n      ||| /          )_) I==||  __\r\n      ||| \\       __/_||  __||__)~)\r\n  -----||-/------`-._/||-o-_o__(O(--  __\r\n    ~~~~~'   ____     __  /_O_/.\\_\\   \\~\\\r\n             \\_O_\\   /~/__/_/O`.o.     \\O\\\r\n             ____   /O/_\\_O/_/  `.'     \\_\\\r\n            /_O_/  /_/\\_O_\\");
                    }
                    else
                    {
                        receivedTokens = ((slotRewardsAmount1 + slotRewardsAmount2 + slotRewardsAmount3) * slotMachineBet) / 24;
                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine("                 _          __\r\n          ,-----' |   _   <'__`)\r\n          | //  : | -'     )o \\\\\r\n          | //  : |  ---   \\__;`\r\n          | //  : | -._      |\\`\\\r\n          `-----._|     __  // ( \\|\r\n           _/___\\_    //)_`//  | ||]\r\n     _____[_______]_[~~-_ (.L_/  ||\r\n    [____________________]' `\\_,/'/\r\n      ||| /          |||  ,___,'./\r\n      ||| \\          |||,'______|\r\n      ||| /          /|| I==||\r\n      ||| \\       __/_||  __||__\r\n  -----||-/------`-._/||-o--o---o---\r\n    ~~~~~'");
                    }
                    bars += receivedTokens;
                    Console.SetCursorPosition(73, 14);
                    Console.WriteLine("You got {0} | {1} | {2}", slotRewards1, slotRewards2, slotRewards3);
                    #endregion
                    if (receivedTokens > 0f)
                    {
                        Console.SetCursorPosition(73, 15);
                        Console.WriteLine("= {0:n1} Tokens~", receivedTokens);
                        totalTokens += receivedTokens;
                    }
                    slotProfit += (receivedTokens - slotMachineBet);
                    Console.SetCursorPosition(73, 17);
                    Console.WriteLine("Total Profit: {0:n1} | Total Rolls: {1:F0}", slotProfit, rollTotalCounter);
                    Console.SetCursorPosition(73, 18);
                    Console.WriteLine("Current bet: {0:n0}", slotMachineBet);
                    Console.SetCursorPosition(73, 19);
                    Console.WriteLine("[1] / [ENTER] to run again.");
                    Console.SetCursorPosition(73, 20);
                    Console.WriteLine("[ESC] / [BACKSPACE] to go back");
                    Thread.Sleep(750);
                    press = Console.ReadKey(false).Key;
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
                                goto slotMachineRoll;
                    }
                }
            }
        }
    }
}