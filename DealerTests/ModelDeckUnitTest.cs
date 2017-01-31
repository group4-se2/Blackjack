using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dealer.Models;

namespace DealerTests
{
    [TestClass]
    public class ModelDeckUnitTest
    {
        [TestMethod]
        public void TestCreateDeck()
        {
            //Arange
            Deck deck = new Deck();

            // Act

            // Assert
            Assert.AreEqual(52, deck.Cards.Count);
        }
        [TestMethod]
        public void TestDrawCardMethod()
        {
            // Arange
            Deck deck = new Deck();
            Card card = null;

            // Act
            card = deck.drawCard();

            // Assert
            Assert.IsNotNull(card);
        }
    }
}
