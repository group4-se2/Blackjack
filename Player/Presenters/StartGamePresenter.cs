using Common.Lib.Models;
using Player.Interfaces;
using Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace Player.Presenters
{
    class StartGamePresenter : IStartGamePresenter
    {
        private IStartGameModel model;
        private IStartGameView view;
        private DiscoveryClient discoveryClient;
        private Client client;
        //private String clientIpAddress;
        //private String serverIpAddress;

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

        private void client_OnConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Connected");

            view.EnableUserNamePanel();
        }

        private void discoveryClient_OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            client.OnConnected += client_OnConnected;
            client.OnDataReceived += client_OnDataReceived;
            //this ipaddress is from the server
            string ipaddress = e.Data.Split(' ')[1].Split(':')[0];
            int port = int.Parse(e.Data.Split(' ')[1].Split(':')[1]);


            //string tempIP ="";

            ////this ipAddress is from this host
            //foreach (IPAddress thisIPAddress in Dns.GetHostEntry(string.Empty).AddressList)
            //{
            //    if (thisIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //    {
            //        if (thisIPAddress.ToString() == ipaddress)
            //        {
            //            Console.WriteLine("This host's IP Address: " + thisIPAddress.ToString());
            //            tempIP = thisIPAddress.ToString();
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine("Dealer IP Address: " + ipaddress);

            //if (ipaddress.ToString() == tempIP)
            //{
            //    // Enable Start Game, Disable Join Game
            //    view.EnableStartGame();
            //}
            //else
            //{
            //    // Disable Start Game, Enable Join Game
            //    view.EnableJoinGame();
            //}


            client.Connect(ipaddress, port);
            
            view.EnableJoinGame();

            //client.Send(new CommandObject() { Command = Command.Join, Payload = new Common.Lib.Models.Player() { Name = "Tim" } });
        }
        private void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            Console.WriteLine(e.CmdObject.Response.ToString());
        }

        public void OnButton1Click()
        {
            Process.Start("C:\\Users\\tws15\\Source\\Repos\\Blackjack\\Dealer\\bin\\Debug\\Dealer.exe");
        }

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
