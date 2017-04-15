using Common.Lib.Interfaces;
using Player.Interfaces;
using System;
using System.Collections.Generic;

namespace Player.Models
{
    public class InGameModel : IInGameModel
    {
        
        public IList<Common.Lib.Models.Player> players { get; set; }

        public IPlayer player { get; set; }

        IList<IPlayer> IInGameModel.players { get; set; }

        public InGameModel()
        {
            
        }

    }
}
