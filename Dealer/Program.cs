using Interfaces;
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
            char[] face = new char[3] { 'J', 'Q', 'K' };
            Models.Deck deck = new Models.Deck();
            for (int i = 0; i < 52; i++)
            {
                ICard card = deck.drawCard();
                if (card.CardType == CardType.Pip)
                    Console.WriteLine((i + 1) + " " + card.Value.ToString() + " " + card.Suit.ToString());
                else if(card.CardType == CardType.Face)
                    Console.WriteLine((i + 1) + " " + face[card.Value - 11] + " " + card.Suit.ToString());
                else if (card.CardType == CardType.Ace)
                    Console.WriteLine((i + 1) + " " + "A " + card.Suit.ToString());
            }
            //Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }
    }
}
