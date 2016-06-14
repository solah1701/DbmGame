using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.WcfService.DebellisMultitudinis;
using GameCore.WcfService.Exceptions;

namespace GameCore.WcfService.Helpers
{
    public class WarGameModel : IWarGameModel
    {
        private Dictionary<string, User> Users { get; set; }
        private Dictionary<int, Army> Armies { get; set; }
        private Dictionary<int, ArmyCommand> ArmyCommands { get; set; }
        private Dictionary<int, ArmyGroup> ArmyGroups { get; set; }
        private Dictionary<int, Unit> Units { get; set; }
        private Dictionary<int, Battle> Battles { get; set; }
        private Dictionary<int, ArmyDefinition> ArmyDefinitions { get; set; }
        private Dictionary<int, ArmyUnitDefinition> ArmyUnitDefinitions { get; set; }

        private IDbmModel _model;

        public WarGameModel() : this(new DbmModel()) { }

        public WarGameModel(IDbmModel model)
        {
            _model = model;
        }

        public User FindUser(string username)
        {
            return UsersContainsKey(username) ? Users[username] : null;
        }

        public void SetUser(string username, User user)
        {
            Users[username] = user;
        }

        public bool UsersContainsKey(string username)
        {
            return Users.ContainsKey(username);
        }

        public void UsersRemove(string username)
        {
            Users.Remove(username);
        }

        public Army GetUserArmy(string username, int id)
        {
            if (!Armies.ContainsKey(id) || Armies[id].User != username) return null;
            return Armies[id];
        }

        public Battle GetUserBattle(string username, int id)
        {
            if (!Battles.ContainsKey(id) ||
                (Battles[id].AttackerUser != username && Battles[id].DefenderUser != username))
                return null;
            return Battles[id];
        }

        public void BattlesAdd(int id, Battle battle)
        {
            Battles.Add(id, battle);
        }

        public bool BattlesContainsKey(int id)
        {
            return Battles.ContainsKey(id);
        }

        public bool IsBattleAttacker(int id, string username)
        {
            return Battles[id].AttackerUser == username;
        }

        public bool IsBattleDefender(int id, string username)
        {
            return Battles[id].DefenderUser == username;
        }

        public void SetBattle(int id, Battle battle)
        {
            Battles[id] = battle;
        }

        public void BattlesRemove(int id)
        {
            Battles.Remove(id);
        }

        public Army FindArmy(int id)
        {
            return ArmiesContainsKey(id) ? Armies[id] : null;
        }

        public Armies FindUserArmies(string username)
        {
            return new Armies(Armies.Values.Where(a => a.User == username).ToList());
        }

        public bool ArmiesContainsKey(int id)
        {
            return Armies.ContainsKey(id);
        }

        public bool IsArmiesUser(string username, int id)
        {
            return Armies[id].User == username;
        }

        public void ArmiesAdd(int id, Army army)
        {
            Armies.Add(id, army);
        }

        public void ArmiesRemove(int id)
        {
            Armies.Remove(id);
        }

        public void SetArmy(int id, Army army)
        {
            Armies[id] = army;
        }

        public ArmyCommand FindUserArmyCommandForArmy(string username, int id, int armyId)
        {
            return ArmyCommandsContainsKey(id) && ArmyCommands[id].User == username && ArmyCommands[id].Army == armyId ? ArmyCommands[id] : null;
        }

        public ArmyCommands FindUserArmyCommandsForArmy(string username, int armyId)
        {
            return new ArmyCommands(ArmyCommands.Values.Where(ac => ac.User == username && ac.Army == armyId).ToList());
        }

        public bool ArmyCommandsContainsKey(int id)
        {
            return ArmyCommands.ContainsKey(id);
        }

        public void SetArmyCommand(int id, ArmyCommand armyCommand)
        {
            ArmyCommands[id] = armyCommand;
        }

        public void ArmyCommandsAdd(int id, ArmyCommand armyCommand)
        {
            ArmyCommands.Add(id, armyCommand);
        }

        public void ArmyCommandsRemove(int id)
        {
            ArmyCommands.Remove(id);
        }

        public ArmyGroup FindUserArmyGroupForArmyCommand(string username, int id, int armyId, int commandId)
        {
            return ArmyGroupsContainsKey(id) && ArmyGroups[id].User == username && ArmyGroups[id].Army == armyId &&
                   ArmyGroups[id].ArmyCommand == commandId ? ArmyGroups[id] : null;
        }

        public ArmyGroups FindUserArmyGroupsForArmyCommand(string username, int armyId, int commandId)
        {
            return new ArmyGroups(ArmyGroups.Values.Where(ag => ag.User == username && ag.Army == armyId && ag.ArmyCommand == commandId).ToList());
        }

        public bool ArmyGroupsContainsKey(int id)
        {
            return ArmyGroups.ContainsKey(id);
        }

        public void SetArmyGroup(int id, ArmyGroup armyGroup)
        {
            ArmyGroups[id] = armyGroup;
        }

        public void ArmyGroupsAdd(int id, ArmyGroup armyGroup)
        {
            ArmyGroups.Add(id, armyGroup);
        }

