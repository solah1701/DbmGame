using System.Collections.Generic;
using GameCore.Wcf.Game;

namespace GameCore.Wcf.Helpers
{
    public interface IWarGameModel
    {
        Dictionary<string, Army> Armies { get; set; }
        Dictionary<string, ArmyCommand> ArmyCommands { get; set; }
        Dictionary<string, ArmyGroup> ArmyGroups { get; set; }
        Dictionary<string, Battle> Battles { get; set; }
        Dictionary<string, Game.User> Users { get; set; }
        Dictionary<string, Unit> Uunits { get; set; }
    }
}