using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameCore.Wcf.Helpers;

namespace GameCore.Wcf.Game
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarGameService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class WarGameService : IWarGameService
    {
        private readonly IWarGameModel _model;

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

        public UserProfile GetUserProfile(string username)
        {
            username = username.ToLower();
            var user = _model.FindUser(username);
            if (user != null)
            {
                SetStatusOk();
                return new UserProfile(user);
            }
            SetStatusNotFound();
            return null;
        }

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
            if (!_model.BattleContainsKey(battle.Id) && _model.UsersContainsKey(username) && _model.UsersContainsKey(defendername))
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
            if (_model.BattleContainsKey(id) && _model.IsBattleAttacker(id, username) &&
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
            if (_model.BattleContainsKey(id))
            {
                _model.BattlesRemove(id);
                SetStatusOk();
                return;
            }
            SetStatusCode(HttpStatusCode.NotModified);
        }

        public Armies GetUserArmies(string username, string tag)
        {
            var armies = _model.ArmiesFindFromUser(username);
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
            var armies = _model.GetUserArmy(username, id);
            if (armies == null)
            {
                SetStatusNotFound();
                return null;
            }
            SetStatusOk();
            return armies;
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
            throw new NotImplementedException();
        }

        public ArmyCommand GetArmyCommand(string username, string armyId, string id)
        {
            throw new NotImplementedException();
        }

        public void PostArmyCommand(string username, string armyId, ArmyCommand armyCommand)
        {
            throw new NotImplementedException();
        }

        public void PutArmyCommand(string username, string armyId, string id, ArmyCommand armyCommand)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmyCommand(string username, string armyId, string id)
        {
            throw new NotImplementedException();
        }

        public ArmyGroups GetUserArmyGroups(string username, string armyId, string commandId, string tag)
        {
            throw new NotImplementedException();
        }

        public ArmyGroup GetArmyGroup(string username, string armyId, string commandId, string id)
        {
            throw new NotImplementedException();
        }

        public void PostArmyGroup(string username, string armyId, string commandId, ArmyGroup armyGroup)
        {
            throw new NotImplementedException();
        }

        public void PutArmyGroup(string username, string armyId, string commandId, string id, ArmyGroup armyGroup)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmyGroup(string username, string armyId, string commandId, string id)
        {
            throw new NotImplementedException();
        }

        public Units GetUserArmyUnits(string username, string armyId, string commandId, string tag)
        {
            throw new NotImplementedException();
        }

        public Units GetUserArmyGroupUnits(string username, string armyId, string commandId, string tag)
        {
            throw new NotImplementedException();
        }

        public Unit GetArmyUnit(string username, string armyId, string commandId, string id)
        {
            throw new NotImplementedException();
        }

        public void PostArmyUnit(string username, string armyId, string commandId, Unit unit)
        {
            throw new NotImplementedException();
        }

        public void PutArmyUnit(string username, string armyId, string commandId, string id, Unit unit)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmyUnit(string username, string armyId, string commandId, string id)
        {
            throw new NotImplementedException();
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
            return new Uri($"http://localhost/users/{username}");
        }

        private static Uri GetUserArmiesLink(string username, string id = "")
        {
            var template = id == ""
                ? $"http://localhost/users/{username}/armies"
                : $"http://localhost/users/{username}/armies/{id}";
            return new Uri(template);
        }

        private static Uri GetUserArmyCommandsLink(string username, string armyid, string tag = "")
        {
            var template = tag == ""
                ? $"http://localhost/users/{username}/armies/{armyid}/armycommands"
                : $"http://localhost/users/{username}/armies/{armyid}/armycommands?tag={tag}";
            return new Uri(template);
        }

        private static Uri GetUserBattlesLink(string username)
        {
            return new Uri($"http://localhost/users/{username}/battles");
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
