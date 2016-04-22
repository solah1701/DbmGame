using System;
using System.Collections.Generic;
using GameCore.Serialization;

namespace GameCore.DebellisMultitudinis
{
    public class DbmGame : SerializerBase<DbmGame>, IDbmGame
    {
        public string Name { get; set; }
        public List<IConstructableUnit> ConstructableUnits { get; set; }

        public DbmGame()
        {
            ConstructableUnits = new List<IConstructableUnit>();
        }
        public override void AddKnownTypes(IList<Type> knownTypes)
        {
            knownTypes.Add(typeof(Unit));
        }
    }
}