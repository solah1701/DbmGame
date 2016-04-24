using GameCore.DebellisMultitudinis;
using GameEditor.Views.Base;

namespace GameEditor.Views
{
    public interface IUnitsView : IListView<IConstructableUnit>
    {
        int Attack { get; set; }
        int Defence { get; set; }
        int Move { get; set; }
        int Range { get; set; }
        int Speed { get; set; }
        int Stamina { get; set; }
        int Level { get; set; }
        int Morale { get; set; }
        decimal Cost { get; set; }
        int Upkeep { get; set; }
        int ConstructionTime { get; set; }
    }
}