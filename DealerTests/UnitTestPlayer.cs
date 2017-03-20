using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Lib.Interfaces;
using Common.Lib.Models;

namespace DealerTests
{
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void TestMethod1()
        {
            //ARRANGE
            IPlayer testPlayer = new Player();

            //ACT
            testPlayer.dealCard(); // total - 3
            testPlayer.switchFocus(); //false
            testPlayer.debitCreditBalance(20); //80
            testPlayer.creditCreditBalance(10); //90
            testPlayer.advanceGameStatus(); //1
            testPlayer.setWagerAmount(30); //30
           
            //ASSERT
            System.Diagnostics.Trace.WriteLine((FaceValue)(testPlayer.getCard(0)).NumericValue + " of " + (testPlayer.getCard(0)).Suit);
            System.Diagnostics.Trace.WriteLine((FaceValue)(testPlayer.getCard(1)).NumericValue + " of " + (testPlayer.getCard(1)).Suit);
            System.Diagnostics.Trace.WriteLine((FaceValue)(testPlayer.getCard(2)).NumericValue + " of " + (testPlayer.getCard(2)).Suit);
            Assert.AreEqual(testPlayer.getCreditBalance(), 90);
            Assert.IsTrue(testPlayer.getFocus());
            Assert.AreEqual(testPlayer.getGameStatus(), 1);
            Assert.AreEqual(testPlayer.getWagerAmount(), 30);
            Assert.IsTrue(testPlayer.scoreHand() > 0 && testPlayer.scoreHand() < 99);
            System.Diagnostics.Trace.WriteLine("Score of hand: " + (testPlayer.scoreHand()));
        }
    }
}                  



                                                         