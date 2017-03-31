using System.Windows.Forms;

namespace Player.Interfaces
{
    public interface IInGameView
    {
        IInGamePresenter InGamePresenter { get; set; }

        DialogResult ShowDialog();
        void UpdateView();
    }
}
