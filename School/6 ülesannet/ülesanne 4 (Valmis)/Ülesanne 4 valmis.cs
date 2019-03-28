using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Sisesta number: ");
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    Console.WriteLine("On paaris arv");
                }
                else
                {
                    Console.WriteLine("On paaritu arv");
                }
                if (number >= 0)
                {
                    Console.WriteLine("Tegu on positiivse arvuga");
                }
                else
                {
                    Console.WriteLine("Tegu on negatiivse arvuga");
                }
                if (IsPrime(number))
                {
                    Console.WriteLine("Tegu on algarvulise arvuga!");
                }
                else
                {
                    Console.WriteLine("Tegu ei ole algarvulise arvuga!");
                }
                Console.WriteLine("Kui kaugele korrutustabelis sa sooviksid minna 12 kohta on kõige kaugem kaugus!", number);
                int userValue_length = int.Parse(Console.ReadLine());
                int n = number;
                int i = 1;
                while (n <= (number * userValue_length))
                {
                    Console.WriteLine("{0} x {1} = {2}", i, number, n);
                    n = n + number;
                    i++;
                }
                Console.ReadKey();
                Console.Clear();

            }
        }
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;
            return true;
        }
    }
}



