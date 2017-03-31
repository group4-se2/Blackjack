using Common.Lib.Interfaces;
using Player.Interfaces;
using System;
using System.Collections.Generic;

namespace Player.Models
{
    public class InGameModel : IInGameModel
    {

        // Players
        IPlayer p1, p2, p3, p4;
        public IList<Common.Lib.Models.Player> players { get; set; }

        public IPlayer mainPlayer { get; set; }
       

        public InGameModel()
        {

        }

        public void updatePlayer(int id, IPlayer player)
        {
            if (id == 1)
            {
                p1 = player;
            }
            else if (id == 2)
            {
                p2 = player;
            }
            else if (id == 3)
            {
                p3 = player;
            }
            else if (id == 4)
            {
                p4 = player;
            }
            else
            {
                Console.WriteLine("Error! Could not find player.");
            }
        }

        public IPlayer getPlayer(int id)
        {
            if (id == 1)
            {
                return p1;
            }
            else if (id == 2) {
                return p2;
            }
            else if (id == 3)
            {
                return p3;
            }
            else if (id == 4)
            {
                return p4;
            }

            return null;
        }
    }
}
