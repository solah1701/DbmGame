using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyUnitTabViewModel : Screen, IMainScreenTabItem
    {
        public ArmyUnitListViewModel ArmyUnitList { get; set; }
        public ArmyUnitDetailViewModel ArmyUnitDetail { get; set; }
        public AllyListViewModel AllyList { get; set; }
        public AllyDetailViewModel AllyDetail { get; set; }

        public ArmyUnitTabViewModel(ArmyUnitListViewModel armyUnitList, ArmyUnitDetailViewModel armyUnitDetail, AllyListViewModel allyList, AllyDetailViewModel allyDetail)
        {
            DisplayName = "Army Unit";
            ArmyUnitList = armyUnitList;
            ArmyUnitDetail = armyUnitDetail;
            AllyList = allyList;
            AllyDetail = allyDetail;
        }
    }
}