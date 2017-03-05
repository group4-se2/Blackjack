using Common.Lib.Models;
using Common.Lib.Interfaces;
using System;

namespace Dealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.OnDataReceived += Server_OnDataReceived;
            server.Start();

            DiscoveryServer discoveryServer = new DiscoveryServer("Blackjack",server.GetPort());
            discoveryServer.Start();

            //char[] face = new char[3] { 'J', 'Q', 'K' };
            //Deck deck = new Deck();
            //for (int i = 0; i < 52; i++)
            //{
            //    ICard card = deck.drawCard();
            //    if (card.CardType == CardType.Pip)
            //        Console.WriteLine((i + 1) + " " + card.Value.ToString() + " " + card.Suit.ToString());
            //    else if(card.CardType == CardType.Face)
            //        Console.WriteLine((i + 1) + " " + face[card.Value - 11] + " " + card.Suit.ToString());
            //    else if (card.CardType == CardType.Ace)
            //        Console.WriteLine((i + 1) + " " + "A " + card.Suit.ToString());
            //}
            //Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }

        static void Server_OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            Player player = (Player)e.CmdObject.Payload;
            Console.WriteLine(player.Name);
        }
    }
}
