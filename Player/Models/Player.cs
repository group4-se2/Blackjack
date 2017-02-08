using Interfaces;

namespace Player.Models
{
    public class Player : IPlayer
    {
        private string name;
        private int bank;
        private int wager;
        private IHand hand;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Bank
        {
            get
            {
                return bank;
            }

            set
            {
                bank = value;
            }
        }

        public int Wager
        {
            get
            {
                return wager;
            }

            set
            {
                wager = value;
            }
        }

         public IHand Hand  
        {
            get
            {
                return hand;
            }

            set
            {
                hand = value;
            }
        }

        public void joinGame()
        { }

        public void exitGame()
        { }

        public void placeBet(int amount)
        { }

        public void requestHit()
        { }

        public void requestStand()
        { }
    }
}
