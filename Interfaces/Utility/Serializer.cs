using Common.Lib.Interfaces;
using Common.Lib.Models;
using System;
using System.Text;

namespace Common.Lib.Utility
{
    public class Serializer
    {
        public static String SerializeCard(ICard card)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{\"Suit\": " + (int)card.Suit + "," +
                      "\"Description\": \"" + card.Description + "\"," +
                      "\"NumericValue\": " + card.NumericValue.ToString() + "," +
                      "\"FaceValue\": " + card.FaceValue.ToString() + "," +
                      "\"IsFaceCard\": " + card.IsFaceCard.ToString().ToLower() + "," +
                      "\"IsAce\": " + card.IsAce.ToString().ToLower() + "," +
                      "\"IsFaceDown\": " + card.IsFaceDown.ToString().ToLower() + "}");
            return sb.ToString();
        }

        public static String SerializeHand(IHand hand)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            foreach (ICard card in hand.hand)
            {
                sb.Append(SerializeCard(card) + ",");
            }
            if(hand.length > 0) sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return sb.ToString();
        }

        public static String SerializePlayer(IPlayer player)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"Name\": \"" + player.Name + "\"," +
                        "\"CreditBalance\": " + player.getCreditBalance() + "," +
                        "\"WagerAmount\": " + player.getWagerAmount() + "," +
                        "\"gameStatus\": " + player.getGameStatus() + "," +
                        "\"hasFocus\": " + player.getFocus().ToString().ToLower() + "," +
                        "\"myHand\": " + SerializeHand(player.myHand) + "}");
            return sb.ToString();
        }
        public static String SerializeCommand(CommandObject commandObject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"Command\": " + (int)commandObject.Command +"," +
                      "\"Response\": " + (int)commandObject.Response + "," +
                      "\"Message\": \"" + commandObject.Message + "\"," +
                      "\"Players\": [");
            foreach (Player player in commandObject.Players) sb.Append(SerializePlayer(player) + ",");
            if(sb.ToString().LastIndexOf(',') == sb.Length-1) sb.Remove(sb.Length - 1, 1);
            sb.Append("]}");
            return sb.ToString();
        }
    }
}