using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Lib.Interfaces;
using Common.Lib.Models;

namespace DealerTests
{
    [TestClass]
    public class UnitTestCard
    {
        [TestMethod]
        public void TestCardCreation()
        {
            //ARRANGE
            Card myCard = new Card((Suit)1, 13);

            //Action

            //ASSERT
            Assert.IsTrue((int)myCard.Suit >= 0 && (int)myCard.Suit <= 3);
            Assert.IsTrue(myCard.NumericValue > 0);
            System.Diagnostics.Trace.WriteLine(myCard.NumericValue + " of " + myCard.Suit);
            Assert.IsTrue(!(myCard.IsAce));
            Assert.IsTrue(myCard.IsFaceCard);
        }
    }
}
