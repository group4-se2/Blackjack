using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealer.Models
{
    public interface IPlayer
    {
        Hand Hand { get; set; }
        string Name { get; set; }
    }
}