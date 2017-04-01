using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Lib.Interfaces;
using Common.Lib.Models;


namespace DealerTests
{
    [TestClass]
    public class UnitTestHand
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))] 
        public void TestForTwoInitialCardsInHand()
        {
            //ARRANGE
            IHand testHand = new Hand();
           
            //ACT
            ICard card1 = testHand.getCard(0);
            ICard card2 = testHand.getCard(1);
           
            //ASSERT
            Assert.IsTrue((card1 != null));
            Assert.IsTrue((card2 != null));
            System.Diagnostics.Trace.WriteLine(card1.NumericValue  + " of " + card1.Suit);
            System.Diagnostics.Trace.WriteLine(card2.NumericValue + " of " + card1.Suit);

            ICard card3 = testHand.getCard(2); // does not exist
        }

        /*[TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForFiveCardsInHand()
        {
            //ARRANGE
            IHand testHand = new Hand();
            
            testHand.dealCard();
            testHand.dealCard();
            testHand.dealCard();

            //ACT
            ICard card1 = testHand.getCard(0);
            ICard card2 = testHand.getCard(1);
            ICard card3 = testHand.getCard(2);
            ICard card4 = testHand.getCard(3);
            ICard card5 = testHand.getCard(4);
            
            //ASSERT
            Assert.IsTrue((card1 != null));
            Assert.IsTrue((card2 != null));
            Assert.IsTrue((card3 != null));
            Assert.IsTrue((card4 != null));
            Assert.IsTrue((card5 != null));

            System.Diagnostics.Trace.WriteLine((FaceValue)card1.NumericValue + " of " + card1.Suit);
            System.Diagnostics.Trace.WriteLine((FaceValue)card2.NumericValue + " of " + card2.Suit);
            System.Diagnostics.Trace.WriteLine((FaceValue)card3.NumericValue + " of " + card3.Suit);
            System.Diagnostics.Trace.WriteLine((FaceValue)card4.NumericValue + " of " + card4.Suit);
            System.Diagnostics.Trace.WriteLine((FaceValue)card5.NumericValue + " of " + card5.Suit);
            System.Diagnostics.Trace.WriteLine("Hand Score: " + testHand.scoreHand());

            testHand.dealCard(); // exceeds hand - should throw exception
        }

    */
    }
}
