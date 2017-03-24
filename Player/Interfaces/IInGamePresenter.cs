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
        void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e);
    }
}
