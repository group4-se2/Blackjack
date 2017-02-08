using Interfaces;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IDeck
    {
        List<ICard> Cards { get; }
    }
}