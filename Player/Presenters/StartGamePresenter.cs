using System;
using Player.Interfaces;
using Common.Lib;
using Common.Lib.Models;

namespace Player.Presenters
{
    class StartGamePresenter : IStartGamePresenter
    {
        private IStartGameModel model;
        private IStartGameView view;
        private DiscoveryClient discoveryClient;
        private Client client;

        public StartGamePresenter(IStartGameModel model, IStartGameView view)
        {
            this.model = model;
            this.view = view;

            view.StartGamePresenter = this;

            client = new Client();

            discoveryClient = new DiscoveryClient();
            discoveryClient.OnDataReceived += discoveryClient_OnDataReceived;
            discoveryClient.Start();
        }

        private void client_OnConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Connected");
        }

        private void discoveryClient_OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            client.OnConnected += client_OnConnected;
            client.OnDataReceived += client_OnDataReceived;

            string ipaddress = e.Data.Split(' ')[1].Split(':')[0];
            int port = int.Parse(e.Data.Split(' ')[1].Split(':')[1]);

            client.Connect(ipaddress, port);
            client.Send(new CommandObject() { Command = Command.Join, Payload = new Common.Lib.Models.Player() { Name = "Tim" } });
        }
        private void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            Console.WriteLine(e.CmdObject.Response.ToString());
        }
        public void OnButton1Click()
        {
            IInGameView inGameView = new InGameView();
            inGameView.ShowDialog();
        }
        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
