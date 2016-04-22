using System;
using System.Collections.Generic;
using System.Linq;
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
        public IArmy SelectedArmy { get; private set; }

        public void CreateArmy(string name)
        {
            if (Armies.Any(a => a.Name == name)) return;
            SelectedArmy = new Army {Name = name};
            Armies.Add(SelectedArmy);
        }

        public void SelectArmy(IArmy army)
        {
            if (!Armies.Contains(army)) return;
            SelectedArmy = army;
        }

        public void UpdateArmy(IArmy army)
        {
            throw new NotImplementedException();
        }

        public void DeleteArmy(IArmy army)
        {
            if (!Armies.Contains(army)) return;
            Armies.Remove(army);
            SelectedArmy = null;
        }

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