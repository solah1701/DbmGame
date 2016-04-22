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
        public IUnit SelectedUnit { get; private set; }

        public void CreateUnit(IUnit unit)
        {
            if (Units.Contains(unit)) return;
            Units.Add(unit);
            SelectedUnit = unit;
        }

        public void SelectUnit(IUnit unit)
        {
            if (!Units.Contains(unit)) return;
            SelectedUnit = unit;
        }

        public void UpdateUnit(IUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUnit(IUnit unit)
        {
            if (!Units.Contains(unit)) return;
            Units.Remove(unit);
            SelectedUnit = null;
        }

        public Army()
        {
            Units = new List<IUnit>();
        }
    }
}