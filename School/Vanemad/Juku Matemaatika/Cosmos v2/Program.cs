
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Cosmos_v2
{
    class Program
    {
        //
        //Arvutused
        //
        static int RngMain1(int temp1, int temp2)
        {
            int temp;
            temp = temp1 + temp2;
            return temp;
        }
        static int RngMain2(int temp1, int temp2)
        {
            int temp;
            temp = temp1 - temp2;
            return temp;
        }
        static int RngMain3(int temp1, int temp2)
        {
            int temp;
            temp = temp1 * temp2;
            return temp;
        }
        static float RngMain4(float tempf1, float tempf2)
        {
            float temp;
            temp = tempf1 / tempf2;
            return temp;
        }

        static void Repeat1()
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Sa oled lõpetanud 15 keerulist ülesannet!\n\nKas sa tahad veel ülesandeid teha?");
        }

        static int Repeat()
        {
            Random rng = new Random();
            Console.Clear();
            int rng1 = rng.Next(1, 15);
            return rng1;
        }

        static int Repeat2()
        {
            Random rng = new Random();
            Console.Clear();
            int rng1 = rng.Next(1, 100);
            return rng1;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random rng = new Random();
            Console.Title = "Jukule toredad ülesanded. -Rene Kristofer Pohlak";
            Console.ForegroundColor = ConsoleColor.Green;
            int valik = 0, count = 1, rng1, result, temp1, level, temp;
            string hmm;
        //
        //MENU
        //

        Start:
            Console.WriteLine("Juku, vali level.\n\nLevel 1 - liitmine\nLevel 2 - lahutamine\nLevel 3 - korrutamine\nLevel 4 - jagamine\n");
            level = int.Parse(Console.ReadLine());
            switch (level)
            {
                case 1:
                    valik = 1;
                    break;
                case 2:
                    valik = 2;
                    break;
                case 3:
                    valik = 3;
                    break;
                case 4:
                    valik = 4;
                    break;
                default:
                    Console.WriteLine("Valik on vale, vali 1-4");
                    goto Start;
            }
            //
            //LIITMINE
            //
            if (valik == 1)
            {
                Console.Clear();
                Console.WriteLine("Valisid level 1: liitmine");
                Console.ReadKey();
            //
            //Kerge
            //
            L1:
                Console.Clear();
                temp = Repeat();
                temp1 = Repeat();
                Console.WriteLine(">{0} + {1} =__", temp, temp1);
                result = int.Parse(Console.ReadLine());
                if (result == Program.RngMain1(temp, temp1))
                {
                    Console.WriteLine("Õige vastus! {0}/5", count++);
                    if (count <= 5)
                    {
                        Console.ReadKey();
                        goto L1;
                    }
                    else
                    {
                        count = 0;
                        Console.Clear();
                    }
                }
                //debug
                else if (result == 1337)
                {
                    count = 10;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0}", Program.RngMain1(temp, temp1));
                    Console.ReadKey();
                    goto L1;
                }
                //
                //Raske
                //
                Console.WriteLine("Siin on raskemad ülesanded, ettevaatust!");
                Console.ReadKey();
            L2:
                Console.Clear();
                temp = Repeat2();
                temp1 = Repeat2();
                Console.WriteLine(">{0} + {1} =__", temp, temp1);
                result = int.Parse(Console.ReadLine());
                if (result == Program.RngMain1(temp, temp1))
                {
                    Console.WriteLine("Õige vastus! {0}/10", count++);
                    if (count <= 10)
                    {
                        Console.ReadKey();
                        goto L2;
                    }
                    else
                    {
                        Repeat1();
                        hmm = Console.ReadLine();
                        if (hmm == "jah" || hmm == "Jah" || hmm == "JAH" || hmm == "y" || hmm == "Y")
                        {
                            Console.Clear();
                            goto Start;
                        }
                        Console.WriteLine("Oled olnud tubli õpilane!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0}", Program.RngMain1(temp, temp1));
                    Console.ReadKey();
                    goto L2;
                }

            }
            //
            //LAHUTAMINE
            //
            if (valik == 2)
            {
                Console.Clear();
                Console.WriteLine("Valisid level 2: lahutamine");
                Console.ReadKey();
            //
            //Kerge
            //
            L3:
                Console.Clear();
                temp = Repeat();
                temp1 = Repeat();
                Console.WriteLine(">{0} - {1} =__", temp, temp1);
                result = int.Parse(Console.ReadLine());
                if (result == Program.RngMain2(temp, temp1))
                {
                    Console.WriteLine("Õige vastus! {0}/5", count++);
                    if (count <= 5)
                    {
                        Console.ReadKey();
                        goto L3;
                    }
                    else
                    {
                        count = 0;
                        Console.Clear();
                    }
                }
                //debug
                else if (result == 1337)
                {
                    count = 10;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0}", Program.RngMain2(temp, temp1));
                    Console.ReadKey();
                    goto L3;
                }
                //
                //Raske
                //
                Console.WriteLine("Siin on raskemad ülesanded, ettevaatust!");
                Console.ReadKey();
            L4:
                Console.Clear();
                temp = Repeat2();
                temp1 = Repeat2();
                Console.WriteLine(">{0} - {1} =__", temp, temp1);
                result = int.Parse(Console.ReadLine());
                if (result == Program.RngMain2(temp, temp1))
                {
                    Console.WriteLine("Õige vastus! {0}/10", count++);
                    if (count <= 10)
                    {
                        Console.ReadKey();
                        goto L4;
                    }
                    else
                    {
                        Repeat1();
                        hmm = Console.ReadLine();
                        if (hmm == "jah" || hmm == "Jah" || hmm == "JAH" || hmm == "y" || hmm == "Y")
                        {
                            Console.Clear();
                            goto Start;
                        }
                        Console.WriteLine("Oled olnud tubli õpilane!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0}", Program.RngMain2(temp, temp1));
                    Console.ReadKey();
                    goto L4;
                }
            }
            //
            //KORRUTAMINE
            //
            if (valik == 3)
            {
                Console.Clear();
                Console.WriteLine("Valisid level 3: korrutamine");
                Console.ReadKey();
            //
            //Kerge
            //
            L6:
                Console.Clear();
                temp = Repeat();
                temp1 = Repeat();
                Console.WriteLine(">{0} * {1} =__", temp, temp1);
                result = int.Parse(Console.ReadLine());
                if (result == Program.RngMain3(temp, temp1))
                {
                    Console.WriteLine("Õige vastus! {0}/5", count++);
                    if (count <= 5)
                    {
                        Console.ReadKey();
                        goto L6;
                    }
                    else
                    {
                        count = 0;
                        Console.Clear();
                    }
                }
                //debug
                else if (result == 1337)
                {
                    count = 10;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0}", Program.RngMain3(temp, temp1));
                    Console.ReadKey();
                    goto L6;
                }
                //
                //Raske
                //
                Console.WriteLine("Siin on raskemad ülesanded, ettevaatust!");
                Console.ReadKey();
            L7:
                Console.Clear();
                temp = Repeat2();
                temp1 = Repeat2();
                Console.WriteLine(">{0} * {1} =__", temp, temp1);
                result = int.Parse(Console.ReadLine());
                if (result == Program.RngMain3(temp, temp1))
                {
                    Console.WriteLine("Õige vastus! {0}/10", count++);
                    if (count <= 10)
                    {
                        Console.ReadKey();
                        goto L7;
                    }
                    else
                    {
                        Repeat1();
                        hmm = Console.ReadLine();
                        if (hmm == "jah" || hmm == "Jah" || hmm == "JAH" || hmm == "y" || hmm == "Y")
                        {
                            Console.Clear();
                            goto Start;
                        }
                        Console.WriteLine("Oled olnud tubli õpilane!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0}", Program.RngMain3(temp, temp1));
                    Console.ReadKey();
                    goto L7;
                }
            }

            if (valik == 4)
            //
            //JAGAMINE
            //
            {
                Console.Clear();
                Console.WriteLine("Valisid level 4: jagamine \n# / #.# / #.## formaadis");
                Console.ReadKey();
            //
            //Kerge
            //
            L8:
                Console.Clear();
                rng1 = rng.Next(1, 15);
                float tempf1 = rng1;
                rng1 = rng.Next(1, 15);
                float tempf2 = rng1;
                Console.WriteLine(">{0} / {1} =_._", tempf1, tempf2);
                string results = Console.ReadLine();
                float tempf3 = Program.RngMain4(tempf1, tempf2);
                string tempf4 = tempf3.ToString("0.00");
                string tempf5 = tempf3.ToString("0.0");
                string tempf6 = tempf3.ToString("0");
                if (results == tempf4 || results == tempf5 || results == tempf6)
                {
                    Console.WriteLine("Õige vastus! {0}/5", count++);
                    if (count <= 5)
                    {
                        Console.ReadKey();
                        goto L8;
                    }
                    else
                    {
                        count = 0;
                        Console.Clear();
                    }
                }
                //debug
                else if (results == "1337")
                {
                    count = 10;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0:n1}", Program.RngMain4(tempf1, tempf2));
                    Console.ReadKey();
                    goto L8;

                }
                //
                //Raske
                //
                Console.WriteLine("Siin on raskemad ülesanded, ettevaatust!");
                Console.ReadKey();
            L9:
                Console.Clear();
                rng1 = rng.Next(1, 100);
                tempf1 = rng1;
                rng1 = rng.Next(1, 100);
                tempf2 = rng1;
                Console.WriteLine(">{0} / {1} =_._", tempf1, tempf2);
                results = Console.ReadLine();
                tempf3 = Program.RngMain4(tempf1, tempf2);
                tempf4 = tempf3.ToString("0.00");
                tempf5 = tempf3.ToString("0.0");
                tempf6 = tempf3.ToString("0");
                if (results == tempf4 || results == tempf5 || results == tempf6)
                {
                    Console.WriteLine("Õige vastus! {0}/10", count++);
                    if (count <= 10)
                    {
                        Console.ReadKey();
                        goto L9;
                    }
                    else
                    {
                        Repeat1();
                        hmm = Console.ReadLine();
                        if (hmm == "Ok" || hmm == "ok" || hmm == "jah" || hmm == "Jah" || hmm == "JAH" || hmm == "y" || hmm == "Y")
                        {
                            Console.Clear();
                            goto Start;
                        }
                        Console.WriteLine("Oled olnud tubli õpilane!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Oi Oi, proovi uuesti!\n\nÕige vastus oleks olnud {0:n1}", Program.RngMain4(tempf1, tempf2));
                    Console.ReadKey();
                    goto L9;
                }
            }
            Console.ReadKey();
        }
    }
}