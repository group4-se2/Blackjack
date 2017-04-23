using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player.Presenters;
using Player.Models;
using Moq;
using Player;
using System.Reflection;

namespace PlayerTests
{
    [TestClass]
    public class PresenterSidebarTests
    {
        [TestMethod]
        public void TestUpdateSidebarForPlaceBetOption()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model,view,client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 0; // "Place Bet"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Place Bet", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForWaitingForBets()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 1; // "Waiting on bets..."

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Waiting on bets...", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForHitStand()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 2; // "Hit/Stand"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Hit/Stand", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForLoss()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 3; // "Loss"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Loss", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForBust()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 4; // "bust"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Bust", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForPush()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 5; // "Push"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Push", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForWin()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 6; // "Win"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Win", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForBlackjack()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 7; // "Blackjack"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Blackjack", result);
        }

        [TestMethod]
        public void TestUpdateSidebarForInactivity()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 8; // "Loss"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
            String result = model.gameStatusLabel;

            // Assert
            Assert.AreEqual("Inactive", result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUpdateSidebarForUnsupportedGameState()
        {
            // Arrange
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);
            Common.Lib.Interfaces.IPlayer player = new Common.Lib.Models.Player();
            int gameStatus = 10; // "Unspported Feature"

            // Act
            player.setGameStatus(gameStatus);
            presenter.UpdateSidebar(player);
        }

    }
}
