using System;
using System.Collections.Generic;

namespace Common.Lib.Interfaces
{
    public interface IDeck
    {
        List<ICard> cards { get; }
        // ICard getCard(int position);
        ICard takeCard();
    }
}
