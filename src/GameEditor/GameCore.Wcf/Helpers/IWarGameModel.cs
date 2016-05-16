using GameCore.Wcf.Game;

namespace GameCore.Wcf.Helpers
{
    public interface IWarGameModel
    {
        //Dictionary<string, Army> Armies { get; set; }
        //Dictionary<string, ArmyCommand> ArmyCommands { get; set; }
        //Dictionary<string, ArmyGroup> ArmyGroups { get; set; }
        //Dictionary<string, Battle> Battles { get; set; }
        //Dictionary<string, Game.User> Users { get; set; }
        //Dictionary<string, Unit> Units { get; set; }

        Game.User FindUser(string username);
        void SetUser(string username, Game.User user);
        bool UsersContainsKey(string username);
        void UsersRemove(string username);
        Army GetUserArmy(string username, string id);
        Battle GetUserBattle(string username, string id);
        void BattlesAdd(string id, Battle battle);
        bool BattleContainsKey(string id);
        bool IsBattleAttacker(string id, string username);
        bool IsBattleDefender(string id, string username);
        void SetBattle(string id, Battle battle);
        void BattlesRemove(string id);
        Army FindArmy(string id);
        Armies ArmiesFindFromUser(string username);
        bool ArmiesContainsKey(string id);
        bool IsArmiesUser(string username, string id);
        void ArmiesAdd(string id, Army army);
        void ArmiesRemove(string id);
        void SetArmy(string id, Army army);
    }
}