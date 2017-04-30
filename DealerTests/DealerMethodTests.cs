using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Lib.Interfaces;
using Common.Lib.Models;
using Dealer;
using System.Collections.Generic;
using System.Diagnostics;

namespace DealerTests
{
    [TestClass]
    public class DealerMethodTests
    {
        [TestMethod]
        public void TestSetPlayerFocus()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            player2.setFocus(false);
            player3.setFocus(false);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.SetPlayerFocus(player2);

            // Assert
            Assert.AreEqual(true, player2.getFocus());
        }

        [TestMethod]
        public void TestSetAllPlayerFocus()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            player2.setFocus(false);
            player3.setFocus(false);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.SetAllPlayersFocus(true);

            // Assert
            Assert.AreEqual(true, player2.getFocus());
            Assert.AreEqual(true, player3.getFocus());
        }

        [TestMethod]
        public void TestAdvanceAllPlayers()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            player2.setGameStatus(0);
            player3.setGameStatus(0);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.AdvanceAllPlayers();

            // Assert
            Assert.AreEqual(1, player2.getGameStatus());
            Assert.AreEqual(1, player3.getGameStatus());
        }

        [TestMethod]
        public void TestCheckBetsForOnePlayerWithWager()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";

            player2.setWagerAmount(10);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            sut.players = players;

            // Act
            sut.CheckBets();

            // Assert
            Assert.AreEqual(true, sut.timeoutSignal);
        }

        [TestMethod]
        public void TestCheckBetsForTwoPlayersWithWager()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            player2.setWagerAmount(10);
            player3.setWagerAmount(10);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.CheckBets();

            // Assert
            Assert.AreEqual(true, sut.timeoutSignal);
        }

        [TestMethod]
        public void TestCheckBetsForThreePlayersWithWager()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";
            IPlayer player4 = new Player();
            player3.Name = "Jim";

            player2.setWagerAmount(10);
            player3.setWagerAmount(10);
            player4.setWagerAmount(10);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            sut.players = players;

            // Act
            sut.CheckBets();

            // Assert
            Assert.AreEqual(true, sut.timeoutSignal);
        }

        [TestMethod]
        public void TestCheckBetsForFourPlayersWithWager()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";
            IPlayer player4 = new Player();
            player3.Name = "Jim";
            IPlayer player5 = new Player();
            player3.Name = "Mark";

            player2.setWagerAmount(10);
            player3.setWagerAmount(10);
            player4.setWagerAmount(10);
            player5.setWagerAmount(10);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            players.Add(player5);
            sut.players = players;

            // Act
            sut.CheckBets();

            // Assert
            Assert.AreEqual(true, sut.timeoutSignal);
        }

        [TestMethod]
        public void TestCheckBetsForTwoPlayersWithoutOneWager()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            player2.setWagerAmount(10);
            player3.setWagerAmount(0);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.CheckBets();

            // Assert
            Assert.AreEqual(false, sut.timeoutSignal);
        }

        [TestMethod]
        public void TestCheckForInactivePlayers()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            player2.setWagerAmount(0);
            player3.setWagerAmount(10);

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.CheckForInactivePlayers();

            // Assert
            Assert.AreEqual(8, player2.getGameStatus());
            Assert.AreNotEqual(8, player3.getGameStatus());
        }

        [TestMethod]
        public void TestDealFirstRoundCards()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            IDeck deck = new Deck();

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.DealFirstRoundCards(deck);

            // Assert
            Assert.AreEqual(1, player2.myHand.hand.Count);
            Assert.AreEqual(1, player3.myHand.hand.Count);
        }

        [TestMethod]
        public void TestDealSecondRoundCards()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            IDeck deck = new Deck();

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.DealFirstRoundCards(deck);
            sut.DealFirstRoundCards(deck);

            // Assert
            Assert.AreEqual(2, player2.myHand.hand.Count);
            Assert.AreEqual(2, player3.myHand.hand.Count);
        }
        
    }
}
