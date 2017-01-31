using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Models.Deck deck = new Models.Deck();
            for(int i = 0; i < 52; i++)
            {
                Models.Card card = deck.drawCard();
                Console.WriteLine((i+1) + " " + card.Value.ToString() + " " + card.Suit.ToString());
            }
            Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }
    }
}
