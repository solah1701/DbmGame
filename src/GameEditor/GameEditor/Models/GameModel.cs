using GameCore;

namespace GameEditor.Models
{
    public class GameModel : IGameModel
    {
        public Game Game { get; set; }

        public GameModel()
        {
            Game = new Game();
        }
    }
}
