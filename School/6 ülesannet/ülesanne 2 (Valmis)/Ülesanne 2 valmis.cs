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
                List<int> kontroll = new List<int>();
            int hinne, temp = 0;
            Console.WriteLine("Sisesta õpilaste kontroltöö tulemused");
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Õpilase tulemus: ");
                int tulemus = int.Parse(Console.ReadLine());
                kontroll.Add(tulemus);
                temp += tulemus;
                if (tulemus >= 91 && tulemus <= 100)
                {
                    Console.WriteLine("Suurepärane!");
                }
                if (tulemus >= 81 && tulemus <= 90)
                {
                    Console.WriteLine("Väga hea!");
                }
                if (tulemus >= 71 && tulemus <= 80)
                {
                    Console.WriteLine("Hea!");
                }
                if (tulemus >= 61 && tulemus <= 70)
                {
                    Console.WriteLine("Rahuldav!");
                }
                if (tulemus >= 51 && tulemus <= 60)
                {
                    Console.WriteLine("Läbitud!");
                }
                if (tulemus >= 0 && tulemus <= 50)
                {
                    Console.WriteLine("Kukkusid läbi!");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Protsentide summa kokku:");
            Console.WriteLine(temp);
            temp = temp / 15;
            Console.WriteLine("Keskmine protsent: ");
            Console.WriteLine(temp);
            Console.WriteLine("Suurem saadud tulemus: ");
            int max = kontroll.Max();
            Console.WriteLine(max);
            Console.WriteLine("Väiksem saadud tulemus: ");
            int min = kontroll.Min();
            Console.WriteLine(min);
            Console.ReadKey();




        }
    }
}


