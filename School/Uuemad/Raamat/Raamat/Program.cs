using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Raamat
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
            getTiitel:
                Console.Write("Sisesta Raamatu Nimi:");
                string tiitel = Console.ReadLine();

                if (tiitel.Length <= 3)
                {
                    Console.WriteLine("Tiitel ei kehti");
                    goto getTiitel;
                }

            getAutor:
                Console.Write("Sisesta Raamatu Autor:");
                string autor = Console.ReadLine();

                if (Regex.IsMatch(autor, @"^\d+"))
                {
                    Console.WriteLine("Autor ei kehti");
                    goto getAutor;
                }

            getHind:
                decimal hind;
                do
                {
                    Console.Write("Sisesta Raamatu Hind:");
                } while (!decimal.TryParse(Console.ReadLine(), out hind));

                if (hind <= 0)
                {
                    Console.WriteLine("Hind ei kehti");
                    goto getHind;
                }

                Console.Clear();
                Raamat Data = new Raamat(tiitel, autor, hind);
                Raamat.ToList(Data.Tiitel, Data.Autor, Data.Hind);
                for (int i = 0; i < Raamat.TiitelList.Count; i++)
                {
                    Raamat.RaamatPrint(i);
                    Console.WriteLine();
                    Esmatrükk.EsmatrükkPrint(i);
                    Console.WriteLine();
                }

                Console.ReadKey();
            }
        }
    }

    public class Raamat
    {
        public Raamat(string tiitel, string autor, decimal hind) //Määrab nime, aadressi ja jootraha mis võtab sisestatud valuedest
        {
            Tiitel = tiitel;
            Autor = autor;
            Hind = hind;
        }

        private static string tiitel;
        private static string autor;
        private static decimal hind;

        public static List<string> TiitelList = new List<string>();
        public static List<string> AutorList = new List<string>();
        public static List<decimal> HindList = new List<decimal>();

        public static void ToList(string tiitel, string autor, decimal hind)
        {
            TiitelList.Add(tiitel);
            AutorList.Add(autor);
            HindList.Add(hind);
        }

        public string Tiitel
        {
            get { return tiitel; }
            set
            {
                tiitel = value;
            }
        }

        public string Autor
        {
            get { return autor; }
            set
            {
                autor = value;
            }
        }

        public decimal Hind
        {
            get { return hind; }
            set
            {
                hind = value;
            }
        }
        public static void RaamatPrint(int i)
        {
            Console.WriteLine("Tavaline Raamat:");
            Console.WriteLine(" " + TiitelList[i]);
            Console.WriteLine(" " + AutorList[i]);
            Console.WriteLine(" " + string.Format("{0:N1}", HindList[i]));
        }
    }


    class Esmatrükk
    {
        public static void EsmatrükkPrint(int i)
        {
            Console.WriteLine("Esmatrukki Raamat:");
            Console.WriteLine(" " + Raamat.TiitelList[i]);
            Console.WriteLine(" " + Raamat.AutorList[i]);
            Console.WriteLine(" " + string.Format("{0:N1}", Raamat.HindList[i] * 1.30m));
        }
    }
}
