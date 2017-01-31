using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealer.Models
{
    public class Dealer : IPlayer
    {
        private String name;
        private Hand hand;
        private List<Player> players;

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return hand;
            }

            set
            {
                hand = value;
            }
        }

        public List<Player> Players
        {
            get
            {
               return players;
            }

            set
            {
                players = value;
            }
        }

        public void dealCards(Player player, int number)
        {
            // Implement dealCards
        }

        public void processScores()
        { }
    }
}