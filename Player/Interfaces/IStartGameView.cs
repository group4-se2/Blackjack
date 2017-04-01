using System.Windows.Forms;

namespace Player.Interfaces
{
    interface IStartGameView
    {
        IStartGamePresenter StartGamePresenter { get; set; }
        IStartGameModel StartGameModel { get; set; }
        DialogResult ShowDialog();
    }
}
