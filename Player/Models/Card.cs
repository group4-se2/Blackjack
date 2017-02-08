using Interfaces;

namespace Player.Models
{
    public class Card : ICard
    {
        private Interfaces.Suit suit;
        private Interfaces.CardType cardType;
        private int value;

        public Interfaces.Suit Suit
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

        public Interfaces.CardType CardType
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
