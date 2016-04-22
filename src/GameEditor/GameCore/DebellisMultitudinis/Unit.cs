using System.Runtime.Serialization;

namespace GameCore.DebellisMultitudinis
{
    [DataContract(Name = "Unit", Namespace = "GameCore.DebellisMultitudinis")]
    public class Unit : IConstructableUnit
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Attack { get; set; }
        [DataMember]
        public int Defence { get; set; }
        [DataMember]
        public int Move { get; set; }
        [DataMember]
        public int Range { get; set; }
        [DataMember]
        public int Speed { get; set; }
        [DataMember]
        public int Stamina { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int Morale { get; set; }
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public int Upkeep { get; set; }
        [DataMember]
        public int ConstructionTime { get; set; }
    }
}