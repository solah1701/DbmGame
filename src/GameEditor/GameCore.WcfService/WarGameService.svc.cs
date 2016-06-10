using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
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
        private DbmModel _db = new DbmModel();

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

        public Battle GetBattle(string username, string id)
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

        public void PutBattle(string username, string defendername, string id, Battle battle)
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

        public void DeleteBattle(string username, string defendername, string id)
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

        public Army GetArmy(string username, string id)
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

        public void PutArmy(string username, string id, Army army)
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

        public void DeleteArmy(string username, string id)
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

        public ArmyCommands GetUserArmyCommands(string username, string armyId, string tag)
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

        public ArmyCommand GetArmyCommand(string username, string armyId, string id)
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

        public void PostArmyCommand(string username, string armyId, ArmyCommand armyCommand)
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

        public void PutArmyCommand(string username, string armyId, string id, ArmyCommand armyCommand)
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

        public void DeleteArmyCommand(string username, string armyId, string id)
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

        public ArmyGroups GetUserArmyGroups(string username, string armyId, string commandId, string tag)
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

        public ArmyGroup GetArmyGroup(string username, string armyId, string commandId, string id)
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

        public void PostArmyGroup(string username, string armyId, string commandId, ArmyGroup armyGroup)
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

        public void PutArmyGroup(string username, string armyId, string commandId, string id, ArmyGroup armyGroup)
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

        public void DeleteArmyGroup(string username, string armyId, string commandId, string id)
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

        public Units GetUserArmyUnits(string username, string armyId, string commandId, string tag)
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

        public Units GetUserArmyGroupUnits(string username, string armyId, string commandId, string groupId, string tag)
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

        public Unit GetArmyUnit(string username, string armyId, string commandId, string id)
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

        public void PostArmyUnit(string username, string armyId, string commandId, Unit unit)
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

        public void PutArmyUnit(string username, string armyId, string commandId, string id, Unit unit)
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

        public void DeleteArmyUnit(string username, string armyId, string commandId, string id)
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
            var armyDefinitions = _db.ArmyListDefinitions.ToList().GetArmyDefinitions();
            if (!armyDefinitions.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new ArmyDefinitions(armyDefinitions);
        }

        public ArmyDefinition GetArmyDefinition(string id)
        {
            var armyDefinition = _db.ArmyListDefinitions.Find(int.Parse(id)).GetArmyDefinition();
            if (armyDefinition == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return armyDefinition;
        }

        public void PostArmyDefinition(ArmyDefinition armyDefinition)
        {
            var armyList = armyDefinition.GetArmyListDefinition();
            _db.ArmyListDefinitions.Add(armyList);
            _db.SaveChanges();
            SetStatusOk();
        }

        public void PutArmyDefinition(ArmyDefinition armyDefinition)
        {
            if (armyDefinition.Id == 0)
            {
                PostArmyDefinition(armyDefinition);
                return;
            }
            var armyDef = armyDefinition.UpdateArmyListDefinition(_db.ArmyListDefinitions.Find(armyDefinition.Id));
            _db.ArmyListDefinitions.Attach(armyDef);
            var entry = _db.Entry(armyDef);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
            SetStatusOk();
        }

        public void DeleteArmyDefinition(string id)
        {
            var item = _db.ArmyListDefinitions.Find(id);
            _db.ArmyListDefinitions.Remove(item);
            _db.SaveChanges();
            SetStatusOk();
        }

        public ArmyUnitDefinitions GetArmyUnitDefinitions(string armyDefinitionId)
        {
            var armyUnitDefinitions = _model.FindArmyUnitDefinitions(armyDefinitionId);
            if (armyUnitDefinitions != null && !armyUnitDefinitions.Any())
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return new ArmyUnitDefinitions(armyUnitDefinitions);
        }

        public ArmyUnitDefinition GetArmyUnitDefinition(string armyDefinitionId, string id)
        {
            var armyUnitDefinitions = _model.FindArmyUnitDefinition(id, armyDefinitionId);
            if (armyUnitDefinitions == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return armyUnitDefinitions;
        }

        public void PostArmyUnitDefinition(string armyDefinitionId, ArmyUnitDefinition armyUnitDefinition)
        {
            var armyDef = _model.FindArmyUnitDefinition(armyUnitDefinition.Id, armyDefinitionId);
            var armyDefLink = GetArmyUnitDefinitionLink(armyDefinitionId, armyUnitDefinition.Id);
            if (armyDef == null) SetStatusCreated(armyDefLink);
            armyUnitDefinition.IdLink = armyDefLink;
            if (_model.ArmyUnitDefinitionsContainsKey(armyUnitDefinition.Id)) _model.SetArmyUnitDefinition(armyUnitDefinition.Id, armyDef);
            else _model.ArmyUnitDefinitionsAdd(armyUnitDefinition.Id, armyDef);
            SetStatusOk();
        }

        public void PutArmyUnitDefinition(string armyDefinitionId, string id, ArmyUnitDefinition armyUnitDefinition)
        {
            var armyDef = _model.FindArmyUnitDefinition(armyUnitDefinition.Id, armyDefinitionId);
            var armyDefLink = GetArmyUnitDefinitionLink(armyDefinitionId, armyUnitDefinition.Id);
            if (armyDef == null)
            {
                SetStatusNotFound();
                return;
            }
            armyUnitDefinition.IdLink = armyDefLink;
            if (_model.ArmyUnitDefinitionsContainsKey(armyUnitDefinition.Id))
                _model.SetArmyUnitDefinition(armyUnitDefinition.Id, armyDef);
            else
            {
                SetStatusNotFound();
                return;
            }
            SetStatusOk();
        }

        public void DeleteArmyUnitDefinition(string armyDefinitionId, string id)
        {
            var armyDef = _model.FindArmyUnitDefinition(id, armyDefinitionId);
            if (armyDef == null)
            {
                SetStatusNotFound();
                return;
            }
            _model.ArmyUnitDefinitionsRemove(id);
            SetStatusOk();
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

        private static Uri GetUserArmiesLink(string username, string id = "")
        {
            var template = id == ""
                ? $"http://{Host}/users/{username}/armies"
                : $"http://{Host}/users/{username}/armies/{id}";
            return new Uri(template);
        }

        private static Uri GetUserArmyCommandsLink(string username, string armyid, string tag = "")
        {
            var template = tag == ""
                ? $"http://{Host}/users/{username}/armies/{armyid}/armycommands"
                : $"http://{Host}/users/{username}/armies/{armyid}/armycommands?tag={tag}";
            return new Uri(template);
        }

        private static Uri GetUserBattlesLink(string username)
        {
            return new Uri($"http://{Host}/users/{username}/battles");
        }

        private static Uri GetUserArmyGroupsLink(string username, string armyid, string armycommandsid)
        {
            return new Uri($"http://{Host}/user/{username}/armies/{armyid}/armycommands/{armycommandsid}/armygroups");
        }

        private static Uri GetUnitLink(string username, string armyid, string armycommandsid, string id)
        {
            return new Uri($"http://{Host}/user/{username}/armies/{armyid}/armycommands/{armycommandsid}/armyunit/{id}");
        }

        private Uri GetArmyDefinitionLink(string id)
        {
            return new Uri($"http://{Host}/armydefinitions/{id}");
        }

        private Uri GetArmyUnitDefinitionLink(string armyDefinitionId, string id)
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
