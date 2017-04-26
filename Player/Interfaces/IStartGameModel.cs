using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Interfaces
{
    public interface IStartGameModel
    {
        Common.Lib.Interfaces.IPlayer player { get; set; }
        String testState { get; set; }
    }
}
