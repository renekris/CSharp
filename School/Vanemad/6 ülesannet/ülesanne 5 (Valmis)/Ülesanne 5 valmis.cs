using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            float intress;
            Console.WriteLine("Sisesta mida investeerida (eurode kogus).");
            float number = int.Parse(Console.ReadLine());
            double algneInvesteering = number;
            double temp;
            float intressiMäär = 5;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\nAasta: {0}", i + 1);
                intress = (number * intressiMäär) / 100;
                number = intress + number;
                Console.WriteLine("{0:N2}", number);
            }
            temp = algneInvesteering * Math.Pow(1 + intressiMäär, 10);
            Console.WriteLine(temp);
            Console.ReadKey();
        }
    }
}
