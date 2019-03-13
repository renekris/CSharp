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

        static void ViewStudents(List<string> nimed)
        {
            Console.Clear();
            StudentAmount(nimed.Count);
            Console.WriteLine("Sinu klassis on õpilased nimega:\n");
            foreach (string VARIABLE in nimed)
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadKey();
        }

        static void AddStudents(ref List<string> nimed)
        {
            Console.Clear();
            StudentAmount(nimed.Count);
            Console.WriteLine("Mitu õpilast sa sisestada tahad?");
            int enteredNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < enteredNumber; i++)
            {
                Console.WriteLine("Sisesta {0}. õpilase nimi {1}/{2}", nimed.Count + 1, i + 1, enteredNumber);
                nimed.Add(Console.ReadLine());
            }
            Console.Clear();
            if (enteredNumber > 1)
            {
                Console.WriteLine("Sinu õpilaste nimede list on nüüd:\n");
            }
            else
            {
                Console.WriteLine("Sinu õpilaste nimede list on nüüd:\n");
            }
            foreach (string VARIABLE in nimed)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadKey();
        }

        static void InsertNumbers(ref List<char> grade, List<string> student)
        {
            foreach (var VARIABLE in student)
            {
                Console.Clear();
                Console.WriteLine("Õpilane: {0}", VARIABLE);
                Console.Write("Hind: \n");
                grade.Add(char.Parse(Console.ReadLine()));
            }
            Console.Clear();
            for (int i = 0; i < student.Count; i++)
            {
                Console.WriteLine("Hind: {0}", grade[i]);
                Console.WriteLine("Õpilane: {0}\n", student[i]);
                Console.WriteLine();
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
            Console.OutputEncoding = Encoding.Unicode;
            List<string> studentsList = new List<string>();
            List<char> gradesList = new List<char>();
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
                    InsertNumbers(ref gradesList, studentsList);
                    goto start;
                default:
                    goto start;
            }
        }
    }
}
