using Common.Lib.Models;
using Player.Interfaces;
using Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace Player.Presenters
{
    public class StartGamePresenter : IStartGamePresenter
    {
        private IStartGameModel model;
        private IStartGameView view;
        private DiscoveryClient discoveryClient;
        private Client client;
        public bool ClientConnected = false;

        public StartGamePresenter(IStartGameModel model, IStartGameView view)
        {
            this.model = model;
            this.view = view;

            model.player = new Common.Lib.Models.Player();

            view.StartGameModel = model;
            view.StartGamePresenter = this;

            client = new Client();

            discoveryClient = new DiscoveryClient();
            discoveryClient.OnDataReceived += discoveryClient_OnDataReceived;
            discoveryClient.Start();
        }

        // Client is connected, enables the username entry panel
        private void client_OnConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Connected");
            ClientConnected = true;
            view.EnableUserNamePanel();
        }

        // If server is found, allow to join game
        private void discoveryClient_OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            client.OnConnected += client_OnConnected;
            client.OnDataReceived += client_OnDataReceived;
            // IP Address from the server
            string ipaddress = e.Data.Split(' ')[1].Split(':')[0];
            int port = int.Parse(e.Data.Split(' ')[1].Split(':')[1]);

            client.Connect(ipaddress, port);
            
            view.EnableJoinGame();
        }

        // Used to debug server/client relations
        private void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            Console.WriteLine(e.CmdObject.Response.ToString());
        }

        // Starts or Joins Game based on ClientConnected * Tested
        public void startGameBtnClick()
        {
            if (!ClientConnected)
            {
                model.testState = "Starting Game";
                Process.Start("Dealer.exe");
            }
            else
            {
                model.testState = "Joining Game";
                view.EnableUserNamePanel();
            }
        }

        // Called on go button click
        public void goButtonClick()
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Join;
            cmdObj.Players = new List<Common.Lib.Interfaces.IPlayer>();
            cmdObj.Players.Add(model.player);
            client.Send(cmdObj);

            IInGameModel inGameModel = new InGameModel();
            inGameModel.player = model.player;
            IInGameView inGameView = new InGameView(inGameModel);

            IInGamePresenter inGamePresenter = new InGamePresenter(inGameModel, inGameView, client);
            client.OnDataReceived += inGamePresenter.client_OnDataReceived;
            inGamePresenter.ShowDialog();
        }
    }
}
