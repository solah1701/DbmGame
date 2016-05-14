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
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }
            var user = Find(username);
            if (user != null) return user;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            return null;
        }

        public void PutUser(string username, User user)
        {
            username = username.ToLower();
            var aUser = Find(username);
            if (aUser == null)
            {
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(GetUserLink(username));
            }
            else if (!IsUserAuthorized(username))
            {
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return;
            }
            user.IdLink = GetUserLink(username);
            user.BattlesLink = GetUserBattlesLink(username);
            user.ArmiesLink = GetUserArmiesLink(username);
            _model.Users[username] = user;
        }

        public void DeleteUser(string username)
        {
            if (_model.Users.ContainsKey(username)) _model.Users.Remove(username);
        }

        public UserProfile GetUserProfile(string username)
        {
            username = username.ToLower();
            var user = Find(username);
            if (user != null) return new UserProfile(user);
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            return null;
        }

        public Battle GetBattle(string username, string id)
        {
            if (_model.Battles.ContainsKey(id))
            {
                var battle = _model.Battles[id];
                if (battle.AttackerUser == username || battle.DefenderUser == username) return battle;
            }
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            return null;
        }

        public void PostBattle(string username, Battle battle)
        {
            if(_model.Battles.ContainsKey(battle.Id))
            throw new NotImplementedException();
        }

        public void PutBattle(string username, string id, Battle battle)
        {
            throw new NotImplementedException();
        }

        public void DeleteBattle(string username, string id)
        {
            throw new NotImplementedException();
        }

        public Armies GetUserArmies(string username, string tag)
        {
            throw new NotImplementedException();
        }

        public Army GetArmy(string username, string id)
        {
            throw new NotImplementedException();
        }

        public void PostArmy(string username, Army army)
        {
            throw new NotImplementedException();
        }

        public void PutArmy(string username, string id, Army army)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmy(string username, string id)
        {
            throw new NotImplementedException();
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

        private User Find(string username)
        {
            return _model.Users.ContainsKey(username) ? _model.Users[username] : null;
        }

        #region Get Uri Links
        private static Uri GetUserLink(string username)
        {
            return new Uri($"http://localhost/users/{username}");
        }

        private static Uri GetUserArmiesLink(string username)
        {
            return new Uri($"http://localhost/users/{username}/armies");
        }

        private static Uri GetUserBattlesLink(string username)
        {
            return new Uri($"http://localhost/users/{username}/battles");
        }
        #endregion
    }
}
