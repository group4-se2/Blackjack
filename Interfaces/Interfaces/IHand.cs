using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Interfaces
{
    public interface IHand
    {
        List<ICard> hand { get; set; }
        void dealCard(IDeck deck, bool faceDown);
        ICard getCard(int position);

        int length { get; set; }

        int scoreHand();

        void resetHand();
    }
}
