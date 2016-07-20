using System.ComponentModel.Composition;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyListTabViewModel : Screen, IMainScreenTabItem
    {
        public ArmyListViewModel ArmyList { get; set; }
        public ArmyDetailViewModel ArmyDetail { get; set; }

        public ArmyListTabViewModel(ArmyListViewModel armyList, ArmyDetailViewModel armyDetail)
        {
            DisplayName = "Army List";
            ArmyList = armyList;
            ArmyDetail = armyDetail;
        }
    }
}