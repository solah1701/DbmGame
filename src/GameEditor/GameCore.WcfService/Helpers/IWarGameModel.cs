
namespace GameCore.WcfService.Helpers
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
        User FindUser(string username);
        void SetUser(string username, User user);
        bool UsersContainsKey(string username);
        void UsersRemove(string username);

        // Battles
        Battle GetUserBattle(string username, int id);
        bool BattlesContainsKey(int id);
        bool IsBattleAttacker(int id, string username);
        bool IsBattleDefender(int id, string username);
        void SetBattle(int id, Battle battle);
        void BattlesAdd(int id, Battle battle);
        void BattlesRemove(int id);

        // Armies
        Army FindArmy(int id);
        Army GetUserArmy(string username, int id);
        Armies FindUserArmies(string username);
        bool ArmiesContainsKey(int id);
        bool IsArmiesUser(string username, int id);
        void SetArmy(int id, Army army);
        void ArmiesAdd(int id, Army army);
        void ArmiesRemove(int id);

        // ArmyCommands
        ArmyCommand FindUserArmyCommandForArmy(string username, int id, int armyId);
        ArmyCommands FindUserArmyCommandsForArmy(string username, int armyId);
        bool ArmyCommandsContainsKey(int id);
        void SetArmyCommand(int id, ArmyCommand armyCommand);
        void ArmyCommandsAdd(int id, ArmyCommand armyCommand);
        void ArmyCommandsRemove(int id);

        // ArmyGroups
        ArmyGroup FindUserArmyGroupForArmyCommand(string username, int id, int armyId, int commandId);
        ArmyGroups FindUserArmyGroupsForArmyCommand(string username, int armyId, int commandId);
        bool ArmyGroupsContainsKey(int id);
        void SetArmyGroup(int id, ArmyGroup armyGroup);
        void ArmyGroupsAdd(int id, ArmyGroup armyGroup);
        void ArmyGroupsRemove(int id);

        // ArmyUnits
        Unit FindUserArmyUnitForArmyCommand(string username, int id, int armyId, int commandId);
        Units FindUserArmyUnitsForArmyCommand(string username, int armyId, int commandId);
        Units FindUserArmyUnitsForArmyCommandGroup(string username, int armyId, int commandId, int groupId);
        bool ArmyUnitsContainsKey(int id);
        void SetArmyUnit(int id, Unit armyUnit);
        void ArmyUnitsAdd(int id, Unit armyUnit);
        void ArmyUnitsRemove(int id);

        // ArmyDefinitions
        ArmyDefinition FindArmyDefinition(int id);
        ArmyDefinitions FindArmyDefinitions();
        bool ArmyDefinitionsContainsKey(int id);
        void SetArmyDefinition(int id, ArmyDefinition armyDefinition);
        void ArmyDefinitionsAdd(ArmyDefinition armyDefinition);
        void ArmyDefinitionsRemove(int id);

        // ArmyUnitDefinitions
        ArmyUnitDefinition FindArmyUnitDefinition(int id, int armyDefinitionId);
        ArmyUnitDefinitions FindArmyUnitDefinitions(int armyDefinitionId);
        bool ArmyUnitDefinitionsContainsKey(int id);
        void SetArmyUnitDefinition(int id, ArmyUnitDefinition armyUnitDefinition);
        void ArmyUnitDefinitionsAdd(int id, ArmyUnitDefinition armyUnitDefinition);
        void ArmyUnitDefinitionsRemove(int id);
    }
}