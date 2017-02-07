using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Models
{
    public class Player : IPlayer
    {
        private string name;
        private int bank;
        private int wager;
        private Hand hand;

        public string Name
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

        public void joinGame()
        { }

        public void exitGame()
        { }

        public void placeBet(int amount)
        { }

        public void requestHit()
        { }

        public void requestStand()
        { }
    }
}
