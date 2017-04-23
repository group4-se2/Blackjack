using Common.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player.Interfaces
{
    public interface IInGamePresenter
    {
        DialogResult ShowDialog();
        void UpdateView();

        void SyncClient(Command c);

        void SubmitBet(int credits);

        void HitCard();

        void Stand();

        void UpdateSidebar(Common.Lib.Interfaces.IPlayer player);

        void CheckForDealerBlackjack(Common.Lib.Interfaces.IPlayer player);

        Client client { get; set; }

        void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e);
    }
}
