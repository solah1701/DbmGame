using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GameCore.Serialization;

namespace GameCore.DebellisMultitudinis
{
    [DataContract(Name= "DbmGame", Namespace = "GameCore.DebellisMultitudinis")]
    public class DbmGame : SerializerBase<DbmGame>, IDbmGame
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<IConstructableUnit> ConstructableUnits { get; set; }
        [DataMember]
        public List<IArmy> Armies { get; set; } 

        public DbmGame()
        {
            ConstructableUnits = new List<IConstructableUnit>();
        }
        public override void AddKnownTypes(IList<Type> knownTypes)
        {
            knownTypes.Add(typeof(Unit));
            knownTypes.Add(typeof(Army));
        }
    }
}