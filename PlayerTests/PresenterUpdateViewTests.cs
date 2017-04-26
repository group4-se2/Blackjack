using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player;
using Player.Models;
using Player.Presenters;
using System.Collections.Generic;

namespace PlayerTests
{
    [TestClass]
    public class PresenterUpdateViewTests
    {
        [TestMethod]
        public void TestUpdateViewforDealerCards()
        {
            // Create Model, View, Client, and Presenter
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);

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

            // Act
            presenter.TestableUpdateView(model.players);

            // Assert 
            Assert.AreEqual("Dealer requested cards Player (Julian) is current player", model.testMessage);
        }

        [TestMethod]
        public void TestUpdateViewforPlayer1Cards()
        {
            // Create Model, View, Client, and Presenter
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);

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

            // Act
            presenter.TestableUpdateView(model.players);

            // Assert (Make sure cardDealPlayerID is equal to 1)
            Assert.AreEqual(1, model.cardDealPlayerID);
        }

        [TestMethod]
        public void TestUpdateViewforPlayer2Cards()
        {
            // Create Model, View, Client, and Presenter
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);

            // Setup Players
            Common.Lib.Models.Player dealer = new Common.Lib.Models.Player();
            dealer.Name = "Dealer";
            Common.Lib.Models.Player player1 = new Common.Lib.Models.Player();
            player1.Name = "Julian";
            Common.Lib.Models.Player player2 = new Common.Lib.Models.Player();
            player2.Name = "Bob";

            // Setup Players to assign to model
            List<Common.Lib.Models.Player> players = new List<Common.Lib.Models.Player>();
            players.Add(dealer);
            players.Add(player1);
            players.Add(player2);

            // Assign players and main player to model
            model.players = players;
            model.player = player1;

            // Act
            presenter.TestableUpdateView(model.players);

            // Assert (Make sure cardDealPlayerID is equal to 2)
            Assert.AreEqual(2, model.cardDealPlayerID);
        }

        [TestMethod]
        public void TestUpdateViewforPlayer3Cards()
        {
            // Create Model, View, Client, and Presenter
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);

            // Setup Players
            Common.Lib.Models.Player dealer = new Common.Lib.Models.Player();
            dealer.Name = "Dealer";
            Common.Lib.Models.Player player1 = new Common.Lib.Models.Player();
            player1.Name = "Julian";
            Common.Lib.Models.Player player2 = new Common.Lib.Models.Player();
            player2.Name = "Bob";
            Common.Lib.Models.Player player3 = new Common.Lib.Models.Player();
            player3.Name = "John";

            // Setup Players to assign to model
            List<Common.Lib.Models.Player> players = new List<Common.Lib.Models.Player>();
            players.Add(dealer);
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Assign players and main player to model
            model.players = players;
            model.player = player1;

            // Act
            presenter.TestableUpdateView(model.players);

            // Assert (Make sure cardDealPlayerID is equal to 3)
            Assert.AreEqual(3, model.cardDealPlayerID);
        }

        [TestMethod]
        public void TestUpdateViewforPlayer4Cards()
        {
            // Create Model, View, Client, and Presenter
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);

            // Setup Players
            Common.Lib.Models.Player dealer = new Common.Lib.Models.Player();
            dealer.Name = "Dealer";
            Common.Lib.Models.Player player1 = new Common.Lib.Models.Player();
            player1.Name = "Julian";
            Common.Lib.Models.Player player2 = new Common.Lib.Models.Player();
            player2.Name = "Bob";
            Common.Lib.Models.Player player3 = new Common.Lib.Models.Player();
            player3.Name = "John";
            Common.Lib.Models.Player player4 = new Common.Lib.Models.Player();
            player4.Name = "Mark";

            // Setup Players to assign to model
            List<Common.Lib.Models.Player> players = new List<Common.Lib.Models.Player>();
            players.Add(dealer);
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            // Assign players and main player to model
            model.players = players;
            model.player = player1;

            // Act
            presenter.TestableUpdateView(model.players);

            // Assert (Make sure cardDealPlayerID is equal to 4)
            Assert.AreEqual(4, model.cardDealPlayerID);
        }

        [TestMethod]
        public void TestUpdateViewforCurrentPlayertoUpdateSidebar()
        {
            // Create Model, View, Client, and Presenter
            InGameModel model = new InGameModel();
            InGameView view = new InGameView(model);
            Client client = new Client();
            InGamePresenter presenter = new InGamePresenter(model, view, client);

            // Setup Players
            Common.Lib.Models.Player dealer = new Common.Lib.Models.Player();
            dealer.Name = "Dealer";
            Common.Lib.Models.Player player1 = new Common.Lib.Models.Player();
            player1.Name = "Julian"; // Current Player
            Common.Lib.Models.Player player2 = new Common.Lib.Models.Player();
            player2.Name = "Bob";
            Common.Lib.Models.Player player3 = new Common.Lib.Models.Player();
            player3.Name = "John";
            Common.Lib.Models.Player player4 = new Common.Lib.Models.Player();
            player4.Name = "Mark";

            // Setup Players to assign to model
            List<Common.Lib.Models.Player> players = new List<Common.Lib.Models.Player>();
            players.Add(dealer);
            players.Add(player1); // Current Player
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            // Assign players and main player to model
            model.players = players;
            model.player = player1; // Current Player

            // Act
            presenter.TestableUpdateView(model.players);

            // Assert (Make sure UpdateView recognizes the current player)
            Assert.AreEqual("Dealer requested cards Player (Julian) is current player", model.testMessage);
        }


    }
}
