﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Interfaces
{
    public interface IPlayer
    {
        String Name { get; set; }

        int WagerAmount { get; set; }
        
        int creditBalance { get; set; }

        //adds one  card to this player's hand
        void dealCard(IDeck deck, bool faceDown);

        ICard getCard(int position);
        IHand myHand { get; set; }

        bool hasFocus { get; set; }

        void setFocus(bool status);

        bool getFocus();
       
        //sets hasFocus opposite to current focus
        void switchFocus();

        int getCreditBalance();
        
        //decreases this player's creditBalance by int
        void debitCreditBalance(int amount);
       
        //increases this player's creditBalance by int
        void creditCreditBalance(int amount);

        /* used by game server to sync GUI to game phase
         * 0 - Bet
         * 1 - Waiting on other bets...
         * 2 - Hit/Stand
         * 3 - Loss (hand complete - for GUI only)
         * 4 - Bust (hand complete - for GUI only)
         * 5 - Push (hand complete - for GUI only)
         * 6 - Win (hand complete - for GUI only)
         * 7 - Blackjack (hand complete - for GUI only)
         * 8 - Inactive
         * 9 - Dealer Reveal Hole Card
         */

        void advanceGameStatus();
        void setGameStatus(int status);
        int getGameStatus();
        void setWagerAmount(int amount);
        int getWagerAmount();

        //returns this player's score  -- 99 for a blackjack 
        int scoreHand();
    }
}
