using System;
using System.Collections.Generic;
using Common.Lib.Interfaces;

namespace Common.Lib.Models
{
    public class Deck : IDeck
    {
        public List<ICard> cards { get; set; }
        public Deck()
        {
            cards = new List<ICard>();
         
         // create unshuffled deck   
            for (int i = 2; i < 15; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cards.Add(new Card((Suit)j,i));
                }
            }
            this.shuffleDeck();
        }
        
        private void shuffleDeck()
        {
            Random rand = new Random();
            List<ICard> tempDeck = new List<ICard>();
            int index;
            while (cards.Count > 0)
            {
                index = rand.Next(0, cards.Count - 1);
                tempDeck.Add(cards[index]);
                cards.RemoveAt(index);
            }
            cards.AddRange(tempDeck);
        }
        public ICard takeCard()
        {
            ICard tempCard;
            tempCard = cards[0];
            cards.RemoveAt(0);

            //Console.WriteLine("Card Info: " + tempCard.Description);
            return tempCard;
        }

    }
}
