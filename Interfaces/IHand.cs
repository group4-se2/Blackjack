using System.Collections.Generic;

namespace Interfaces
{
    public interface IHand
    {
        List<ICard> Cards { get; set; }
        int Score { get; set; }

        void calculateScore();
    }
}