        public void ArmyGroupsRemove(int id)
        {
            ArmyGroups.Remove(id);
        }

        public Unit FindUserArmyUnitForArmyCommand(string username, int id, int armyId, int commandId)
        {
            return ArmyUnitsContainsKey(id) && Units[id].User == username && Units[id].Army == armyId && Units[id].ArmyCommand == commandId ? Units[id] : null;
        }

        public Units FindUserArmyUnitsForArmyCommand(string username, int armyId, int commandId)
        {
            return new Units(Units.Values.Where(au => au.User == username && au.Army == armyId && au.ArmyCommand == commandId).ToList());
        }

        public Units FindUserArmyUnitsForArmyCommandGroup(string username, int armyId, int commandId, int groupId)
        {
            return new Units(Units.Values.Where(au => au.User == username && au.Army == armyId && au.ArmyCommand == commandId && au.ArmyGroup == groupId).ToList());
        }

        public bool ArmyUnitsContainsKey(int id)
        {
            return Units.ContainsKey(id);
        }

        public void SetArmyUnit(int id, Unit armyUnit)
        {
            Units[id] = armyUnit;
        }

        public void ArmyUnitsAdd(int id, Unit armyUnit)
        {
            Units.Add(id, armyUnit);
        }

        public void ArmyUnitsRemove(int id)
        {
            Units.Remove(id);
        }

        public ArmyDefinition FindArmyDefinition(int id)
        {
            if (!ArmyDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyDefinition with id = {id} does not exist");
            var definition = _model.ArmyListDefinitions.First(ald => ald.ArmyListDefinitionId == id);
            return definition.GetArmyDefinition();
        }

        public ArmyDefinitions FindArmyDefinitions()
        {
            var definitions = _model.ArmyListDefinitions.ToList();
            return definitions.GetArmyDefinitions();
        }

        public bool ArmyDefinitionsContainsKey(int id)
        {
            return _model.ArmyListDefinitions.Any(ald => ald.ArmyListDefinitionId == id);
        }

        public void SetArmyDefinition(int id, ArmyDefinition armyDefinition)
        {
            if (!ArmyDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyDefinition with id = {id} does not exist");
            _model.ArmyListDefinitions.Find(id).SetArmyListDefinition(armyDefinition);
            _model.SaveDbChanges();
        }

        public void ArmyDefinitionsAdd(ArmyDefinition armyDefinition)
        {
            //if (ArmyCommandsContainsKey(armyDefinition.Id)) throw new PrimaryKeyViolationException($"ArmyDefinition with id = {armyDefinition.Id} already exists");
            _model.ArmyListDefinitions.Add(armyDefinition.GetArmyListDefinition());
            _model.SaveDbChanges();
        }

        public void ArmyDefinitionsRemove(int id)
        {
            var definition = FindArmyDefinition(id);
            _model.ArmyListDefinitions.Remove(definition.GetArmyListDefinition());
            _model.SaveDbChanges();
        }

        public ArmyUnitDefinition FindArmyUnitDefinition(int id, int armyDefinitionId)
        {
            if (!ArmyUnitDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyUnitDefinition with id = {id} does not exist");
            var definition = _model.ArmyUnitDefinitions.First(ald => ald.ArmyUnitDefinitionId == id && ald.ArmyListDefinition.ArmyListDefinitionId == armyDefinitionId);
            return definition.GetArmyUnitDefinition();
        }

        public ArmyUnitDefinitions FindArmyUnitDefinitions(int armyDefinitionId)
        {
            var definitions = _model.ArmyUnitDefinitions.Where(aud => aud.ArmyListDefinition.ArmyListDefinitionId == armyDefinitionId).ToList();
            return definitions.GetArmyUnitDefinitions();
        }

        public bool ArmyUnitDefinitionsContainsKey(int id)
        {
            return _model.ArmyUnitDefinitions.Any(ald => ald.ArmyUnitDefinitionId == id);
        }

        public void SetArmyUnitDefinition(int id, ArmyUnitDefinition armyUnitDefinition)
        {
            if (!ArmyUnitDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyUnitDefinition with id = {id} does not exist");
            _model.ArmyUnitDefinitions.Find(id).SetArmyListUnitDefinition(armyUnitDefinition);
            _model.SaveDbChanges();
        }

        public void ArmyUnitDefinitionsAdd(int id, ArmyUnitDefinition armyUnitDefinition)
        {
            if (ArmyUnitDefinitionsContainsKey(armyUnitDefinition.Id)) throw new PrimaryKeyViolationException($"ArmyUnitDefinition with id = {armyUnitDefinition.Id} already exists");
            _model.ArmyUnitDefinitions.Add(armyUnitDefinition.GetArmyUnitDefinition());
            _model.SaveDbChanges();
        }

        public void ArmyUnitDefinitionsRemove(int id)
        {
            if (!ArmyUnitDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyUnitDefinition with id = {id} does not exist");
            var definition = _model.ArmyUnitDefinitions.First(ald => ald.ArmyUnitDefinitionId == id);
            _model.ArmyUnitDefinitions.Remove(definition);
            _model.SaveDbChanges();
        }
    }
}
