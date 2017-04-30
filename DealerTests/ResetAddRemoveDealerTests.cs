using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Lib.Interfaces;
using Common.Lib.Models;
using Dealer;
using System.Collections.Generic;

namespace DealerTests
{
    [TestClass]
    public class ResetAddRemoveDealerTests
    {
        [TestMethod]
        public void TestRemovePlayers()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Setup player 3 to remove
            sut.removePlayers.Add(player3);

            // Act
            sut.RemovePlayers();

            // Assert there are only two players left
            Assert.AreEqual(2, sut.players.Count);
        }

        [TestMethod]
        public void TestAddPlayers()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Setup player to add
            IPlayer player4 = new Player();
            player4.Name = "Jim";
            sut.addPlayers.Add(player4);

            // Act
            sut.AddPlayers();

            // Assert there should be four players now
            Assert.AreEqual(4, sut.players.Count);
        }

        [TestMethod]
        public void TestResetPlayers()
        {
            // Arrange
            Program2 sut = new Program2();

            IPlayer player1 = new Player();
            player1.Name = "Dealer";
            IPlayer player2 = new Player();
            player2.Name = "Julian";
            player2.setWagerAmount(50);
            IPlayer player3 = new Player();
            player3.Name = "Bob";

            // Setup initial players
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            sut.players = players;

            // Act
            sut.ResetPlayers();

            // Assert
            Assert.AreEqual(0, player2.WagerAmount);
        }
    }
}
