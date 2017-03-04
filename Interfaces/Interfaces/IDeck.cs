using Common.Lib.Interfaces;
using System.Collections.Generic;

namespace Common.Lib.Interfaces
{
    //Fred will be working on this
    public interface IDeck
    {
        List<ICard> Cards { get; }
    }
}