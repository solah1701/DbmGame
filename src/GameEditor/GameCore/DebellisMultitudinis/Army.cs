using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameCore.DebellisMultitudinis
{
    [DataContract(Name = "Army")]
    public class Army : IArmy
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<IUnit> Units { get; set; }

        public Army()
        {
            Units = new List<IUnit>();
        }
    }
}