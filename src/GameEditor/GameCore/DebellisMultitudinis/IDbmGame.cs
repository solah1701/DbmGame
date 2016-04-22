using System.Collections.Generic;

namespace GameCore.DebellisMultitudinis
{
    public interface IDbmGame : INamedItem
    {
        List<IConstructableUnit> ConstructableUnits { get; set; }
        List<IArmy> Armies { get; set; }
        IArmy SelectedArmy { get; }
        void CreateArmy(string name);
        void SelectArmy(IArmy army);
        void UpdateArmy(IArmy army);
        void DeleteArmy(IArmy army);
    }
}