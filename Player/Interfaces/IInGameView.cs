using System.Windows.Forms;

namespace Player.Interfaces
{
    public interface IInGameView
    {
        DialogResult ShowDialog();
        void UpdateView();
    }
}
