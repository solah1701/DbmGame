using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyUnitTabViewModel : Screen, IArmyUnitTabViewModel
    {
        public IArmyUnitListViewModel ArmyUnitList { get; set; }
        public IArmyUnitDetailViewModel ArmyUnitDetail { get; set; }
        public IAllyListViewModel AllyList { get; set; }
        public IAllyDetailViewModel AllyDetail { get; set; }

        public ArmyUnitTabViewModel(IArmyUnitListViewModel armyUnitList, IArmyUnitDetailViewModel armyUnitDetail, IAllyListViewModel allyList, IAllyDetailViewModel allyDetail)
        {
            DisplayName = "Army Unit";
            ArmyUnitList = armyUnitList;
            ArmyUnitDetail = armyUnitDetail;
            AllyList = allyList;
            AllyDetail = allyDetail;
        }
    }
}