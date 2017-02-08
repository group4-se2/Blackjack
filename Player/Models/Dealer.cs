using Interfaces;
using System;
using System.Collections.Generic;

namespace Player.Models
{
    public class Dealer : IPlayer
    {
        private String name;
        private IHand hand;
        private List<IPlayer> players;
        private int bank;
        private int wager;

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
                hand = value;
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
                return bank;
            }

            set
            {
                bank = value;
            }
        }

        public int Wager
        {
            get
            {
                return wager;
            }

            set
            {
                wager = value;
            }
        }
        
        public void dealCards(IPlayer player, int number)
        {
            // Implement dealCards
        }

        public void processScores()
        { }
    }
}