using Common.Lib.Interfaces;
using Common.Lib.Models;
using System;
using System.Collections.Generic;

namespace Common.Lib.Utility
{
    public class Deserializer
    {
        public static Card DeserializeCard(ref String s)
        {
            String suitValue = GetValue(ref s);
            GetValue(ref s);
            int numericValue = int.Parse(GetValue(ref s));
            GetValue(ref s);
            GetValue(ref s);
            GetValue(ref s);
            Card card = new Card((Suit)Enum.Parse(typeof(Suit), suitValue), numericValue);
            card.IsFaceDown = Boolean.Parse(s.Split(':')[1]);

            return card;
        }
        public static List<ICard> DeserializeHand(ref String s)
        {
            List<ICard> hand = new List<ICard>();
            int start = s.IndexOf('[');
            int end = s.IndexOf(']');

            if (s.Substring(start + 1, 1) == "{")
            {
                start++;
                String[] cards = s.Substring(start, end - start).Split('{', '}');

                s = s.Remove(0, end + 2);

                for (int i = 0; i < cards.Length - 1; i++)
                {
                    if (cards[i] != "" && cards[i] != ",")
                    {
                        Card card = DeserializeCard(ref cards[i]);
                        hand.Add(card);
                    }
                }
            }
            return hand;
        }
        public static Player DeserializePlayer(ref String s)
        {
            Player player = new Player();
            String n = GetValue(ref s).Remove(1, 1);
            n = n.Remove(n.Length - 1, 1).Trim();
            player.Name = n;
            player.creditBalance = int.Parse(GetValue(ref s));
            player.WagerAmount = int.Parse(GetValue(ref s));
            player.gameStatus = int.Parse(GetValue(ref s));
            player.hasFocus = Boolean.Parse(GetValue(ref s));
            player.myHand = new Hand() { hand = DeserializeHand(ref s) };
            return player;
        }
        public static CommandObject DeserializeCommand(String s)
        {
            CommandObject commandObj = new CommandObject();
            List<IPlayer> players = new List<IPlayer>();

            s = s.Trim();

            int result;
            int i = s.IndexOf(",");
            String v = s.Substring(0, i).Split(':')[1];
            int.TryParse(v, out result);
            commandObj.Command = (Command)result;
            s = s.Remove(0, i + 1);

            i = s.IndexOf(",");
            v = s.Substring(0, i).Split(':')[1];
            int.TryParse(v, out result);
            commandObj.Response = (Response)result;
            s = s.Remove(0, i + 1);

            i = s.IndexOf(",");
            v = s.Substring(0, i).Split(':')[1].Remove(1, 1);
            v = v.Remove(v.Length - 1, 1);
            commandObj.Message = v;
            s = s.Remove(0, i + 1);

            i = s.IndexOf("{");
            while(i > -1)
            {
                s = s.Remove(0, i + 1);
                Player p = DeserializePlayer(ref s);
                players.Add(p);
                i = s.IndexOf("{");
            }
            commandObj.Players = players;

            return commandObj;
        }
        private static String GetValue(ref String s)
        {
            String v = "";
            int i = s.IndexOf(",");

            if (i > -1)
            {
                v = s.Substring(0, i).Split(':')[1];
                s = s.Remove(0, i + 1);
            }
            return v;
        }
    }
}
