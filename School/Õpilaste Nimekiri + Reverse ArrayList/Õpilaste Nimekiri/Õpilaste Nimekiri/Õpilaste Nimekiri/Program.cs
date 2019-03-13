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
            StudentAmount(studentsList.Count);
            

            int studentAmount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
