using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace Kaubahinnad
{
    class Program
    {
        private static string path = @"data.txt";
        private static TextFieldParser parser = new TextFieldParser(@"test.txt");
        private static string objectsPath = @"objects.txt";
        private static string pricePath = @"price.txt";
        static List<string> objects = new List<string>();
        static List<double> price = new List<double>();

        static void Pood()
        {
            Console.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                

                DataTable table = new DataTable();
                table.Columns.Add("Hind", typeof(double));
                table.Columns.Add("Toode", typeof(string));

                var lines = File.ReadAllLines(pricePath).ToList();
                lines.ForEach(line => table.Rows.Add(line));

                double temp = 0;
                foreach (DataRow row in table.Rows)
                {
                    temp += row.Field<double>(0);
                    Console.WriteLine(row.Field<double>(0));
                }

                Console.WriteLine("SUM {0}", temp);
                reader.Close();
            }
            Console.ReadKey();
            //parser.TextFieldType = FieldType.Delimited;
            //parser.SetDelimiters("\t");
            //while (!parser.EndOfData)
            //{
            //    string[] fields = parser.ReadFields();
            //    for (int i = 0; i < fields.Length / 2; i++)
            //    {
            //        price.Add(Convert.ToDouble(fields[i].Replace(',', '.')));
            //        objects.Add(fields[i + 1]);
            //    }
            //}
            //double temp = 0d;
            //foreach (double d in price)
            //{
            //    temp += d;
            //}
            //Console.WriteLine(temp);
            //Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1]> Poodi\n" +
                                  "[2]> Moonda poe hindu\n" +
                                  "[3]> Ava fail\n" +
                                  "[4]> Ava fail Excelis\n" +
                                  "[5]> Ava faili asukoht");

                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Pood();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Process.Start(path);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Process.Start("excel.exe", path);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Process.Start("explorer.exe", "/select, " + path);
                        break;
                }
            }





            Console.ReadKey();


            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters("\t");
            while (!parser.EndOfData)
            {
                //Processing row
                string[] fields = parser.ReadFields();
                for (int i = 0; i < fields.Length / 2; i++)
                {
                    price.Add(Convert.ToDouble(fields[i].Replace(',', '.')));
                    objects.Add(fields[i + 1]);
                }
            }

            double temp = 0d;
            foreach (double d in price)
            {
                temp += d;
            }
            Console.WriteLine(temp);
            Console.WriteLine(objects);


            Console.ReadKey();
            //Tekstifaili igal real on müüdud kauba hind.Arvuta programmi abil nende hindade summa.

        }
    }
}
