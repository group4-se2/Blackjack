using System;
using System.Windows.Forms;
using Player.Interfaces;
using Player.Models;
using System.Drawing;
using Common.Lib.Interfaces;
using System.Collections.Generic;
using Common.Lib.Models;

namespace Player.Presenters
{
    public class InGamePresenter : IInGamePresenter
    {
        IInGameModel model;
        IInGameView view;
        public Client client { get; set; }

        public InGamePresenter(IInGameModel model, IInGameView view, Client client)
        {
            this.model = model;
            this.view = view;
            this.client = client;

            view.InGamePresenter = this;
        }
        
        public DialogResult ShowDialog()
        {
            return view.ShowDialog();
        }

        public void UpdateView()
        {
            // Update everything here

            throw new NotImplementedException();
        }

        public void OnCardShoeClick()
        {

            
        }

        public void TestMethod()
        {

            /*Common.Lib.Models.Player p = new Common.Lib.Models.Player();
            p.Name = "Julian Loftis";

            Console.WriteLine("Test Method works!");
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Join;
            cmdObj.Payload = p;

            //server.Send("Tim", cmdObj); 
            client.Send(cmdObj);
            */
        }

        public void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            /*
            // Player object retrieved from server
            model.players = (List<Common.Lib.Models.Player>)e.CmdObject.Payload;
            
            foreach (Common.Lib.Interfaces.IPlayer player in model.players)
            {
                Console.WriteLine("Name: " + player.Name);
            }
            */
            //Console.WriteLine("Name: " + player.getCreditBalance().ToString());

            //model.updatePlayer(1, player);

            view.UpdateView();
        }
    }
}
