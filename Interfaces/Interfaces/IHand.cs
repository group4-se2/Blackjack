using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Interfaces
{
    public interface IHand
    {
        void dealCard();
        ICard getCard(int position);

        int scoreHand();
    }
}
