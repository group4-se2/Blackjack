using Common.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Interfaces
{
    public interface IInGameModel
    {
        void updatePlayer(int id, IPlayer player);
        IPlayer getPlayer(int id);
    }
}
