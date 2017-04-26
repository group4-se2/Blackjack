using Player.Interfaces;

namespace Player.Models
{
    public class StartGameModel : IStartGameModel
    {
        public Common.Lib.Interfaces.IPlayer player { get; set; }
        public string testState { get; set; }
    }
}
