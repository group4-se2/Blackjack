using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Models
{
    public class Hand
    {
        private List<Models.Card> cards;
        private int score;

        public List<Card> Cards
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
