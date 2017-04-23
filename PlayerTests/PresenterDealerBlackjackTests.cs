using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player;
using Player.Presenters;
using Player.Models;

namespace PlayerTests
{
    [TestClass]
    public class PresenterDealerBlackjackTests
    {
        [TestMethod]
        public void TestCheckForDealerBlackjackGameStatusNotReady()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();

            // Act
            player.setGameStatus(8); // Inactive
            presenter.CheckForDealerBlackjack(player);
            String result = model.dealerCardCount;

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestCheckForDealerBlackjackGameStatusReady()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();

            // Act
            player.setGameStatus(9); // Ready state
            presenter.CheckForDealerBlackjack(player);
            String result = model.dealerCardCount;

            // Assert
            Assert.AreEqual("Count: 0", result);
        }
        
        // Need to test the other code path, need to mock
    }
}
