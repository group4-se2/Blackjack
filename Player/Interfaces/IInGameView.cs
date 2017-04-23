using System.Windows.Forms;

namespace Player.Interfaces
{
    public interface IInGameView
    {
        IInGamePresenter InGamePresenter { get; set; }

        DialogResult ShowDialog();

        // Updates the sidebar for the current player
        void UpdateGameStatusLabel();

        // Updates each one of the player slots
        void UpdatePlayer1();
        void UpdatePlayer2();
        void UpdatePlayer3();
        void UpdatePlayer4();

        // Updates the dealer's Card Value Count
        void UpdateDealerCount();

        // Deals the dealer's cards
        void DealDealerCards();

        // Deals the player's cards depending on player id
        void DealCards(int playerID);

        // Button enabling
        void EnableBetButtons();
        void DisableBetButtons();
        void EnableHitStandButtons();
        void DisableAllButtons();

        // Called on game round over
        void GameOver();
    }
}
