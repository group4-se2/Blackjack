using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player;
using Player.Models;
using Player.Presenters;
using System.Diagnostics;

namespace PlayerTests
{
    [TestClass]
    public class StartGameTest
    {
        [TestMethod]
        public void TestStartGameBtnClientConnected()
        {
            StartGameModel model = new StartGameModel();
            StartGameView view = new StartGameView();
            StartGamePresenter presenter = new StartGamePresenter(model, view);

            // Bool ClientConnected
            presenter.ClientConnected = true;
            presenter.startGameBtnClick();

            // Assert testState is "Joining Game"
            Assert.AreEqual("Joining Game", model.testState);
        }

        [TestMethod]
        public void TestStartGameBtnClientNotConnected()
        {
            StartGameModel model = new StartGameModel();
            StartGameView view = new StartGameView();
            StartGamePresenter presenter = new StartGamePresenter(model, view);

            // Bool ClientConnected
            presenter.ClientConnected = false;
            try
            {
                presenter.startGameBtnClick();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Debug.WriteLine("Cannot Launch dealer.exe from within tests");
            }

            // Assert testState is "Starting Game"
            Assert.AreEqual("Starting Game", model.testState);
        }
    }
}
