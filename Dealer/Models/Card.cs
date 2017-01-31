using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Models
{
    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }
    public enum CardType
    {
        Face,
        Pip,
        Ace
    }
    public class Card
    {
        private Suit suit;
        private CardType cardType;
        private int value;

        public Suit Suit
        {
            get
            {
                return suit;
            }

            set
            {
                suit = value;
            }
        }

        public CardType CardType
        {
            get
            {
                return cardType;
            }

            set
            {
                cardType = value;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
