using Common.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Interfaces
{
    public interface IInGameModel
    {

        IList<Common.Lib.Interfaces.IPlayer> players { get; set; }
        IPlayer player { get; set; }
        String gameStatusLabel { get; set; } 
        String dealerCardCount { get; set; }
        int cardDealPlayerID { get; set; }

  
    }
}
