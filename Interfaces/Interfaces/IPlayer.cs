// Added interface items from Player class
// Fred Mar 8, 2017

namespace Common.Lib.Interfaces
{
    public interface IPlayer
    {
        // creates one additional card in this player hand
        //void dealCard();

        // unknown if this will be implemented from outside Player
        // return card code (1 - 52) from hand by hand[] (position)
        //int getCard(int position);

        // unknown if this will be implemented from outside Player
        // return card face value when given card code

        //string parseCard(int numericValue);

        // set focus for true for this player
        //void enableFocus();

        // set focus to false for this player
        //void disableFocus();

        // get current focus for this player
        //bool getFocus();

        // deduct wager from credit balance
        //void deductWager(int amount);

        // used by dealer to credit winnings to this player
        //void depositWin(int amount);

        // used by dealer to calculate winnings
        //used by GUI to display this player's credit balance
        //int getCreditBalance();

        /* used exclusively be server to sync GUI to game phase
         * 1 - Bet
         * 2 - Hit/Stand
         * 3 - loss (hand complete - for GUI only)
         * 4 - Bust (hand complete - for GUI only)
         * 5 - Tie (hand complete - for GUI only)
         * 6 - Win (hand complete - for GUI only)
         * 7 - Blackjack (hand complete - for GUI only)
         */
        //void setGameStatus(int status);

        // get this player status
        //int getGameStatus();
        
        // used by server to set wager (then send to all GUIs)
        //void setWager(int amount);

        // may be unneded at this end
        // used too get wager amount
        //int getWager();

        // used by dealer to compare and score this player
        //int calculateHandValue();


        // may delete - dont want to yet
        int Bank { get; set; }
        IHand Hand { get; set; }
        string Name { get; set; }
        int Wager { get; set; }
    }
}