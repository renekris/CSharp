using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balekoth
{
    internal class Oftenlib
    {
        public static void WindowBuffer(int height, int width)
        {
            Console.BufferWidth = Console.WindowWidth = width;
            Console.BufferHeight = Console.WindowHeight = height;
        }
        public static void MiddleWriteLine(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }
        public static void MiddleWrite(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.Write(s);
        }
        public static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ════════════════════════════════════════════════════════════════════════════════════════════════════\n");
            Console.WriteLine("  ▀█████████▄     ▄████████  ▄█          ▄████████    ▄█   ▄█▄  ▄██████▄      ███        ▄█    █▄   ");
            Console.WriteLine("    ███    ███   ███    ███ ███         ███    ███   ███ ▄███▀ ███    ███ ▀█████████▄   ███    ███  ");
            Console.WriteLine("    ███    ███   ███    ███ ███         ███    █▀    ███▐██▀   ███    ███    ▀███▀▀██   ███    ███  ");
            Console.WriteLine("   ▄███▄▄▄██▀    ███    ███ ███        ▄███▄▄▄      ▄█████▀    ███    ███     ███   ▀  ▄███▄▄▄▄███▄▄");
            Console.WriteLine("  ▀▀███▀▀▀██▄  ▀███████████ ███       ▀▀███▀▀▀     ▀▀█████▄    ███    ███     ███     ▀▀███▀▀▀▀███▀ ");
            Console.WriteLine("    ███    ██▄   ███    ███ ███         ███    █▄    ███▐██▄   ███    ███     ███       ███    ███  ");
            Console.WriteLine("    ███    ███   ███    ███ ███▌    ▄   ███    ███   ███ ▀███▄ ███    ███     ███       ███    ███  ");
            Console.WriteLine("  ▄█████████▀    ███    █▀  █████▄▄██   ██████████   ███   ▀█▀  ▀██████▀     ▄████▀     ███    █▀   ");
            Console.WriteLine("                            ▀                        ▀                                              ");
            Console.WriteLine(" ════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            MiddleWriteLine("By");
            MiddleWrite("Rene Kristofer Pohlak");
            Console.ResetColor();
        }

        public static void MiniTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            MiddleWriteLine("────────────────────────────");
            MiddleWriteLine("| ╔╗ ╔═╗╦  ╔═╗╦╔═╔═╗╔╦╗╦ ╦ |");
            MiddleWriteLine("~| ╠╩╗╠═╣║  ║╣ ╠╩╗║ ║ ║ ╠═╣ |~");
            MiddleWriteLine("| ╚═╝╩ ╩╩═╝╚═╝╩ ╩╚═╝ ╩ ╩ ╩ |");
            MiddleWriteLine("────────────────────────────");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
