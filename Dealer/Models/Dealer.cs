using Interfaces;
using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public class Dealer : IPlayer
    {
        private String name;
        private Hand hand;
        private List<IPlayer> players;

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
        public IHand Hand
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

        public List<IPlayer> Players
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

        public int Bank
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Wager
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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