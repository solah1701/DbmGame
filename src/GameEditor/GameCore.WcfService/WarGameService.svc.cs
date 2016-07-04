using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using GameCore.WcfService.DebellisMultitudinis;
using GameCore.WcfService.Helpers;

namespace GameCore.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DbmGameService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DbmGameService.svc or DbmGameService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class WarGameService : IWarGameService
    {
        private readonly IWarGameModel _model;
        private const string Host = "localhost";

        public WarGameService()
        {
            _model = new WarGameModel();
        }

        public WarGameService(IWarGameModel model)
        {
            _model = model;
        }

        public User GetUser(string username)
        {
            username = username.ToLower();
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return null;
            }
            var user = _model.FindUser(username);
            if (user != null)
            {
                SetStatusOk();
                return user;
            }
            SetStatusNotFound();
            return null;
        }

        public void PutUser(string username, User user)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var aUser = _model.FindUser(username);
            if (aUser == null)
                SetStatusCreated(userLink);
            else if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            user.IdLink = userLink;
            user.BattlesLink = GetUserBattlesLink(username);
            user.ArmiesLink = GetUserArmiesLink(username);
            _model.SetUser(username, user);
            SetStatusOk();
        }

        public void DeleteUser(string username)
        {
            if (_model.UsersContainsKey(username)) _model.UsersRemove(username);
        }

        //public UserProfile GetUserProfile(string username)
        //{
        //    username = username.ToLower();
        //    var user = _model.FindUser(username);
        //    if (user != null)
        //    {
        //        SetStatusOk();
        //        return new UserProfile(user);
        //    }
        //    SetStatusNotFound();
        //    return null;
        //}

        public Battle GetBattle(string username, int id)
        {
            var battle = _model.GetUserBattle(username, id);
            if (battle == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return battle;
        }

        public void PostBattle(string username, string defendername, Battle battle)
        {
            if (!_model.BattlesContainsKey(battle.Id) && _model.UsersContainsKey(username) && _model.UsersContainsKey(defendername))
            {
                battle.AttackerUser = username;
                battle.DefenderUser = defendername;
                _model.BattlesAdd(battle.Id, battle);
                SetStatusOk();
                return;
            }
            SetStatusCode(HttpStatusCode.NotModified);
        }

        public void PutBattle(string username, string defendername, int id, Battle battle)
        {
            if (_model.BattlesContainsKey(id) && _model.IsBattleAttacker(id, username) &&
                _model.IsBattleDefender(id, defendername))
            {
                _model.SetBattle(id, battle);
                SetStatusOk();
                return;
            }
            SetStatusCode(HttpStatusCode.NotModified);
        }

        public void DeleteBattle(string username, string defendername, int id)
        {
            if (_model.BattlesContainsKey(id))
            {
                _model.BattlesRemove(id);
                SetStatusOk();
                return;
            }
            SetStatusCode(HttpStatusCode.NotModified);
        }

        public Armies GetUserArmies(string username, string tag)
        {
            var armies = _model.FindUserArmies(username);
            if (!armies.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new Armies(armies);
        }

        public Army GetArmy(string username, int id)
        {
            var army = _model.GetUserArmy(username, id);
            if (army == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return army;
        }

        public void PostArmy(string username, Army army)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, army.Id);
            var aArmy = _model.FindArmy(army.Id);
            if (aArmy == null)
                SetStatusCreated(armyLink);
            else if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            army.User = username;
            army.UserLink = userLink;
            army.IdLink = armyLink;
            army.ArmyCommandsLink = GetUserArmyCommandsLink(username, army.Id);
            if (_model.ArmiesContainsKey(army.Id))
                _model.SetArmy(army.Id, army);
            else
                _model.ArmiesAdd(army.Id, army);
            SetStatusOk();
        }

        public void PutArmy(string username, int id, Army army)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, id);
            var aArmy = _model.FindArmy(id);
            if (aArmy == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            aArmy.User = username;
            aArmy.UserLink = userLink;
            aArmy.IdLink = armyLink;
            aArmy.ArmyCommandsLink = GetUserArmyCommandsLink(username, id);
            if (_model.ArmiesContainsKey(id))
                _model.SetArmy(id, army);
            else
            {
                SetStatusNotFound();
                return;
            }
            SetStatusOk();
        }

        public void DeleteArmy(string username, int id)
        {
            username = username.ToLower();
            var army = _model.FindArmy(id);
            if (army == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username) || !_model.IsArmiesUser(username, id))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            _model.ArmiesRemove(id);
            SetStatusOk();
        }

        public ArmyCommands GetUserArmyCommands(string username, int armyId, string tag)
        {
            var armyCommands = _model.FindUserArmyCommandsForArmy(username, armyId);
            if (armyCommands != null && !armyCommands.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new ArmyCommands(armyCommands);
        }

        public ArmyCommand GetArmyCommand(string username, int armyId, int id)
        {
            var armyCommand = _model.FindUserArmyCommandForArmy(username, id, armyId);
            if (armyCommand == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return armyCommand;
        }

        public void PostArmyCommand(string username, int armyId, ArmyCommand armyCommand)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, armyId);
            var armyGroupsLink = GetUserArmyGroupsLink(username, armyId, armyCommand.Id);
            var armyCommandLink = GetUserArmyCommandsLink(username, armyId, armyCommand.Id);
            var command = _model.FindUserArmyCommandForArmy(username, armyCommand.Id, armyId);
            if (command == null) SetStatusCreated(armyCommandLink);
            else if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            armyCommand.User = username;
            armyCommand.UserLink = userLink;
            armyCommand.IdLink = armyCommandLink;
            armyCommand.ArmyLink = armyLink;
            armyCommand.ArmyGroupsLink = armyGroupsLink;
            if (_model.ArmyCommandsContainsKey(armyCommand.Id)) _model.SetArmyCommand(armyCommand.Id, armyCommand);
            else _model.ArmyCommandsAdd(armyCommand.Id, armyCommand);
            SetStatusOk();
        }

        public void PutArmyCommand(string username, int armyId, int id, ArmyCommand armyCommand)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, armyId);
            var armyGroupsLink = GetUserArmyGroupsLink(username, armyId, armyCommand.Id);
            var armyCommandLink = GetUserArmyCommandsLink(username, armyId, armyCommand.Id);
            var command = _model.FindUserArmyCommandForArmy(username, armyCommand.Id, armyId);
            if (command == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            armyCommand.User = username;
            armyCommand.UserLink = userLink;
            armyCommand.IdLink = armyCommandLink;
            armyCommand.ArmyLink = armyLink;
            armyCommand.ArmyGroupsLink = armyGroupsLink;
            if (_model.ArmyCommandsContainsKey(armyCommand.Id)) _model.SetArmyCommand(armyCommand.Id, armyCommand);
            else
            {
                SetStatusNotFound();
                return;
            }
            SetStatusOk();
        }

        public void DeleteArmyCommand(string username, int armyId, int id)
        {
            username = username.ToLower();
            var armyCommand = _model.FindUserArmyCommandForArmy(username, id, armyId);
            if (armyCommand == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            _model.ArmyCommandsRemove(id);
            SetStatusOk();
        }

        public ArmyGroups GetUserArmyGroups(string username, int armyId, int commandId, string tag)
        {
            var armyGroups = _model.FindUserArmyGroupsForArmyCommand(username, armyId, commandId);
            if (armyGroups != null && !armyGroups.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new ArmyGroups(armyGroups);
        }

        public ArmyGroup GetArmyGroup(string username, int armyId, int commandId, int id)
        {
            var armyGroup = _model.FindUserArmyGroupForArmyCommand(username, id, armyId, commandId);
            if (armyGroup == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return armyGroup;
        }

        public void PostArmyGroup(string username, int armyId, int commandId, ArmyGroup armyGroup)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, armyId);
            var armyGroupLink = GetUserArmyGroupsLink(username, armyId, armyGroup.Id);
            var armyCommandsLink = GetUserArmyCommandsLink(username, armyId, armyGroup.ArmyCommand);
            var group = _model.FindUserArmyGroupForArmyCommand(username, armyGroup.Id, armyId, commandId);
            if (group == null) SetStatusCreated(armyGroupLink);
            else if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            armyGroup.User = username;
            armyGroup.UserLink = userLink;
            armyGroup.Army = armyId;
            armyGroup.ArmyLink = armyLink;
            armyGroup.ArmyCommand = commandId;
            armyGroup.ArmyCommandLink = armyCommandsLink;
            armyGroup.IdLink = armyGroupLink;
            if (_model.ArmyGroupsContainsKey(armyGroup.Id)) _model.SetArmyGroup(armyGroup.Id, armyGroup);
            else _model.ArmyGroupsAdd(armyGroup.Id, armyGroup);
            SetStatusOk();
        }

        public void PutArmyGroup(string username, int armyId, int commandId, int id, ArmyGroup armyGroup)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, armyId);
            var armyGroupLink = GetUserArmyGroupsLink(username, armyId, armyGroup.Id);
            var armyCommandsLink = GetUserArmyCommandsLink(username, armyId, armyGroup.ArmyCommand);
            var group = _model.FindUserArmyGroupForArmyCommand(username, armyGroup.Id, armyId, commandId);
            if (group == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            armyGroup.User = username;
            armyGroup.UserLink = userLink;
            armyGroup.Army = armyId;
            armyGroup.ArmyLink = armyLink;
            armyGroup.ArmyCommand = commandId;
            armyGroup.ArmyCommandLink = armyCommandsLink;
            armyGroup.IdLink = armyGroupLink;
            if (_model.ArmyGroupsContainsKey(armyGroup.Id)) _model.SetArmyGroup(armyGroup.Id, armyGroup);
            else
            {
                SetStatusNotFound();
                return;
            }
            SetStatusOk();
        }

        public void DeleteArmyGroup(string username, int armyId, int commandId, int id)
        {
            username = username.ToLower();
            var armyGroup = _model.FindUserArmyGroupForArmyCommand(username, id, armyId, commandId);
            if (armyGroup == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            _model.ArmyGroupsRemove(id);
            SetStatusOk();
        }

        public Units GetUserArmyUnits(string username, int armyId, int commandId, string tag)
        {
            var armyUnits = _model.FindUserArmyUnitsForArmyCommand(username, armyId, commandId);
            if (armyUnits != null && !armyUnits.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new Units(armyUnits);
        }

        public Units GetUserArmyGroupUnits(string username, int armyId, int commandId, int groupId, string tag)
        {
            var armyUnits = _model.FindUserArmyUnitsForArmyCommandGroup(username, armyId, commandId, groupId);
            if (armyUnits != null && !armyUnits.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new Units(armyUnits);
        }

        public Unit GetArmyUnit(string username, int armyId, int commandId, int id)
        {
            var armyUnit = _model.FindUserArmyUnitForArmyCommand(username, id, armyId, commandId);
            if (armyUnit == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return armyUnit;
        }

        public void PostArmyUnit(string username, int armyId, int commandId, Unit unit)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, armyId);
            //var armyGroupLink = GetUserArmyGroupsLink(username, armyId, armyGroup.Id);
            var armyUnitLink = GetUnitLink(username, armyId, commandId, unit.Id);
            var armyCommandsLink = GetUserArmyCommandsLink(username, armyId, commandId);
            var armyUnit = _model.FindUserArmyUnitForArmyCommand(username, unit.Id, armyId, commandId);
            if (armyUnit == null) SetStatusCreated(armyUnitLink);
            else if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            unit.User = username;
            unit.UserLink = userLink;
            unit.Army = armyId;
            unit.ArmyLink = armyLink;
            unit.ArmyCommand = commandId;
            unit.ArmyCommandLink = armyCommandsLink;
            unit.IdLink = armyUnitLink;
            if (_model.ArmyUnitsContainsKey(unit.Id)) _model.SetArmyUnit(unit.Id, armyUnit);
            else _model.ArmyUnitsAdd(unit.Id, armyUnit);
            SetStatusOk();
        }

        public void PutArmyUnit(string username, int armyId, int commandId, int id, Unit unit)
        {
            username = username.ToLower();
            var userLink = GetUserLink(username);
            var armyLink = GetUserArmiesLink(username, armyId);
            //var armyGroupLink = GetUserArmyGroupsLink(username, armyId, armyGroup.Id);
            var armyUnitLink = GetUnitLink(username, armyId, commandId, unit.Id);
            var armyCommandsLink = GetUserArmyCommandsLink(username, armyId, commandId);
            var armyUnit = _model.FindUserArmyUnitForArmyCommand(username, unit.Id, armyId, commandId);
            if (armyUnit == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            unit.User = username;
            unit.UserLink = userLink;
            unit.Army = armyId;
            unit.ArmyLink = armyLink;
            unit.ArmyCommand = commandId;
            unit.ArmyCommandLink = armyCommandsLink;
            unit.IdLink = armyUnitLink;
            if (_model.ArmyUnitsContainsKey(unit.Id)) _model.SetArmyUnit(unit.Id, armyUnit);
            else
            {
                SetStatusNotFound();
                return;
            }
            SetStatusOk();
        }

        public void DeleteArmyUnit(string username, int armyId, int commandId, int id)
        {
            username = username.ToLower();
            var armyUnit = _model.FindUserArmyUnitForArmyCommand(username, id, armyId, commandId);
            if (armyUnit == null)
            {
                SetStatusNotFound();
                return;
            }
            if (!IsUserAuthorized(username))
            {
                SetStatusCode(HttpStatusCode.Unauthorized);
                return;
            }
            _model.ArmyUnitsRemove(id);
            SetStatusOk();
        }

        public ArmyDefinitions GetArmyDefinitions()
        {
            using (var db = new DbmModel())
            {
                var armyDefinitions = db.ArmyListDefinitions.ToList().GetArmyDefinitions();
                if (!armyDefinitions.Any())
                {
                    SetStatusNotFound();
                    return null;
                }
                SetStatusOk();
                return new ArmyDefinitions(armyDefinitions);
            }
        }

        public ArmyDefinition GetArmyDefinition(int id)
        {
            using (var db = new DbmModel())
            {
                var armyDefinition = db.ArmyListDefinitions.Find(id).GetArmyDefinition();
                if (armyDefinition == null)
                {
                    SetStatusNotFound();
                    return null;
                }
                SetStatusOk();
                return armyDefinition;
            }
        }

        public ArmyDefinition GetArmyDefinitionByName(string name)
        {
            using (var db = new DbmModel())
            {
                var definition = db.ArmyListDefinitions.First(armyList => armyList.Name == name).GetArmyDefinition();
                if (definition == null)
                {
                    SetStatusNotFound();
                    return null;
                }
                SetStatusOk();
                return definition;
            }
        }

        public int PostArmyDefinition(ArmyDefinition armyDefinition)
        {
            using (var db = new DbmModel())
            {
                var armyList = armyDefinition.GetArmyListDefinition();
                db.ArmyListDefinitions.Add(armyList);
                db.SaveChanges();
                SetStatusOk();
                return armyList.ArmyListDefinitionId;
            }
        }

        public int PutArmyDefinition(ArmyDefinition armyDefinition)
        {
            if (armyDefinition.Id == 0) return PostArmyDefinition(armyDefinition);
            using (var db = new DbmModel())
            {
                var armyDef = armyDefinition.UpdateArmyListDefinition(db.ArmyListDefinitions.Find(armyDefinition.Id));
                db.ArmyListDefinitions.Attach(armyDef);
                db.Entry(armyDef).State = EntityState.Modified;
                db.SaveChanges();
                SetStatusOk();
                return armyDef.ArmyListDefinitionId;
            }
        }

        public void DeleteArmyDefinition(int id)
        {
            using (var db = new DbmModel())
            {
                var item = db.ArmyListDefinitions.Find(id);
                if (item == null) return;
                db.ArmyListDefinitions.Remove(item);
                db.SaveChanges();
                SetStatusOk();
            }
        }

        public ArmyUnitDefinitions GetArmyUnitDefinitions(int armyDefinitionId)
        {
            using (var db = new DbmModel())
            {
                var unitDefinitions = db.ArmyListDefinitions.Find(armyDefinitionId).ArmyListUnitDefinitions.ToList().GetArmyUnitDefinitions();
                SetStatusOk();
                return !unitDefinitions.Any() ? new ArmyUnitDefinitions() : unitDefinitions;
            }
        }

        public ArmyUnitDefinition GetArmyUnitDefinition(int armyDefinitionId, int id)
        {
            using (var db = new DbmModel())
            {
                var unitDefinition =
                    db.ArmyListDefinitions.Find(armyDefinitionId)
                        .ArmyListUnitDefinitions.Find(u => u.ArmyUnitDefinitionId == id)
                        .GetArmyUnitDefinition();
                if (unitDefinition == null)
                {
                    SetStatusNotFound();
                    return null;
                }
                SetStatusOk();
                return unitDefinition;
            }
        }

        public int PostArmyUnitDefinition(int armyDefinitionId, ArmyUnitDefinition armyUnitDefinition)
        {
            using (var db = new DbmModel())
            {
                var armyList = db.ArmyListDefinitions.Find(armyDefinitionId);
                if (armyList == null)
                {
                    SetStatusNotFound();
                    return 0;
                }
                var armyUnit = armyUnitDefinition.GetArmyUnitDefinition();
                armyList.ArmyListUnitDefinitions.Add(armyUnit);
                db.ArmyUnitDefinitions.Add(armyUnit);
                db.SaveChanges();
                SetStatusOk();
                return armyUnit.ArmyUnitDefinitionId;
            }
        }

        public int PutArmyUnitDefinition(int armyDefinitionId, int id, ArmyUnitDefinition armyUnitDefinition)
        {
            if (armyUnitDefinition.Id == 0) return PostArmyUnitDefinition(armyDefinitionId, armyUnitDefinition);
            using (var db = new DbmModel())
            {
                var armyUnit =
                    armyUnitDefinition.UpdateArmyUnitDefinition(db.ArmyUnitDefinitions.Find(armyUnitDefinition.Id));
                db.ArmyUnitDefinitions.Attach(armyUnit);
                db.Entry(armyUnit).State = EntityState.Modified;
                db.SaveChanges();
                SetStatusOk();
                return armyUnit.ArmyUnitDefinitionId;
            }
        }

        public void DeleteArmyUnitDefinition(int armyDefinitionId, int id)
        {
            using (var db = new DbmModel())
            {
                var armyDef = db.ArmyUnitDefinitions.Find(id);
                if (armyDef == null) return;
                db.ArmyUnitDefinitions.Remove(armyDef);
                db.SaveChanges();
                SetStatusOk();
            }
        }

        public AlliedArmyDefinitions GetAlliedArmyDefinitions(int armyDefinitionId)
        {
            using (var db = new DbmModel())
            {
                var definitions =
                    db.ArmyListDefinitions.Find(armyDefinitionId)
                        .AlliedArmyListDefinitions.ToList()
                        .GetAlliedArmyDefinitions();
                SetStatusOk();
                return !definitions.Any() ? new AlliedArmyDefinitions() : definitions;
            }
        }

        public AlliedArmyDefinitions GetAllAlliedArmyDefinitions()
        {
            using (var db = new DbmModel())
            {
                var definitions = db.AlliedArmyListDefinitions.ToList().GetAlliedArmyDefinitions();
                SetStatusOk();
                return !definitions.Any() ? new AlliedArmyDefinitions() : definitions;
            }
        }

        public ArmyDefinitions GetArmyDefinitionsForPeriod(int id, int minDate, int maxDate)
        {
            using (var db = new DbmModel())
            {
                //                 return MinDate >= min && MinDate <= max || MinDate <= min && MaxDate >= min;
                var definitions =
                    db.ArmyListDefinitions.Where(armyList => armyList.ArmyListDefinitionId != id && armyList.MinYear >= minDate && armyList.MinYear <= maxDate || armyList.MinYear <= minDate && armyList.MaxYear >= minDate)
                        .ToList()
                        .GetArmyDefinitions();
                SetStatusOk();
                return !definitions.Any() ? new ArmyDefinitions() : definitions;
            }
        }

        public AlliedArmyDefinition GetAlliedArmyDefinition(int armyDefinitionId, int id)
        {
            using (var db = new DbmModel())
            {
                var definition =
                    db.ArmyListDefinitions.Find(armyDefinitionId)
                        .AlliedArmyListDefinitions.Find(a => a.AlliedArmyListDefinitionId == id)
                        .GetAlliedArmyDefinition();
                if (definition == null)
                {
                    SetStatusNotFound();
                    return null;
                }
                SetStatusOk();
                return definition;
            }
        }

        public int PostAlliedArmyDefinition(int armyDefinitionId, AlliedArmyDefinition alliedArmyDefinition)
        {
            using (var db = new DbmModel())
            {
                var armyList = db.ArmyListDefinitions.Find(armyDefinitionId);
                if (armyList == null)
                {
                    SetStatusNotFound();
                    return 0;
                }
                var ally = alliedArmyDefinition.GetAlliedArmyDefinition();
                armyList.AlliedArmyListDefinitions.Add(ally);
                db.AlliedArmyListDefinitions.Add(ally);
                db.SaveChanges();
                return ally.AlliedArmyListDefinitionId;
            }
        }

        public int PutAlliedArmyDefinition(int armyDefinitionId, int id, AlliedArmyDefinition alliedArmyDefinition)
        {
            if (alliedArmyDefinition.Id == 0) return PostAlliedArmyDefinition(armyDefinitionId, alliedArmyDefinition);
            using (var db = new DbmModel())
            {
                var ally =
                    alliedArmyDefinition.UpdateAlliedArmyDefinition(
                        db.AlliedArmyListDefinitions.Find(alliedArmyDefinition.Id));
                db.AlliedArmyListDefinitions.Attach(ally);
                db.Entry(ally).State = EntityState.Modified;
                db.SaveChanges();
                SetStatusOk();
                return ally.AlliedArmyListDefinitionId;
            }
        }

        public void DeleteAlliedArmyDefinition(int armyDefinitionId, int id)
        {
            using (var db = new DbmModel())
            {
                var ally = db.AlliedArmyListDefinitions.Find(id);
                if (ally == null) return;
                db.AlliedArmyListDefinitions.Remove(ally);
                db.SaveChanges();
                SetStatusOk();
            }
        }

        public AlternativeUnitDefinitions GetAlternativeUnitDefinitions(int armyDefinitionId, int unitId)
        {
            using (var db = new DbmModel())
            {
                //TODO: The current model contains only a singular alternative... Need to consider plural
                var alternativeUnits =
                    db.ArmyListDefinitions.Find(armyDefinitionId)
                        .ArmyListUnitDefinitions.Find(unit => unit.ArmyUnitDefinitionId == unitId)
                        .AlternativeUnitDefinition.GetAlternativeUnitDefinition();
                SetStatusOk();
                return alternativeUnits == null ? new AlternativeUnitDefinitions() : new AlternativeUnitDefinitions { alternativeUnits };
            }
        }

        public AlternativeUnitDefinition GetAlternativeUnitDefinition(int armyDefinitionId, int unitId, int id)
        {
            using (var db = new DbmModel())
            {
                var alternativeUnit =
                    db.ArmyListDefinitions.Find(armyDefinitionId)
                        .ArmyListUnitDefinitions.Find(
                            unit =>
                                unit.ArmyUnitDefinitionId == unitId &&
                                unit.AlternativeUnitDefinition.AlternativeUnitDefinitionId == id)
                        .AlternativeUnitDefinition.GetAlternativeUnitDefinition();
                if (alternativeUnit == null)
                {
                    SetStatusNotFound();
                    return null;
                }
                SetStatusOk();
                return alternativeUnit;
            }
        }

        public int PostAlternativeUnitDefinition(int armyDefinitionId, int unitId, AlternativeUnitDefinition alternativeUnitDefinition)
        {
            using (var db = new DbmModel())
            {
                var armyList = db.ArmyListDefinitions.Find(armyDefinitionId);
                if (armyList == null)
                {
                    SetStatusNotFound();
                    return 0;
                }
                var armyUnit = armyList.ArmyListUnitDefinitions.Find(unit => unit.ArmyUnitDefinitionId == unitId);
                if (armyUnit == null)
                {
                    SetStatusNotFound();
                    return 0;
                }
                var alternativeUnit = alternativeUnitDefinition.GetAlternativeUnitDefinition();
                armyUnit.AlternativeUnitDefinition = alternativeUnit;
                //TODO: I dont think we need the two lines commented below
                //armyList.ArmyListUnitDefinitions.Add(armyUnit);
                //db.ArmyUnitDefinitions.Add(armyUnit);
                db.SaveChanges();
                SetStatusOk();
                return alternativeUnit.AlternativeUnitDefinitionId;
            }
        }

        public int PutAlternativeUnitDefinition(int armyDefinitionId, int unitId, int id, AlternativeUnitDefinition alternativeUnitDefinition)
        {
            if (alternativeUnitDefinition.Id == 0)
                return PostAlternativeUnitDefinition(armyDefinitionId, unitId, alternativeUnitDefinition);
            using (var db = new DbmModel())
            {
                var alternativeUnit =
                    alternativeUnitDefinition.UpdateAlternativeUnitDefinition(
                        db.AlternativeUnitDefinitions.Find(alternativeUnitDefinition.Id));
                db.AlternativeUnitDefinitions.Attach(alternativeUnit);
                db.Entry(alternativeUnit).State = EntityState.Modified;
                db.SaveChanges();
                SetStatusOk();
                return alternativeUnit.AlternativeUnitDefinitionId;
            }
        }

        public void DeleteAlternativeUnitDefinition(int armyDefinitionId, int unitId, int id)
        {
            using (var db=new DbmModel())
            {
                var alternativeUnit = db.AlternativeUnitDefinitions.Find(id);
                if (alternativeUnit == null) return;
                db.AlternativeUnitDefinitions.Remove(alternativeUnit);
                db.SaveChanges();
                SetStatusOk();
            }
        }

        private bool IsUserAuthorized(string username)
        {
            var ctx = WebOperationContext.Current;
            if (ctx == null) return false;
            var requestUri = ctx.IncomingRequest.UriTemplateMatch.RequestUri.ToString();
            var authorizationHeader = ctx.IncomingRequest.Headers[HttpRequestHeader.Authorization];
            return IsValidUserKey(authorizationHeader, requestUri);
        }

        private bool IsValidUserKey(string key, string urit)
        {
            return true;
            throw new NotImplementedException();
        }

        #region Get Uri Links
        private static Uri GetUserLink(string username)
        {
            return new Uri($"http://{Host}/users/{username}");
        }

        private static Uri GetUserArmiesLink(string username, int id = 0)
        {
            var template = id == 0
                ? $"http://{Host}/users/{username}/armies"
                : $"http://{Host}/users/{username}/armies/{id}";
            return new Uri(template);
        }

        private static Uri GetUserArmyCommandsLink(string username, int armyid, string tag = "")
        {
            var template = tag == ""
                ? $"http://{Host}/users/{username}/armies/{armyid}/armycommands"
                : $"http://{Host}/users/{username}/armies/{armyid}/armycommands?tag={tag}";
            return new Uri(template);
        }

        private static Uri GetUserArmyCommandsLink(string username, int armyid, int commandId)
        {
            var template = $"http://{Host}/users/{username}/armies/{armyid}/armycommands/{commandId}";
            return new Uri(template);
        }

        private static Uri GetUserBattlesLink(string username)
        {
            return new Uri($"http://{Host}/users/{username}/battles");
        }

        private static Uri GetUserArmyGroupsLink(string username, int armyid, int armycommandsid)
        {
            return new Uri($"http://{Host}/user/{username}/armies/{armyid}/armycommands/{armycommandsid}/armygroups");
        }

        private static Uri GetUnitLink(string username, int armyid, int armycommandsid, int id)
        {
            return new Uri($"http://{Host}/user/{username}/armies/{armyid}/armycommands/{armycommandsid}/armyunit/{id}");
        }

        private Uri GetArmyDefinitionLink(int id)
        {
            return new Uri($"http://{Host}/armydefinitions/{id}");
        }

        private Uri GetArmyUnitDefinitionLink(int armyDefinitionId, int id)
        {
            return new Uri($"http://{Host}/armydefinitions/{armyDefinitionId}/armyunitdefinitions/{id}");
        }

        #endregion

        #region Web Response Status
        private static void SetStatusNotFound()
        {
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
        }

        private static void SetStatusOk()
        {
            SetStatusCode(HttpStatusCode.OK);
        }

        private static void SetStatusCreated(Uri link)
        {
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(link);
        }

        private static void SetStatusCode(HttpStatusCode code)
        {
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.StatusCode = code;
        }
        #endregion
    }
}
