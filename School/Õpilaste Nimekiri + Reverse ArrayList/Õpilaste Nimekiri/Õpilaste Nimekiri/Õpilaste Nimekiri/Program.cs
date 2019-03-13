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

        static void ViewStudents(List<string> student, List<string> grade)
        {
            Console.Clear();
            StudentAmount(student.Count);
            Console.WriteLine("Sinu klassis on õpilased nimega:\n");
            for (int i = 0; i < student.Count; i++)
            {
                Console.WriteLine("Õpilane: {0}", student[i]);
                if (grade.Count > 0)
                {
                Console.WriteLine("Hinne: {0}\n", grade[i]);    
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }

        static void AddStudents(ref List<string> student)
        {
            Console.Clear();
            StudentAmount(student.Count);
            Console.WriteLine("Mitu õpilast sa sisestada tahad?");
            int enteredNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < enteredNumber; i++)
            {
                Console.WriteLine("Sisesta {0}. õpilase nimi {1}/{2}", student.Count + 1, i + 1, enteredNumber);
                student.Add(Console.ReadLine());
            }
            Console.Clear();
            if (enteredNumber > 1)
            {
                Console.WriteLine("Sinu õpilaste studente list on nüüd:\n");
            }
            else
            {
                Console.WriteLine("Sinu õpilaste studente list on nüüd:\n");
            }
            foreach (string VARIABLE in student)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadKey();
        }

        static void InsertNumbers(ref List<string> grade, List<string> student)
        {
            grade.Clear();
            foreach (var VARIABLE in student)
            {
                string hinne = " "; 
                Console.Clear();
                Console.WriteLine("Õpilane: {0}", VARIABLE);
                Console.Write("Hind: \n");

                Console.WriteLine("[0] = P | [1] = X | [2] = 2 | [3] = 3 | [4] = 4 | [5] = 5");
                ConsoleKey press = Console.ReadKey(false).Key;
                switch (press)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        hinne = "P";
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        hinne = "X";
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        hinne = "2";
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        hinne = "3";
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        hinne = "4";
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        hinne = "5";
                        break;
                    default:
                        hinne = " ";
                        break;

                }
                grade.Add(hinne);
            }
            Console.Clear();
            for (int i = 0; i < student.Count; i++)
            {
                Console.WriteLine("Õpilane: {0}", student[i]);
                Console.WriteLine("Hind: {0}\n", grade[i]);
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
            List<string> gradesList = new List<string>();
            studentsList.Add("Juku");
            studentsList.Add("Madis");
            studentsList.Add("Joonas");
            studentsList.Add("Kohuke");
            studentsList.Add("Alfa USB Network Adapter 2.4GHz Wifi, RT3070 chip (Monitoring + packet injection)");
        start:
            Console.Clear();
            StudentAmount(studentsList.Count);

            Console.WriteLine("[1] Vaata õpilasi / hindeid\n" +
                              "[2] Lisa õpilasi\n" +
                              "[3] Sisesta hindeid / puudumised\n" +
                              "[4] Otsi õpilasi");
            ConsoleKey press = Console.ReadKey(false).Key;
            switch (press)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ViewStudents(studentsList, gradesList);
                    goto start;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    AddStudents(ref studentsList);
                    goto start;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    InsertNumbers(ref gradesList, studentsList);
                    goto start;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    goto start;
                default:
                    goto start;
            }
        }
    }
}
