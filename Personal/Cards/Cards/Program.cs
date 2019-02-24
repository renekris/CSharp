using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Cards
    {
        private static string RedCard(string card)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(card);
            Console.ResetColor();
            return card;
        }

        private static string WhiteCard(string card)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(card);
            Console.ResetColor();
            return card;
        }

        public static void SpadeCards()
        {
             string spades1Card = WhiteCard(" _____\r\n|1    |\r\n|     |\r\n|  ♠  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
             string spades2Card = WhiteCard(" _____\r\n|2    |\r\n|  ♠  |\r\n|     |\r\n|  ♠  |\r\n|     |\r\n ‾‾‾‾‾");
             string spades3Card = WhiteCard(" _____\r\n|3    |\r\n|  ♠  |\r\n|  ♠  |\r\n|  ♠  |\r\n|     |\r\n ‾‾‾‾‾");
             string spades4Card = WhiteCard(" _____\r\n|4    |\r\n| ♠ ♠ |\r\n|     |\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
             string spades5Card = WhiteCard(" _____\r\n|5    |\r\n| ♠ ♠ |\r\n|  ♠  |\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
             string spades6Card = WhiteCard(" _____\r\n|6    |\r\n| ♠ ♠ |\r\n| ♠ ♠ |\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
             string spades7Card = WhiteCard(" _____\r\n|7    |\r\n| ♠ ♠ |\r\n|♠ ♠ ♠|\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
             string spades8Card = WhiteCard(" _____\r\n|8    |\r\n|♠ ♠ ♠|\r\n| ♠ ♠ |\r\n|♠ ♠ ♠|\r\n|     |\r\n ‾‾‾‾‾");
             string spades9Card = WhiteCard(" _____\r\n|9 ♠  |\r\n|♠   ♠|\r\n|♠ ♠ ♠|\r\n|♠   ♠|\r\n|  ♠  |\r\n ‾‾‾‾‾");
            string spades10Card = WhiteCard(" _____\r\n|10♠  |\r\n|♠ ♠ ♠|\r\n| ♠ ♠ |\r\n|♠ ♠ ♠|\r\n|  ♠  |\r\n ‾‾‾‾‾");
            string spades11Card = WhiteCard(" _____\r\n|J    |\r\n| ♠-♠ |\r\n| |J| |\r\n| ♠-♠ |\r\n|     |\r\n ‾‾‾‾‾");
            string spades12Card = WhiteCard(" _____\r\n|K    |\r\n| ♠-♠ |\r\n| |K| |\r\n| ♠-♠ |\r\n|     |\r\n ‾‾‾‾‾");
            string spades13Card = WhiteCard(" _____\r\n|Q    |\r\n| ♠-♠ |\r\n| |Q| |\r\n| ♠-♠ |\r\n|     |\r\n ‾‾‾‾‾");
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Cards.SpadeCards();

            Console.WriteLine("♠\t♥\t♦\t♣");
            Console.ReadKey();
        }
    }
}
