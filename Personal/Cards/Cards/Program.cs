using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class Cards
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
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
        public static void HeartCards()
        {
            string heart1Card = RedCard(" _____\r\n|1    |\r\n|     |\r\n|  ♥  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
            string heart2Card = RedCard(" _____\r\n|2    |\r\n|  ♥  |\r\n|     |\r\n|  ♥  |\r\n|     |\r\n ‾‾‾‾‾");
            string heart3Card = RedCard(" _____\r\n|3    |\r\n|  ♥  |\r\n|  ♥  |\r\n|  ♥  |\r\n|     |\r\n ‾‾‾‾‾");
            string heart4Card = RedCard(" _____\r\n|4    |\r\n| ♥ ♥ |\r\n|     |\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
            string heart5Card = RedCard(" _____\r\n|5    |\r\n| ♥ ♥ |\r\n|  ♥  |\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
            string heart6Card = RedCard(" _____\r\n|6    |\r\n| ♥ ♥ |\r\n| ♥ ♥ |\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
            string heart7Card = RedCard(" _____\r\n|7    |\r\n| ♥ ♥ |\r\n|♥ ♥ ♥|\r\n| ♥ ♥ |\r\n|     |\r\n ‾‾‾‾‾");
            string heart8Card = RedCard(" _____\r\n|8    |\r\n|♥ ♥ ♥|\r\n| ♥ ♥ |\r\n|♥ ♥ ♥|\r\n|     |\r\n ‾‾‾‾‾");
            string heart9Card = RedCard(" _____\r\n|9 ♥  |\r\n|♥   ♥|\r\n|♥ ♥ ♥|\r\n|♥   ♥|\r\n|  ♥  |\r\n ‾‾‾‾‾");
            string heart10Card = RedCard(" _____\r\n|10♥  |\r\n|♥ ♥ ♥|\r\n| ♥ ♥ |\r\n|♥ ♥ ♥|\r\n|  ♥  |\r\n ‾‾‾‾‾");
            string heart11Card = RedCard(" _____\r\n|J    |\r\n| ♥-♥ |\r\n| |J| |\r\n| ♥-♥ |\r\n|     |\r\n ‾‾‾‾‾");
            string heart12Card = RedCard(" _____\r\n|K    |\r\n| ♥-♥ |\r\n| |K| |\r\n| ♥-♥ |\r\n|     |\r\n ‾‾‾‾‾");
            string heart13Card = RedCard(" _____\r\n|Q    |\r\n| ♥-♥ |\r\n| |Q| |\r\n| ♥-♥ |\r\n|     |\r\n ‾‾‾‾‾");
        }
        public static void DiamondCards()
        {
            string diamond1Card = RedCard(" _____\r\n|1    |\r\n|     |\r\n|  ♦  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond2Card = RedCard(" _____\r\n|2    |\r\n|  ♦  |\r\n|     |\r\n|  ♦  |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond3Card = RedCard(" _____\r\n|3    |\r\n|  ♦  |\r\n|  ♦  |\r\n|  ♦  |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond4Card = RedCard(" _____\r\n|4    |\r\n| ♦ ♦ |\r\n|     |\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond5Card = RedCard(" _____\r\n|5    |\r\n| ♦ ♦ |\r\n|  ♦  |\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond6Card = RedCard(" _____\r\n|6    |\r\n| ♦ ♦ |\r\n| ♦ ♦ |\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond7Card = RedCard(" _____\r\n|7    |\r\n| ♦ ♦ |\r\n|♦ ♦ ♦|\r\n| ♦ ♦ |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond8Card = RedCard(" _____\r\n|8    |\r\n|♦ ♦ ♦|\r\n| ♦ ♦ |\r\n|♦ ♦ ♦|\r\n|     |\r\n ‾‾‾‾‾");
            string diamond9Card = RedCard(" _____\r\n|9 ♦  |\r\n|♦   ♦|\r\n|♦ ♦ ♦|\r\n|♦   ♦|\r\n|  ♦  |\r\n ‾‾‾‾‾");
            string diamond10Card = RedCard(" _____\r\n|10♦  |\r\n|♦ ♦ ♦|\r\n| ♦ ♦ |\r\n|♦ ♦ ♦|\r\n|  ♦  |\r\n ‾‾‾‾‾");
            string diamond11Card = RedCard(" _____\r\n|J    |\r\n| ♦-♦ |\r\n| |J| |\r\n| ♦-♦ |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond12Card = RedCard(" _____\r\n|K    |\r\n| ♦-♦ |\r\n| |K| |\r\n| ♦-♦ |\r\n|     |\r\n ‾‾‾‾‾");
            string diamond13Card = RedCard(" _____\r\n|Q    |\r\n| ♦-♦ |\r\n| |Q| |\r\n| ♦-♦ |\r\n|     |\r\n ‾‾‾‾‾");
        }
        public static void ClubCards()
        {
            string club1Card = WhiteCard(" _____\r\n|1    |\r\n|     |\r\n|  ♣  |\r\n|     |\r\n|     |\r\n ‾‾‾‾‾");
            string club2Card = WhiteCard(" _____\r\n|2    |\r\n|  ♣  |\r\n|     |\r\n|  ♣  |\r\n|     |\r\n ‾‾‾‾‾");
            string club3Card = WhiteCard(" _____\r\n|3    |\r\n|  ♣  |\r\n|  ♣  |\r\n|  ♣  |\r\n|     |\r\n ‾‾‾‾‾");
            string club4Card = WhiteCard(" _____\r\n|4    |\r\n| ♣ ♣ |\r\n|     |\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
            string club5Card = WhiteCard(" _____\r\n|5    |\r\n| ♣ ♣ |\r\n|  ♣  |\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
            string club6Card = WhiteCard(" _____\r\n|6    |\r\n| ♣ ♣ |\r\n| ♣ ♣ |\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
            string club7Card = WhiteCard(" _____\r\n|7    |\r\n| ♣ ♣ |\r\n|♣ ♣ ♣|\r\n| ♣ ♣ |\r\n|     |\r\n ‾‾‾‾‾");
            string club8Card = WhiteCard(" _____\r\n|8    |\r\n|♣ ♣ ♣|\r\n| ♣ ♣ |\r\n|♣ ♣ ♣|\r\n|     |\r\n ‾‾‾‾‾");
            string club9Card = WhiteCard(" _____\r\n|9 ♣  |\r\n|♣   ♣|\r\n|♣ ♣ ♣|\r\n|♣   ♣|\r\n|  ♣  |\r\n ‾‾‾‾‾");
            string club10Card = WhiteCard(" _____\r\n|10♣  |\r\n|♣ ♣ ♣|\r\n| ♣ ♣ |\r\n|♣ ♣ ♣|\r\n|  ♣  |\r\n ‾‾‾‾‾");
            string club11Card = WhiteCard(" _____\r\n|J    |\r\n| ♣-♣ |\r\n| |J| |\r\n| ♣-♣ |\r\n|     |\r\n ‾‾‾‾‾");
            string club12Card = WhiteCard(" _____\r\n|K    |\r\n| ♣-♣ |\r\n| |K| |\r\n| ♣-♣ |\r\n|     |\r\n ‾‾‾‾‾");
            string club13Card = WhiteCard(" _____\r\n|Q    |\r\n| ♣-♣ |\r\n| |Q| |\r\n| ♣-♣ |\r\n|     |\r\n ‾‾‾‾‾");
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Cards.SpadeCards();
            Cards.ClubCards();
            Cards.DiamondCards();
            Cards.HeartCards();
            Console.WriteLine("♠\t♥\t♦\t♣");
            Console.ReadKey();
        }
    }
}
