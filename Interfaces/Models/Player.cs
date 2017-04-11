using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Lib.Interfaces;

namespace Common.Lib.Models
{
    public class Player : IPlayer
    {
        private const int STARTING_CREDIT_BALANCE = 100;  // facilitate changing game length later

        /* The following are values for THIS player that are sent out to ALL players 
         * to facilitate the rendering of all players on the card table
         */
        public int creditBalance { get; set; }

        public int WagerAmount { set; get; }

        // facilitates GUI buttons and display - includes bet, hit/pass, win-loss-draw
        private int gameStatus { set; get; }

        // enables interaction with GUI
        private bool hasFocus { set; get; }

        private IHand myHand { set; get; }

        public string Name { get; set; }

        public Player()
        {
            creditBalance = STARTING_CREDIT_BALANCE;
            WagerAmount = 0;
            gameStatus = 0;
            hasFocus = true;
            myHand = new Hand();
        }

        public void dealCard(IDeck deck, bool faceDown)
        {
            myHand.dealCard(deck, faceDown);
        }

        public ICard getCard(int position)
        {
            return myHand.getCard(position);
        }
        public void setFocus(bool status)
        {
            hasFocus = status;
        }
        public bool getFocus()
        {
            return hasFocus;
        }
        public void switchFocus()
        {
            if(hasFocus)
            {
                hasFocus = false;
            }
            else
            {
                hasFocus = true;
            }
        }
        public int getCreditBalance()
        {
            return creditBalance;
        }
        public void debitCreditBalance(int amount)
        {
            creditBalance -= amount;
        }
        public void creditCreditBalance(int amount)
        {
            creditBalance += amount;
        }

        public void advanceGameStatus()
        {
            gameStatus++;
        }
        public void setGameStatus(int status)
        {
            gameStatus = status;
        }
        public int getGameStatus()
        {
            return gameStatus;
        }

        public void setWagerAmount(int amount)
        {
            WagerAmount = amount;
        }
        public int getWagerAmount()
        {
            return WagerAmount;
        }

        public int scoreHand()
        {
            return myHand.scoreHand();
        }

        //public void dealCard()
        //{
        //    throw new NotImplementedException();
        //}
    }
}