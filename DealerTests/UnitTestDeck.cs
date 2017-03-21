using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Lib.Interfaces;
using Common.Lib.Models;

namespace DealerTests
{
    [TestClass]
    public class UnitTestDeck
    {
        [TestMethod]
        public void TestDeckCreation()
        {
            //ARRANGE
            IDeck deck = new Deck();
            
            //ACT
            ICard myCard = deck.cards[1];

            //ASSERT
            Assert.IsTrue(myCard.NumericValue > 0);
            Assert.IsTrue((int)myCard.Suit >= 0 && (int)myCard.Suit <= 3);
            System.Diagnostics.Trace.WriteLine(myCard.NumericValue + " of " + myCard.Suit);
        }
    }
}
