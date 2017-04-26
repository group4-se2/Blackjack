using System.Windows.Forms;

namespace Player.Interfaces
{
    public interface IStartGameView
    {
        IStartGamePresenter StartGamePresenter { get; set; }
        IStartGameModel StartGameModel { get; set; }
        DialogResult ShowDialog();

        void EnableStartGame();
        void EnableJoinGame();
        void EnableUserNamePanel();
    }
}
