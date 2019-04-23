using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Riidelapp
{
    /*
     * kodutöö - Loo programm, kus on eraldi klass riidelapi andmete hoidmiseks: pikkus, laius, toon Klassis peab olema käsklus lapi andmete väljatrükiks,
     * käsklus lapi pindala arvutamiseks, meetod (alamprogramm) lapi poolitamiseks: pikem külg tehakse poole lühemaks.
     * Lisaks peab poolitamise meetod algse lapi poolitamisele väljastama ka uue samasuguse algsest poole väiksema eksemplari.
     * Peab olema teine poolitusmeetod, kus saab määrata, mitme protsendi peale lõigatakse pikem külg.
     * Peaprogrammis saab kasutaja sisestada andmed ning lõpuks väljastatakse tulemused. Lisaks täiendada tunnis loodud ülesannet niimoodi,
     * et kasutaja saaks lisada ise andmeid Listi.
     */
    class Program : LapiAndmed
    {
        static void Main(string[] args)
        {
            //Programm on kirjutatud Rene Kristofer Pohlaku ja Sander Juškini poolt.
            while (true)
            {
                float pikkus, laius;
                string toon;
                Console.WriteLine("Sisestage pikkus");
                float.TryParse(Console.ReadLine(), out pikkus);

                Console.WriteLine("Sisestage laius");
                float.TryParse(Console.ReadLine(), out laius);

                Console.WriteLine("Sisestage toon");
                toon = Console.ReadLine();

                Console.WriteLine("Kas te tahate valikulist poolitamist: [Y]/[N].");
                string temp = "";
                bool y = false;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        y = true;
                        Console.Clear();
                        Console.WriteLine("Sisesta protsent arv millega poolitaks");
                        if (float.TryParse(Console.ReadLine(), out float f))
                        {
                            Console.Clear();
                            if (f >= 100)
                                temp = ValikulinePoolitamine(pikkus, laius, 100);
                            else if (f <= 0)
                                temp = ValikulinePoolitamine(pikkus, laius, 0);
                            else
                                temp = ValikulinePoolitamine(pikkus, laius, f);
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
                Console.WriteLine("Pikkus: {0} | Laius: {1} | Toon: {2} \n", pikkus, laius, toon);
                Console.WriteLine("Moondatud arvud:");
                Console.WriteLine(Pindala(pikkus, laius));
                if (y)
                    Console.WriteLine("\nPeale poolitamist:\n" + temp);
                else
                    Console.WriteLine("\nPeale poolitamist: \n" + Poolitamine(pikkus, laius));
                Console.ReadKey();
                y = false;
            }
        }
    }

    class LapiAndmed
    {
        internal static string Pindala(float pikkus, float laius)
        {
            //Lapi pindala arvutamine
            return "Lapi pindala: " + pikkus * laius;
        }
        internal static string Poolitamine(float pikkus, float laius)
        {
            string temp;
            //Lapi poolitamine
            if (pikkus > laius)
                temp = "Uus Pikkus: " + pikkus / 2 + "| Laius: " + laius;
            else
                temp = "Pikkus: " + pikkus + "| Uus Laius: " + laius / 2;
            return temp;
        }
        internal static string ValikulinePoolitamine(float pikkus, float laius, float f)
        {
            string temp;
            //Lapi poolitamine kasutaja sisestusega
            if (pikkus > laius)
                temp = "Uus Pikkus: " + (pikkus - (pikkus * (f / 100f))) + " | Laius: " + laius;
            else
                temp = "Pikkus on " + pikkus + " | Uus Laius:" + (laius - (laius * (f / 100f)));
            return temp;
        }
    }
}
