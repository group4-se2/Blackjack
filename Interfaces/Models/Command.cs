using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Models
{
    public enum Command
    {
        Join,       // Join a game
        Exit,       // Leave a game
        Bet,        // Place bet
        Hit,        // Request a card
        Stand,      // No more cards
        Message,    // Send a text message to all the players
        Sync        // Syncs players with the server
    }
}
