using Interfaces;

namespace Dealer.Models
{
    public class Card : ICard
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
