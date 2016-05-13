using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameCore.Wcf.Game
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarGameService" in both code and config file together.
    public class WarGameService : IWarGameService
    {
        public void DeleteArmy(string username, string id, Army army)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmyCommand(string username, string armyId, string id, ArmyCommand armyCommand)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmyGroup(string username, string armyId, string commandId, string id, ArmyGroup armyGroup)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmyUnit(string username, string armyId, string commandId, string id, Unit unit)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string username, User user)
        {
            throw new NotImplementedException();
        }

        public Army GetArmy(string username, string id)
        {
            throw new NotImplementedException();
        }

        public ArmyCommand GetArmyCommand(string username, string armyId, string id)
        {
            throw new NotImplementedException();
        }

        public ArmyGroup GetArmyGroup(string username, string armyId, string commandId, string id)
        {
            throw new NotImplementedException();
        }

        public Unit GetArmyUnit(string username, string armyId, string commandId, string id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public Armies GetUserArmies(string username, string tag)
        {
            throw new NotImplementedException();
        }

        public ArmyCommands GetUserArmyCommands(string username, string armyId, string tag)
        {
            throw new NotImplementedException();
        }

        public ArmyGroups GetUserArmyGroups(string username, string armyId, string commandId, string tag)
        {
            throw new NotImplementedException();
        }

        public Units GetUserArmyGroupUnits(string username, string armyId, string commandId, string tag)
        {
            throw new NotImplementedException();
        }

        public Units GetUserArmyUnits(string username, string armyId, string commandId, string tag)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfile(string username)
        {
            throw new NotImplementedException();
        }

        public void PostArmy(string username, Army army)
        {
            throw new NotImplementedException();
        }

        public void PostArmyCommand(string username, string armyId, ArmyCommand armyCommand)
        {
            throw new NotImplementedException();
        }

        public void PostArmyGroup(string username, string armyId, string commandId, ArmyGroup armyGroup)
        {
            throw new NotImplementedException();
        }

        public void PostArmyUnit(string username, string armyId, string commandId, Unit unit)
        {
            throw new NotImplementedException();
        }

        public void PutArmy(string username, string id, Army army)
        {
            throw new NotImplementedException();
        }

        public void PutArmyCommand(string username, string armyId, string id, ArmyCommand armyCommand)
        {
            throw new NotImplementedException();
        }

        public void PutArmyGroup(string username, string armyId, string commandId, string id, ArmyGroup armyGroup)
        {
            throw new NotImplementedException();
        }

        public void PutArmyUnit(string username, string armyId, string commandId, string id, Unit unit)
        {
            throw new NotImplementedException();
        }

        public void PutUser(string username, User user)
        {
            throw new NotImplementedException();
        }
    }
}
