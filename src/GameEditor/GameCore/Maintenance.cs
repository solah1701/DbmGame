using System.Runtime.Serialization;

namespace GameCore
{
    [DataContract(Name = "Maintenance", Namespace = "GameCore")]
    public class Maintenance : IMaintenance
    {
        [DataMember]
        public string Name { get; set; }
    }
}