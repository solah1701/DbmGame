using System.Collections.Generic;

namespace GameCore.DebellisMultitudinis
{
    public interface IArmy : INamedItem
    {
        List<IUnit> Units { get; set; }
        IUnit SelectedUnit { get; }
        void CreateUnit(IUnit unit);
        void SelectUnit(IUnit unit);
        void UpdateUnit(IUnit unit);
        void DeleteUnit(IUnit unit);
    }
}