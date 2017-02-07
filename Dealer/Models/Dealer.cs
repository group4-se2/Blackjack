using Interfaces;
using System;
using System.Collections.Generic;

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
        public Object Hand
        {
            get
            {
                return hand;
            }

            set
            {
                hand = (Hand)value;
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