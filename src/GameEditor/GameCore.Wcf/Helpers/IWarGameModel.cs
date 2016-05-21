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

        // Users
        Game.User FindUser(string username);
        void SetUser(string username, Game.User user);
        bool UsersContainsKey(string username);
        void UsersRemove(string username);

        // Battles
        Battle GetUserBattle(string username, string id);
        bool BattlesContainsKey(string id);
        bool IsBattleAttacker(string id, string username);
        bool IsBattleDefender(string id, string username);
        void SetBattle(string id, Battle battle);
        void BattlesAdd(string id, Battle battle);
        void BattlesRemove(string id);

        // Armies
        Army FindArmy(string id);
        Army GetUserArmy(string username, string id);
        Armies FindUserArmies(string username);
        bool ArmiesContainsKey(string id);
        bool IsArmiesUser(string username, string id);
        void SetArmy(string id, Army army);
        void ArmiesAdd(string id, Army army);
        void ArmiesRemove(string id);

        // ArmyCommands
        ArmyCommand FindUserArmyCommandForArmy(string username, string id, string armyId);
        ArmyCommands FindUserArmyCommandsForArmy(string username, string armyId);
        bool ArmyCommandsContainsKey(string id);
        void SetArmyCommand(string id, ArmyCommand armyCommand);
        void ArmyCommandsAdd(string id, ArmyCommand armyCommand);
        void ArmyCommandsRemove(string id);

        // ArmyGroups
        ArmyGroup FindArmyGroup(string id);
        ArmyGroups FindUserArmyGroups(string username);
        bool ArmyGroupsContainsKey(string id);
        void SetArmyGroup(string id, ArmyGroup armyGroup);
        void ArmyGroupsAdd(string id, ArmyGroup armyGroup);
        void ArmyGroupsRemove(string id);

        // ArmyUnits
        Unit FindArmyUnit(string id);
        Units FindUserArmyUnits(string username);
        bool ArmyUnitsContainsKey(string id);
        void SetArmyUnit(string id, Unit armyUnit);
        void ArmyUnitsAdd(string id, Unit armyUnit);
        void ArmyUnitsRemove(string id);
    }
}