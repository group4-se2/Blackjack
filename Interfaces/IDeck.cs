using Interfaces;
using System.Collections.Generic;

namespace Interfaces
{
    //Fred will be working on this
    public interface IDeck
    {
        List<ICard> Cards { get; }
    }
}