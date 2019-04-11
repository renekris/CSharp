using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
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
        static DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable tbl = new DataTable();
            for (int col = 0; col < numberOfColumns; col++)
            {
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
            }
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                var cols = line.Split('\t');
                DataRow dr = tbl.NewRow();
                for (int i = 0; i < 2; i++)
                {
                    dr[i] = cols[i];
                }
                tbl.Rows.Add(dr);
            }
            return tbl;
        }

        static void ColumnsPriceSum()
        {
            StreamReader reader = new StreamReader(path);
            List<double> hinnad = new List<double>();
            DataTable dataTable = ConvertToDataTable(path, 2);
            double sum = 0d, price = 0d;
            string objects = "";
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }
            reader.Close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                hinnad.Add(Convert.ToDouble(dataTable.Rows[i]["Column1"].ToString()));
                objects = dataTable.Rows[i]["Column2"].ToString();
            }

            Console.WriteLine(string.Format("{0}€", hinnad.Sum()));
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
                        Console.Clear();
                        ColumnsPriceSum();
                        Console.ReadKey();
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
        }
    }
}
