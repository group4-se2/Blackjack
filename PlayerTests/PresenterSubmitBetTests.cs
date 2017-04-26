using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player;
using Player.Models;
using Player.Presenters;
using System.Collections.Generic;

namespace PlayerTests
{
    [TestClass]
    public class PresenterSubmitBetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSubmitBetOverCreditBalance()
        {
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            int credits = 150; // Default credit balance is 100

            // Setup Players
            Common.Lib.Models.Player dealer = new Common.Lib.Models.Player();
            dealer.Name = "Dealer";
            Common.Lib.Models.Player player1 = new Common.Lib.Models.Player();
            player1.Name = "Julian";

            // Setup Players to assign to model
            List<Common.Lib.Models.Player> players = new List<Common.Lib.Models.Player>();
            players.Add(dealer);
            players.Add(player1);

            // Assign players and main player to model
            model.players = players;
            model.player = player1;

            presenter.SubmitBet(credits);
        }
        
    }
}
