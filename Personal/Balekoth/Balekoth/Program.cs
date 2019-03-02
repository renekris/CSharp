using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balekoth
{
    class Program
    {
        static void SetCursorMiddle(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }
        static void Title()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            SetCursorMiddle("══════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();
            SetCursorMiddle("▀█████████▄     ▄████████  ▄█          ▄████████    ▄█   ▄█▄  ▄██████▄      ███        ▄█    █▄   ");
            SetCursorMiddle("  ███    ███   ███    ███ ███         ███    ███   ███ ▄███▀ ███    ███ ▀█████████▄   ███    ███  ");
            SetCursorMiddle("  ███    ███   ███    ███ ███         ███    █▀    ███▐██▀   ███    ███    ▀███▀▀██   ███    ███  ");
            SetCursorMiddle(" ▄███▄▄▄██▀    ███    ███ ███        ▄███▄▄▄      ▄█████▀    ███    ███     ███   ▀  ▄███▄▄▄▄███▄▄");
            SetCursorMiddle("▀▀███▀▀▀██▄  ▀███████████ ███       ▀▀███▀▀▀     ▀▀█████▄    ███    ███     ███     ▀▀███▀▀▀▀███▀ ");
            SetCursorMiddle("  ███    ██▄   ███    ███ ███         ███    █▄    ███▐██▄   ███    ███     ███       ███    ███  ");
            SetCursorMiddle("  ███    ███   ███    ███ ███▌    ▄   ███    ███   ███ ▀███▄ ███    ███     ███       ███    ███  ");
            SetCursorMiddle("▄█████████▀    ███    █▀  █████▄▄██   ██████████   ███   ▀█▀  ▀██████▀     ▄████▀     ███    █▀   ");
            SetCursorMiddle("                          ▀                        ▀                                              ");
            SetCursorMiddle("══════════════════════════════════════════════════════════════════════════════════════════════════");
            SetCursorMiddle("~Written by Rene Kristofer Pohlak~");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            //Title
            Title();


            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
