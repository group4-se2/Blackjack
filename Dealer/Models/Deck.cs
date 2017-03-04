using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dealer.Models
{
    public class Deck : IDeck
    {
        private static System.Security.Cryptography.RNGCryptoServiceProvider seed = 
            new System.Security.Cryptography.RNGCryptoServiceProvider();

        private List<ICard> cards = new List<ICard>();

        public List<ICard> Cards
        {
            get
            {
                return cards;
            }
        }

        List<ICard> IDeck.Cards
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Deck()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int val = 1; val < 14; val++)
                {
                    Card card = new Card();
                    card.Suit = (Suit)suit;
                    card.CardType = val > 10 ? CardType.Face : val > 1 ? CardType.Pip : CardType.Ace;
                    card.Value = val;
                    this.cards.Add(card);
                }
            }
        }
        public ICard drawCard()
        {
            int minimum = 0;
            int maximum = cards.Count-1;
            ICard card;

            byte[] randomNumber = new byte[1];

            seed.GetBytes(randomNumber);

            double asciiValue = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValue / 255d) - 0.00000000001d);

            // adding one to the range, to allow for rounding 
            int range = maximum - minimum + 1;

            // round to ensure within range
            double randomValue = Math.Floor(multiplier * range); 

            card = cards.ElementAt<ICard>((int)(randomValue));

            cards.RemoveAt((int)(randomValue));

            return card; 
        }
    }
}
