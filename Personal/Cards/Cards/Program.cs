using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(card);
            Console.ResetColor();
            return card;
        }

        public static string SpadeCards(int num)
        {
            string returnCard = null;
            switch (num)
            {
                //Space cards
                case 1:
                    returnCard = WhiteCard(" _____\r\n|1    |\r\n|     |\r\n|  ♠  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 2:
                    returnCard = WhiteCard(" _____\r\n|2    |\r\n|  ♠  |\r\n|     |\r\n|  ♠  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 3:
                    returnCard = WhiteCard(" _____\r\n|3    |\r\n|  ♠  |\r\n|  ♠  |\r\n|  ♠  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 4:
                    returnCard = WhiteCard(" _____\r\n|4    |\r\n| ♠ ♠ |\r\n|     |\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 5:
                    returnCard = WhiteCard(" _____\r\n|5    |\r\n| ♠ ♠ |\r\n|  ♠  |\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 6:
                    returnCard = WhiteCard(" _____\r\n|6    |\r\n| ♠ ♠ |\r\n| ♠ ♠ |\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 7:
                    returnCard = WhiteCard(" _____\r\n|7    |\r\n| ♠ ♠ |\r\n|♠ ♠ ♠|\r\n| ♠ ♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 8:
                    returnCard = WhiteCard(" _____\r\n|8    |\r\n|♠ ♠ ♠|\r\n| ♠ ♠ |\r\n|♠ ♠ ♠|\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 9:
                    returnCard = WhiteCard(" _____\r\n|9 ♠  |\r\n|♠   ♠|\r\n|♠ ♠ ♠|\r\n|♠   ♠|\r\n|  ♠  |\r\n ‾‾‾‾‾");
                    break;
                case 10:
                    returnCard = WhiteCard(" _____\r\n|10♠  |\r\n|♠ ♠ ♠|\r\n| ♠ ♠ |\r\n|♠ ♠ ♠|\r\n|  ♠  |\r\n ‾‾‾‾‾");
                    break;
                case 11:
                    returnCard = WhiteCard(" _____\r\n|J    |\r\n| ♠-♠ |\r\n| |J| |\r\n| ♠-♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 12:
                    returnCard = WhiteCard(" _____\r\n|K    |\r\n| ♠-♠ |\r\n| |K| |\r\n| ♠-♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 13:
                    returnCard = WhiteCard(" _____\r\n|Q    |\r\n| ♠-♠ |\r\n| |Q| |\r\n| ♠-♠ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                //Heart cards     
                case 14:
                    returnCard = RedCard(" _____\r\n|1    |\r\n|     |\r\n|  ♥  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 15:
                    returnCard = RedCard(" _____\r\n|2    |\r\n|  ♥  |\r\n|     |\r\n|  ♥  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 16:
                    returnCard = RedCard(" _____\r\n|3    |\r\n|  ♥  |\r\n|  ♥  |\r\n|  ♥  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 17:
                    returnCard = RedCard(" _____\r\n|4    |\r\n| ♥ ♥ |\r\n|     |\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 18:
                    returnCard = RedCard(" _____\r\n|5    |\r\n| ♥ ♥ |\r\n|  ♥  |\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 19:
                    returnCard = RedCard(" _____\r\n|6    |\r\n| ♥ ♥ |\r\n| ♥ ♥ |\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 20:
                    returnCard = RedCard(" _____\r\n|7    |\r\n| ♥ ♥ |\r\n|♥ ♥ ♥|\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 21:
                    returnCard = RedCard(" _____\r\n|8    |\r\n|♥ ♥ ♥|\r\n| ♥ ♥ |\r\n|♥ ♥ ♥|\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 22:
                    returnCard = RedCard(" _____\r\n|9 ♥  |\r\n|♥   ♥|\r\n|♥ ♥ ♥|\r\n|♥   ♥|\r\n|  ♥  |\r\n ‾‾‾‾‾");
                    break;
                case 23:
                    returnCard = RedCard(" _____\r\n|10♥  |\r\n|♥ ♥ ♥|\r\n| ♥ ♥ |\r\n|♥ ♥ ♥|\r\n|  ♥  |\r\n ‾‾‾‾‾");
                    break;
                case 24:
                    returnCard = RedCard(" _____\r\n|J    |\r\n| ♥-♥ |\r\n| |J| |\r\n| ♥-♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 25:
                    returnCard = RedCard(" _____\r\n|K    |\r\n| ♥-♥ |\r\n| |K| |\r\n| ♥-♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 26:
                    returnCard = RedCard(" _____\r\n|Q    |\r\n| ♥-♥ |\r\n| |Q| |\r\n| ♥-♥ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                //Diamond cards
                case 27:
                    returnCard = RedCard(" _____\r\n|1    |\r\n|     |\r\n|  ♦  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 28:
                    returnCard = RedCard(" _____\r\n|2    |\r\n|  ♦  |\r\n|     |\r\n|  ♦  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 29:
                    returnCard = RedCard(" _____\r\n|3    |\r\n|  ♦  |\r\n|  ♦  |\r\n|  ♦  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 30:
                    returnCard = RedCard(" _____\r\n|4    |\r\n| ♦ ♦ |\r\n|     |\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 31:
                    returnCard = RedCard(" _____\r\n|5    |\r\n| ♦ ♦ |\r\n|  ♦  |\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 32:
                    returnCard = RedCard(" _____\r\n|6    |\r\n| ♦ ♦ |\r\n| ♦ ♦ |\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 33:
                    returnCard = RedCard(" _____\r\n|7    |\r\n| ♦ ♦ |\r\n|♦ ♦ ♦|\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 34:
                    returnCard = RedCard(" _____\r\n|8    |\r\n|♦ ♦ ♦|\r\n| ♦ ♦ |\r\n|♦ ♦ ♦|\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 35:
                    returnCard = RedCard(" _____\r\n|9 ♦  |\r\n|♦   ♦|\r\n|♦ ♦ ♦|\r\n|♦   ♦|\r\n|  ♦  |\r\n ‾‾‾‾‾");
                    break;
                case 36:
                    returnCard = RedCard(" _____\r\n|10♦  |\r\n|♦ ♦ ♦|\r\n| ♦ ♦ |\r\n|♦ ♦ ♦|\r\n|  ♦  |\r\n ‾‾‾‾‾");
                    break;
                case 37:
                    returnCard = RedCard(" _____\r\n|J    |\r\n| ♦-♦ |\r\n| |J| |\r\n| ♦-♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 38:
                    returnCard = RedCard(" _____\r\n|K    |\r\n| ♦-♦ |\r\n| |K| |\r\n| ♦-♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 39:
                    returnCard = RedCard(" _____\r\n|Q    |\r\n| ♦-♦ |\r\n| |Q| |\r\n| ♦-♦ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                //Club cards
                case 40:
                    returnCard = WhiteCard(" _____\r\n|1    |\r\n|     |\r\n|  ♣  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 41:
                    returnCard = WhiteCard(" _____\r\n|2    |\r\n|  ♣  |\r\n|     |\r\n|  ♣  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 42:
                    returnCard = WhiteCard(" _____\r\n|3    |\r\n|  ♣  |\r\n|  ♣  |\r\n|  ♣  |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 43:
                    returnCard = WhiteCard(" _____\r\n|4    |\r\n| ♣ ♣ |\r\n|     |\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 44:
                    returnCard = WhiteCard(" _____\r\n|5    |\r\n| ♣ ♣ |\r\n|  ♣  |\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 45:
                    returnCard = WhiteCard(" _____\r\n|6    |\r\n| ♣ ♣ |\r\n| ♣ ♣ |\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 46:
                    returnCard = WhiteCard(" _____\r\n|7    |\r\n| ♣ ♣ |\r\n|♣ ♣ ♣|\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 47:
                    returnCard = WhiteCard(" _____\r\n|8    |\r\n|♣ ♣ ♣|\r\n| ♣ ♣ |\r\n|♣ ♣ ♣|\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 48:
                    returnCard = WhiteCard(" _____\r\n|9 ♣  |\r\n|♣   ♣|\r\n|♣ ♣ ♣|\r\n|♣   ♣|\r\n|  ♣  |\r\n ‾‾‾‾‾");
                    break;
                case 49:
                    returnCard = WhiteCard(" _____\r\n|10♣  |\r\n|♣ ♣ ♣|\r\n| ♣ ♣ |\r\n|♣ ♣ ♣|\r\n|  ♣  |\r\n ‾‾‾‾‾");
                    break;
                case 50:
                    returnCard = WhiteCard(" _____\r\n|J    |\r\n| ♣-♣ |\r\n| |J| |\r\n| ♣-♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 51:
                    returnCard = WhiteCard(" _____\r\n|K    |\r\n| ♣-♣ |\r\n| |K| |\r\n| ♣-♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
                case 52:
                    returnCard = WhiteCard(" _____\r\n|Q    |\r\n| ♣-♣ |\r\n| |Q| |\r\n| ♣-♣ |\r\n|     |\r\n ‾‾‾‾‾");
                    break;
            }

            return returnCard;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.OutputEncoding = Encoding.Unicode;
            List<int> cardsList = new List<int>(1 - 52); 

            while (true)
            {
                int rngCards = rng.Next(cardsList);
                cardsList.Remove(rngCards);
                Cards.SpadeCards(rngCards);
                Console.ReadKey();
                Thread.Sleep(25);
                Console.Clear();
            }
            

            Console.WriteLine("♠\t♥\t♦\t♣");
            Console.ReadKey();
        }
    }
}
