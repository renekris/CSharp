using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fibonacci_Sequence
{
    class Program
    {
        
        static int BigIteration(int bi)
        {
            if (bi >= 1)
            {
                return bi;
            }
            else
                return 0;
            
        }

        static string Animation(int bin)
        {
            string ani = Convert.ToString(bin);
            switch (bin)
            {
                case 0:
                    return null;
                case 1:
                    if (ani == "1")
                    {
                        return "#";
                    }
                    else
                        return null;
                case 2:
                    if (ani == "2")
                    {
                        return "##";
                    }
                    else
                        return null;
                default:
                    return "---";


            }
        }

        static void Main(string[] args)
        {
            int bi = 0;
        a:
            long a = 0, b = 1, i, temp, count = 0;
            for (i = 0; i < 91; i++)
            {
                System.Threading.Thread.Sleep(10);
                Console.Clear();
                temp = b;
                b = a;
                a = temp + a;
                Console.WriteLine("~~Fibonacci_Sequence~~\n\nAdds previous numbers \ntogether to make a \nnew number, \nthen uses that \nwith the previous \nto make another, \nand so on...\n\nIt also resets due to \nhaving the max value \nof 9*10^18\n\n{0}\n+\n{1}\n=\n{2}\n\nIteration: {3}\nBig Iteration: {4}\n\n{5}",temp, b, a, count++,BigIteration(bi), Animation(bi));
            }
            bi++;
            goto a;
        }
    }
}
