using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

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
        List        // Get a list of players from the server
    }

    public enum Response
    {
        Accepted,
        Rejected,
        Null
    }
    
    public class CommandObject
    {
        private Object _payload = new Object();

        public Command Command { get; set; }
        public Response Response { get; set; }
        public string Message { get; set; }
        public Object Payload
        {
            get
            {
                return GetPayload();
            }
            set
            {
                _payload = value;
            }
        }

        private Object GetPayload()
    {
        if (_payload.GetType() == typeof(JObject))
        {
            return ((JObject)_payload).ToObject<Player>();
        }
        else if (_payload.GetType() == typeof(JArray))
        {
            return ((JArray)_payload).ToObject<List<Player>>();
        }
        else
        {
            return _payload;
        }
        }
    }
}
