using System.Collections.Generic;

namespace Common.Lib.Interfaces
{
    public interface IHand
    {
        List<ICard> Cards { get; set; }
        int Score { get; set; }

        void calculateScore();
    }
}