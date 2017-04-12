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

        //unneeded complexity
        public void OnCardShoeClick()
        {

            
        }

        // Allows player to submit bet
        public void SubmitBet(int credits)
        {
            if (model.player.getCreditBalance() >= credits)
            {
                model.player.setWagerAmount(credits);
                SyncClient(Command.Bet);
            }
            else
            {
                // Update View with Error Dialog Later
            }

        }
        

        public void SyncClient(Command c)
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = c;
            cmdObj.Payload = model.player;
            client.Send(cmdObj);
        }

        public void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            
            // Player object retrieved from server
            model.players = (List<Common.Lib.Models.Player>)e.CmdObject.Payload;
            
            Console.WriteLine("Player info retrieved from Server:");

            
            foreach (Common.Lib.Interfaces.IPlayer player in model.players)
            {
                Console.WriteLine("Name: " + player.Name);
                //Console.WriteLine("Bet Amount: " + player.getWagerAmount().ToString());
                //Console.WriteLine("Credit Balance: " + player.getCreditBalance().ToString());
            }
            
            view.UpdateView();
        }
    }
}
