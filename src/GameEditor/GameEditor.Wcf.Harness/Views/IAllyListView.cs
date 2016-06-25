using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Views
{
    public interface IAllyListView
    {
        AlliedArmyDefinitions AlliedArmyDefinitions { set; }
        string AllyName { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
        bool CanUpdate { get; set; }
    }
}