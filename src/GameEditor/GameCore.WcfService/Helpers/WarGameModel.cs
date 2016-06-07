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
        private Dictionary<string, Army> Armies { get; set; }
        private Dictionary<string, ArmyCommand> ArmyCommands { get; set; }
        private Dictionary<string, ArmyGroup> ArmyGroups { get; set; }
        private Dictionary<string, Unit> Units { get; set; }
        private Dictionary<string, Battle> Battles { get; set; }
        private Dictionary<string, ArmyDefinition> ArmyDefinitions { get; set; }
        private Dictionary<string, ArmyUnitDefinition> ArmyUnitDefinitions { get; set; }

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

        public Army GetUserArmy(string username, string id)
        {
            if (!Armies.ContainsKey(id) || Armies[id].User != username) return null;
            return Armies[id];
        }

        public Battle GetUserBattle(string username, string id)
        {
            if (!Battles.ContainsKey(id) ||
                (Battles[id].AttackerUser != username && Battles[id].DefenderUser != username))
                return null;
            return Battles[id];
        }

        public void BattlesAdd(string id, Battle battle)
        {
            Battles.Add(id, battle);
        }

        public bool BattlesContainsKey(string id)
        {
            return Battles.ContainsKey(id);
        }

        public bool IsBattleAttacker(string id, string username)
        {
            return Battles[id].AttackerUser == username;
        }

        public bool IsBattleDefender(string id, string username)
        {
            return Battles[id].DefenderUser == username;
        }

        public void SetBattle(string id, Battle battle)
        {
            Battles[id] = battle;
        }

        public void BattlesRemove(string id)
        {
            Battles.Remove(id);
        }

        public Army FindArmy(string id)
        {
            return ArmiesContainsKey(id) ? Armies[id] : null;
        }

        public Armies FindUserArmies(string username)
        {
            return new Armies(Armies.Values.Where(a => a.User == username).ToList());
        }

        public bool ArmiesContainsKey(string id)
        {
            return Armies.ContainsKey(id);
        }

        public bool IsArmiesUser(string username, string id)
        {
            return Armies[id].User == username;
        }

        public void ArmiesAdd(string id, Army army)
        {
            Armies.Add(id, army);
        }

        public void ArmiesRemove(string id)
        {
            Armies.Remove(id);
        }

        public void SetArmy(string id, Army army)
        {
            Armies[id] = army;
        }

        public ArmyCommand FindUserArmyCommandForArmy(string username, string id, string armyId)
        {
            return ArmyCommandsContainsKey(id) && ArmyCommands[id].User == username && ArmyCommands[id].Army == armyId ? ArmyCommands[id] : null;
        }

        public ArmyCommands FindUserArmyCommandsForArmy(string username, string armyId)
        {
            return new ArmyCommands(ArmyCommands.Values.Where(ac => ac.User == username && ac.Army == armyId).ToList());
        }

        public bool ArmyCommandsContainsKey(string id)
        {
            return ArmyCommands.ContainsKey(id);
        }

        public void SetArmyCommand(string id, ArmyCommand armyCommand)
        {
            ArmyCommands[id] = armyCommand;
        }

        public void ArmyCommandsAdd(string id, ArmyCommand armyCommand)
        {
            ArmyCommands.Add(id, armyCommand);
        }

        public void ArmyCommandsRemove(string id)
        {
            ArmyCommands.Remove(id);
        }

        public ArmyGroup FindUserArmyGroupForArmyCommand(string username, string id, string armyId, string commandId)
        {
            return ArmyGroupsContainsKey(id) && ArmyGroups[id].User == username && ArmyGroups[id].Army == armyId &&
                   ArmyGroups[id].ArmyCommand == commandId ? ArmyGroups[id] : null;
        }

        public ArmyGroups FindUserArmyGroupsForArmyCommand(string username, string armyId, string commandId)
        {
            return new ArmyGroups(ArmyGroups.Values.Where(ag => ag.User == username && ag.Army == armyId && ag.ArmyCommand == commandId).ToList());
        }

        public bool ArmyGroupsContainsKey(string id)
        {
            return ArmyGroups.ContainsKey(id);
        }

        public void SetArmyGroup(string id, ArmyGroup armyGroup)
        {
            ArmyGroups[id] = armyGroup;
        }

        public void ArmyGroupsAdd(string id, ArmyGroup armyGroup)
        {
            ArmyGroups.Add(id, armyGroup);
        }

        public void ArmyGroupsRemove(string id)
        {
            ArmyGroups.Remove(id);
        }

        public Unit FindUserArmyUnitForArmyCommand(string username, string id, string armyId, string commandId)
        {
            return ArmyUnitsContainsKey(id) && Units[id].User == username && Units[id].Army == armyId && Units[id].ArmyCommand == commandId ? Units[id] : null;
        }

        public Units FindUserArmyUnitsForArmyCommand(string username, string armyId, string commandId)
        {
            return new Units(Units.Values.Where(au => au.User == username && au.Army == armyId && au.ArmyCommand == commandId).ToList());
        }

        public Units FindUserArmyUnitsForArmyCommandGroup(string username, string armyId, string commandId, string groupId)
        {
            return new Units(Units.Values.Where(au => au.User == username && au.Army == armyId && au.ArmyCommand == commandId && au.ArmyGroup == groupId).ToList());
        }

        public bool ArmyUnitsContainsKey(string id)
        {
            return Units.ContainsKey(id);
        }

        public void SetArmyUnit(string id, Unit armyUnit)
        {
            Units[id] = armyUnit;
        }

        public void ArmyUnitsAdd(string id, Unit armyUnit)
        {
            Units.Add(id, armyUnit);
        }

        public void ArmyUnitsRemove(string id)
        {
            Units.Remove(id);
        }

        public ArmyDefinition FindArmyDefinition(string id)
        {
            if (!ArmyDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyDefinition with id = {id} does not exist");
            var definition = _model.ArmyListDefinitions.First(ald => ald.ArmyListDefinitionId.ToString() == id);
            return definition.GetArmyDefinition();
        }

        public ArmyDefinitions FindArmyDefinitions()
        {
            var definitions = _model.ArmyListDefinitions.ToList();
            return definitions.GetArmyDefinitions();
        }

        public bool ArmyDefinitionsContainsKey(string id)
        {
            int localId;
            if (int.TryParse(id, out localId))
                return _model.ArmyListDefinitions.Any(ald => ald.ArmyListDefinitionId == localId);
            throw new InvalidCastException($"parameter id = {id} does not cast to an integer type");
        }

        public void SetArmyDefinition(string id, ArmyDefinition armyDefinition)
        {
            if (!ArmyDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyDefinition with id = {id} does not exist");
            _model.ArmyListDefinitions.Find(int.Parse(id)).SetArmyListDefinition(armyDefinition);
            _model.SaveDbChanges();
        }

        public void ArmyDefinitionsAdd(string id, ArmyDefinition armyDefinition)
        {
            if (ArmyCommandsContainsKey(armyDefinition.Id)) throw new PrimaryKeyViolationException($"ArmyDefinition with id = {armyDefinition.Id} already exists");
            _model.ArmyListDefinitions.Add(armyDefinition.GetArmyListDefinition());
            _model.SaveDbChanges();
        }

        public void ArmyDefinitionsRemove(string id)
        {
            var definition = FindArmyDefinition(id);
            _model.ArmyListDefinitions.Remove(definition.GetArmyListDefinition());
            _model.SaveDbChanges();
        }

        public ArmyUnitDefinition FindArmyUnitDefinition(string id, string armyDefinitionId)
        {
            if (!ArmyUnitDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyUnitDefinition with id = {id} does not exist");
            var definition = _model.ArmyUnitDefinitions.First(ald => ald.ArmyUnitDefinitionId.ToString() == id && ald.ArmyListDefinition.ArmyListDefinitionId.ToString() == armyDefinitionId);
            return definition.GetArmyUnitDefinition();
        }

        public ArmyUnitDefinitions FindArmyUnitDefinitions(string armyDefinitionId)
        {
            var definitions = _model.ArmyUnitDefinitions.Where(aud => aud.ArmyListDefinition.ArmyListDefinitionId.ToString() == armyDefinitionId).ToList();
            return definitions.GetArmyUnitDefinitions();
        }

        public bool ArmyUnitDefinitionsContainsKey(string id)
        {
            int localId;
            if (int.TryParse(id, out localId))
                return _model.ArmyUnitDefinitions.Any(ald => ald.ArmyUnitDefinitionId == localId);
            throw new InvalidCastException($"parameter id = {id} does not cast to an integer type");
        }

        public void SetArmyUnitDefinition(string id, ArmyUnitDefinition armyUnitDefinition)
        {
            if (!ArmyUnitDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyUnitDefinition with id = {id} does not exist");
            _model.ArmyUnitDefinitions.Find(int.Parse(id)).SetArmyListUnitDefinition(armyUnitDefinition);
            _model.SaveDbChanges();
        }

        public void ArmyUnitDefinitionsAdd(string id, ArmyUnitDefinition armyUnitDefinition)
        {
            if (ArmyUnitDefinitionsContainsKey(armyUnitDefinition.Id)) throw new PrimaryKeyViolationException($"ArmyUnitDefinition with id = {armyUnitDefinition.Id} already exists");
            _model.ArmyUnitDefinitions.Add(armyUnitDefinition.GetArmyUnitDefinition());
            _model.SaveDbChanges();
        }

        public void ArmyUnitDefinitionsRemove(string id)
        {
            if (!ArmyUnitDefinitionsContainsKey(id)) throw new RecordNotFoundException($"ArmyUnitDefinition with id = {id} does not exist");
            var definition = _model.ArmyUnitDefinitions.First(ald => ald.ArmyUnitDefinitionId.ToString() == id);
            _model.ArmyUnitDefinitions.Remove(definition);
            _model.SaveDbChanges();
        }
    }
}
