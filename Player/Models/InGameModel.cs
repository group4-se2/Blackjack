using Common.Lib.Interfaces;
using Player.Interfaces;
using System;
using System.Collections.Generic;

namespace Player.Models
{
    public class InGameModel : IInGameModel
    {
        
        public IList<Common.Lib.Models.Player> players { get; set; }

        // Current player
        public IPlayer player { get; set; }

        // Status of the game to display on UI
        public String gameStatusLabel { get; set; }

        // Dealer's hand card value count
        public String dealerCardCount { get; set; }

        // Player id of the player to deal cards for
        public int cardDealPlayerID { get; set; }

        IList<IPlayer> IInGameModel.players { get; set; }

        public String testMessage { get; set; }

        public InGameModel()
        {
            
        }

    }
}
