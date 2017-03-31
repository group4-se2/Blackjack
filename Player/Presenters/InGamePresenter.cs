using System;
using System.Windows.Forms;
using Player.Interfaces;
using Player.Models;
using System.Drawing;
using Common.Lib.Interfaces;

namespace Player.Presenters
{
    public class InGamePresenter : IInGamePresenter
    {
        IInGameModel model;
        IInGameView view;

        public InGamePresenter(IInGameModel model, IInGameView view)
        {
            this.model = model;
            this.view = view;
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

        public void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {

            // Player object retrieved from server
            IPlayer player = (Common.Lib.Models.Player)e.CmdObject.Payload;

            Console.WriteLine("Name: " + player.getCreditBalance().ToString());

            model.updatePlayer(1, player);

            view.UpdateView();
        }
    }
}
