using System.Windows.Forms;

namespace Player.Interfaces
{
    interface IStartGameView
    {
        IStartGamePresenter StartGamePresenter { get; set; }

        void UpdateView();
        DialogResult ShowDialog();
    }
}
