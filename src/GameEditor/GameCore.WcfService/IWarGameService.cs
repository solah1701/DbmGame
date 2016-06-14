using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameCore.WcfService.DebellisMultitudinis.Enumerations;

namespace GameCore.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDbmGameService" in both code and config file together.
    [ServiceContract]
    public interface IWarGameService
    {
        #region User
        [WebGet(UriTemplate = "users/{username}")]
        [OperationContract]
        User GetUser(string username);

        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}")]
        [OperationContract]
        void PutUser(string username, User user);

        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}")]
        [OperationContract]
        void DeleteUser(string username);

        //[WebGet(UriTemplate = "users/{username}/profile")]
        //[OperationContract]
        //UserProfile GetUserProfile(string username);
        #endregion

        #region Battle
        [WebGet(UriTemplate = "users/{username}/battles/{id}")]
        [OperationContract]
        Battle GetBattle(string username, int id);

        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/defender/{defendername}/battles")]
        [OperationContract]
        void PostBattle(string username, string defendername, Battle battle);

        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/defender/{defendername}/battles/{id}")]
        [OperationContract]
        void PutBattle(string username, string defendername, int id, Battle battle);

        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/defender/{defendername}/battles/{id}")]
        [OperationContract]
        void DeleteBattle(string username, string defendername, int id);
        #endregion

        #region Army
        [WebGet(UriTemplate = "users/{username}/Armies?tag={tag}")]
        [OperationContract]
        Armies GetUserArmies(string username, string tag);

        [WebGet(UriTemplate = "users/{username}/Armies/{id}")]
        [OperationContract]
        Army GetArmy(string username, int id);

        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/Armies")]
        [OperationContract]
        void PostArmy(string username, Army army);

        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/Armies/{id}")]
        [OperationContract]
        void PutArmy(string username, int id, Army army);

        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/Armies/{id}")]
        [OperationContract]
        void DeleteArmy(string username, int id);
        #endregion

        #region ArmyCommand
        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands?tag={tag}")]
        [OperationContract]
        ArmyCommands GetUserArmyCommands(string username, int armyId, string tag);

        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{id}")]
        [OperationContract]
        ArmyCommand GetArmyCommand(string username, int armyId, int id);

        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands")]
        [OperationContract]
        void PostArmyCommand(string username, int armyId, ArmyCommand armyCommand);

        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{id}")]
        [OperationContract]
        void PutArmyCommand(string username, int armyId, int id, ArmyCommand armyCommand);

        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{id}")]
        [OperationContract]
        void DeleteArmyCommand(string username, int armyId, int id);
        #endregion

        #region ArmyGroup
        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/ArmyGroups?tag={tag}")]
        [OperationContract]
        ArmyGroups GetUserArmyGroups(string username, int armyId, int commandId, string tag);

        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/ArmyGroups/{id}")]
        [OperationContract]
        ArmyGroup GetArmyGroup(string username, int armyId, int commandId, int id);

        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/ArmyGroups")]
        [OperationContract]
        void PostArmyGroup(string username, int armyId, int commandId, ArmyGroup armyGroup);

        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/ArmyGroups/{id}")]
        [OperationContract]
        void PutArmyGroup(string username, int armyId, int commandId, int id, ArmyGroup armyGroup);

        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/ArmyGroups/{id}")]
        [OperationContract]
        void DeleteArmyGroup(string username, int armyId, int commandId, int id);
        #endregion

        #region ArmyUnit
        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/Units?tag={tag}")]
        [OperationContract]
        Units GetUserArmyUnits(string username, int armyId, int commandId, string tag);

        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/ArmyGroups/{groupId}/Units?tag={tag}")]
        [OperationContract]
        Units GetUserArmyGroupUnits(string username, int armyId, int commandId, int groupId, string tag);

        [WebGet(UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/Units/{id}")]
        [OperationContract]
        Unit GetArmyUnit(string username, int armyId, int commandId, int id);

        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/Units")]
        [OperationContract]
        void PostArmyUnit(string username, int armyId, int commandId, Unit unit);

        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/Units/{id}")]
        [OperationContract]
        void PutArmyUnit(string username, int armyId, int commandId, int id, Unit unit);

        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/Armies/{armyId}/ArmyCommands/{commandId}/Units/{id}")]
        [OperationContract]
        void DeleteArmyUnit(string username, int armyId, int commandId, int id);
        #endregion

        #region ArmyDefinition

        [WebGet(UriTemplate = "ArmyDefinitions")]
        [OperationContract]
        ArmyDefinitions GetArmyDefinitions();

        [WebGet(UriTemplate = "ArmyDefinitions/{id}")]
        [OperationContract]
        ArmyDefinition GetArmyDefinition(int id);

        [WebInvoke(Method = "POST", UriTemplate = "ArmyDefinitions")]
        [OperationContract]
        int PostArmyDefinition(ArmyDefinition armyDefinition);

        [WebInvoke(Method = "PUT", UriTemplate = "ArmyDefinitions/{id}")]
        [OperationContract]
        int PutArmyDefinition(ArmyDefinition armyDefinition);

        [WebInvoke(Method = "Delete", UriTemplate = "ArmyDefinitions/{id}")]
        [OperationContract]
        void DeleteArmyDefinition(int id);

        #endregion

        #region ArmyUnitDefinition

        [WebGet(UriTemplate = "ArmyDefinitions/{armyDefinitionId}/ArmyUnitDefinitions")]
        [OperationContract]
        ArmyUnitDefinitions GetArmyUnitDefinitions(int armyDefinitionId);

        [WebGet(UriTemplate = "ArmyDefinitions/{armyDefinitionId}/ArmyUnitDefinitions/{id}")]
        [OperationContract]
        ArmyUnitDefinition GetArmyUnitDefinition(int armyDefinitionId, int id);

        [WebInvoke(Method = "POST", UriTemplate = "ArmyDefinitions/{armyDefinitionId}/ArmyUnitDefinitions")]
        [OperationContract]
        void PostArmyUnitDefinition(int armyDefinitionId, ArmyUnitDefinition armyUnitDefinition);

        [WebInvoke(Method = "PUT", UriTemplate = "ArmyDefinitions/{armyDefinitionId}/ArmyUnitDefinitions/{id}")]
        [OperationContract]
        void PutArmyUnitDefinition(int armyDefinitionId, int id, ArmyUnitDefinition armyUnitDefinition);

        [WebInvoke(Method = "Delete", UriTemplate = "ArmyDefinitions/{armyDefinitionId}/ArmyUnitDefinitions/{id}")]
        [OperationContract]
        void DeleteArmyUnitDefinition(int armyDefinitionId, int id);

        #endregion
    }

    public class ArmyDefinition
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string ArmyName { get; set; }
        public int ArmyBook { get; set; }
        public int ArmyList { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public string Notes { get; set; }
    }

    [CollectionDataContract]
    public class ArmyDefinitions : List<ArmyDefinition>
    {
        public ArmyDefinitions() { }
        public ArmyDefinitions(List<ArmyDefinition> armyDefinitions) : base(armyDefinitions) { }
    }

    public class ArmyUnitDefinition
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string UnitName { get; set; }
        public decimal? Cost { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsChariot { get; set; }
        public bool IsMountedInfantry { get; set; }
        public bool IsAlly { get; set; }
        public bool IsDoubleElement { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public DisciplineTypeEnum DisciplineType { get; set; }
        public UnitTypeEnum UnitType { get; set; }
        public GradeTypeEnum GradeType { get; set; }
        public DispositionTypeEnum DispositionType { get; set; }

        //public virtual ArmyListDefinition ArmyListDefinition { get; set; }
    }

    [CollectionDataContract]
    public class ArmyUnitDefinitions : List<ArmyUnitDefinition>
    {
        public ArmyUnitDefinitions() { }
        public ArmyUnitDefinitions(List<ArmyUnitDefinition> armyUnitDefinitions) : base(armyUnitDefinitions) { }
    }

    public class User
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri ArmiesLink { get; set; }
        public Uri BattlesLink { get; set; }
    }

    //public class UserProfile
    //{
    //    public UserProfile(User user)
    //    {
    //        IdLink = user.IdLink;
    //        Id = user.Id;
    //        Name = user.Name;
    //        ArmiesLink = user.ArmiesLink;
    //        BattlesLink = user.BattlesLink;
    //    }

    //    public Uri IdLink { get; set; }
    //    public int id { get; set; }
    //    public string Name { get; set; }
    //    public Uri ArmiesLink { get; set; }
    //    public Uri BattlesLink { get; set; }
    //}

    public class Army
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri ArmyCommandsLink { get; set; }
        public Uri UserLink { get; set; }
        public string User { get; set; }
    }

    [CollectionDataContract]
    public class Armies : List<Army>
    {
        public Armies() { }
        public Armies(List<Army> armies) : base(armies) { }
    }

    public class ArmyCommand
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri ArmyGroupsLink { get; set; }
        public Uri UnitsLink { get; set; }
        public bool IsFlankMarch { get; set; }
        public bool IsBroken { get; set; }
        public Uri UserLink { get; set; }
        public string User { get; set; }
        public Uri ArmyLink { get; set; }
        public int Army { get; set; }
    }

    [CollectionDataContract]
    public class ArmyCommands : List<ArmyCommand>
    {
        public ArmyCommands() { }
        public ArmyCommands(List<ArmyCommand> armyCommands) : base(armyCommands) { }
    }

    public class ArmyGroup
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public int UnitFrontage { get; set; }
        public Uri UnitsLink { get; set; }
        public Uri UserLink { get; set; }
        public string User { get; set; }
        public Uri ArmyLink { get; set; }
        public int Army { get; set; }
        public Uri ArmyCommandLink { get; set; }
        public int ArmyCommand { get; set; }
    }

    [CollectionDataContract]
    public class ArmyGroups : List<ArmyGroup>
    {
        public ArmyGroups() { }
        public ArmyGroups(List<ArmyGroup> armyGroups) : base(armyGroups) { }
    }

    public class Unit
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }
        public Uri UserLink { get; set; }
        public string User { get; set; }
        public Uri ArmyLink { get; set; }
        public int Army { get; set; }
        public Uri ArmyCommandLink { get; set; }
        public int ArmyCommand { get; set; }
        public Uri ArmyGroupLink { get; set; }
        public int ArmyGroup { get; set; }
    }

    [CollectionDataContract]
    public class Units : List<Unit>
    {
        public Units() { }
        public Units(List<Unit> units) : base(units) { }
    }

    public class Battle
    {
        public Uri IdLink { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Uri AttackerUserLink { get; set; }
        public string AttackerUser { get; set; }
        public Uri DefenderUserLink { get; set; }
        public string DefenderUser { get; set; }
    }

    [CollectionDataContract]
    public class Battles : List<Battle>
    {
        public Battles() { }
        public Battles(List<Battle> battles) : base(battles) { }
    }
}
