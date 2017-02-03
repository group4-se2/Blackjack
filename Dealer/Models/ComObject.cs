using Newtonsoft.Json;
using System;
using System.Net.Sockets;

namespace Dealer.Models
{
    public enum Command
    {
        Join,       //Log into the server
        Exit,       //Logout of the server
        Bet,        // Place bet
        Hit,        // Request a card
        Stand,      // No more cards
        Message,    //Send a text message to all the players
        List        //Get a list of players from the server
    }

    public enum Response
    {
        Accepted,
        Rejected,
        Null
    }
    
    public class CommandObject
    {
        public Command Command { get; set; }
        public Response Response { get; set; }
        public string Message { get; set; }
        public Object Payload { get; set; }
    }
}
