using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Õpilaste_Nimekiri
{
    class Program
    {
        static void StudentAmount(int amount)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Sinu klassis on {0} õpilast\n", amount);
            Console.ResetColor();
        }

        static void ViewStudents(List<string> nimi)
        {
            Console.Clear();
            Console.WriteLine("\nSinu klassis on õpilased nimega:");
            foreach (string VARIABLE in nimi)
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadKey();
        }

        static void AddStudents(ref List<string> nimed)
        {
            Console.Clear();
            Console.WriteLine("Mitu õpilast sa sisestada tahad?");
            int enteredNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < enteredNumber; i++)
            {
                Console.WriteLine("Sisesta {0}. õpilase nimi", nimed.Count + 1);
                nimed.Add(Console.ReadLine());
            }
            Console.Clear();
            if (enteredNumber > 1)
            {
                Console.WriteLine("Sa sisestasid {0} õpilast\nSinu õpilaste nimede list on nüüd:\n", enteredNumber);
            }
            else
            {
                Console.WriteLine("Sa sisestasid {0} õpilase\nSinu õpilaste nimede list on nüüd:\n", enteredNumber);
            }
            foreach (string VARIABLE in nimed)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            /* 1~~
             * Õpilaste arvu ei ole antud, õpetaja ise otsustab.
             * Loo programm, kus õpetaja saab salvestada nimekirja õpilaste nimed, hinded ja puudumised.
             * Lisaks on tal võimalik nimekirjast otsida õpilast nime järgi ning siis näha tema hindeid ja puudumisi
             * Võimalik kuvada kogu õpilaste nimekiri tulemustega.
             *
             * 2~~
             * Küsi kasutajalt arve, kuni ta sisestab nulli.
             * Salvesta ArrayListi.
             * Väljasta need arvud tagurpidises järjekorras.
             */
            List<string> studentsList = new List<string>();
            studentsList.Add("Juku");
            studentsList.Add("Madis");
            studentsList.Add("Joonas");
            studentsList.Add("Kohuke");
            studentsList.Add("Alfa USB Network Adapter 2.4GHz Wifi, RT3070 chip (Monitoring + packet injection)");
        start:
            Console.Clear();
            StudentAmount(studentsList.Count);

            Console.WriteLine("1. Vaata õpilasi\n" +
                              "2. Lisa õpilasi\n" +
                              "3. Sisesta hindeid + puudumised\n");
            ConsoleKey press = Console.ReadKey(false).Key;
            switch (press)
            {
                case ConsoleKey.D1:
                    ViewStudents(studentsList);
                    goto start;
                case ConsoleKey.D2:
                    AddStudents(ref studentsList);
                    goto start;
                case ConsoleKey.D3:

                    goto start;
            }
            int studentAmount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
