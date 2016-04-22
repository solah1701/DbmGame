using GameCore.DebellisMultitudinis;

namespace GameEditor.Models
{
    public class DbmGameModel : IDbmGameModel
    {
        public DbmGame Game { get; set; }

        public DbmGameModel()
        {
            Game = new DbmGame();
        }
    }
}