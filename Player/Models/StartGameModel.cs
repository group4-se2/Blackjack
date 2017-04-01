using Player.Interfaces;

namespace Player.Models
{
    class StartGameModel : IStartGameModel
    {
        public Common.Lib.Interfaces.IPlayer player { get; set; }
    }
}
