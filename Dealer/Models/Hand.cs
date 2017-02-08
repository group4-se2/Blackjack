using Interfaces;
using System.Collections.Generic;

namespace Dealer.Models
{
    public class Hand : IHand
    {
        private List<ICard> cards;
        private int score;

        public List<ICard> Cards
        {
            get
            {
                return cards;
            }

            set
            {
                cards = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public void calculateScore()
        {
            // Implement calculateScore
        }
    }
}
