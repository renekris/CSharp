using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Kaubahinnad
{
    class Program
    {
        private static string path = @"data.txt";
        static void Main(string[] args)
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1]> Poodi\n" +
                                  "[2]> Ava fail\n" +
                                  "[3]> Ava fail Excelis\n" +
                                  "[4]> Ava faili asukoht");
                ConsoleKey press = Console.ReadKey().Key;
                switch (press)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        ColumnsPriceSum();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Process.Start(path);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Process.Start("excel.exe", path);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Process.Start("explorer.exe", "/select, " + path);
                        break;
                }
            }
        }
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
                for (int i = 0; i < numberOfColumns; i++)
                {
                    dr[i] = cols[i];
                }
                tbl.Rows.Add(dr);
            }
            return tbl;
        }

        static void ColumnsPriceSum()
        {
            List<double> hinnadList = new List<double>();
            List<double> hinnadSumList = new List<double>();
            DataTable dataTable = ConvertToDataTable(path, 3);

            while (true)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    Console.Write("Sisesta ostu number:");
                    Console.Write("\tTäis hind: €{0}\t", hinnadSumList.Sum());
                    Console.Write("[0] - Tagasi\n");
                    Console.WriteLine("NUMBER\tHIND\tTOODE");

                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                    reader.Close();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        hinnadList.Add(Convert.ToDouble(dataTable.Rows[i]["Column2"].ToString().Replace("€", null)));
                    }
                    Console.SetCursorPosition(20, 0);
                    //Loeb
                    if (int.TryParse(Console.ReadLine(), out int enteredNumber) && hinnadList.Count + 1 > enteredNumber)
                    {
                        if (enteredNumber == 0)
                        {
                            break;
                        }
                        hinnadSumList.Add(hinnadList[enteredNumber - 1]);
                    }
                    hinnadList.Clear();
                }
                Console.Clear();
            }
        }
    }
}
