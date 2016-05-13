using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameCore.Wcf.Game
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarGameService" in both code and config file together.
    [ServiceContract]
    public interface IWarGameService
    {
        [OperationContract]
        void DoWork();
    }



    public class User
    {
        public Uri Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Armies { get; set; }
    }

    public class UserProfile
    {
        public UserProfile(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Armies = user.Armies;
        }

        public Uri Id { get; set; }
        public string Name { get; set; }
        public Uri Armies { get; set; }
    }

    public class Army
    {
        public Uri Id { get; set; }
        public string Title { get; set; }
        public Uri ArmyCommands { get; set; }
    }

    [CollectionDataContract]
    public class Armies : List<Army>
    {
        public Armies() { }
        public Armies(List<Army> armies) : base(armies) { }
    }

    public class ArmyCommand
    {
        public Uri Id { get; set; }
        public string Title { get; set; }
        public Uri ArmyGroups { get; set; }
        public Uri Units { get; set; }
        public bool IsFlankMarch { get; set; }
        public bool IsBroken { get; set; }
    }

    [CollectionDataContract]
    public class ArmyCommands : List<ArmyCommand>
    {
        public ArmyCommands() { }
        public ArmyCommands(List<ArmyCommand> armyCommands) : base(armyCommands) { }
    }

    public class ArmyGroup
    {
        public Uri Id { get; set; }
        public Uri Units { get; set; }
        public Uri ArmyCommand { get; set; }
        public int UnitFrontage { get; set; }
    }

    [CollectionDataContract]
    public class ArmyGroups : List<ArmyGroup>
    {
        public ArmyGroups() { }
        public ArmyGroups(List<ArmyGroup> armyGroups) : base(armyGroups) { }
    }

    public class Unit
    {
        public Uri Id { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }
    }

    [CollectionDataContract]
    public class Units : List<Unit>
    {
        public Units() { }
        public Units(List<Unit> units) : base(units) { }
    }
}