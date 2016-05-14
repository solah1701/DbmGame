using System.Collections.Generic;
using GameCore.Wcf.Game;

namespace GameCore.Wcf.Helpers
{
    public class WarGameModel : IWarGameModel
    {
        public Dictionary<string, Game.User> Users { get; set; }
        public Dictionary<string, Army> Armies { get; set; }
        public Dictionary<string, ArmyCommand> ArmyCommands { get; set; }
        public Dictionary<string, ArmyGroup> ArmyGroups { get; set; }
        public Dictionary<string, Unit> Uunits { get; set; }
        public Dictionary<string, Battle> Battles { get; set; }

    }
}