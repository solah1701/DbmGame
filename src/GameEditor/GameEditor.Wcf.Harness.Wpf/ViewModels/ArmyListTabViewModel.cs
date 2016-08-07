using System.ComponentModel.Composition;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyListTabViewModel : Screen, IArmyListTabViewModel
    {
        public IArmyListViewModel ArmyList { get; set; }
        public IArmyDetailViewModel ArmyDetail { get; set; }

        public ArmyListTabViewModel(IArmyListViewModel armyList, IArmyDetailViewModel armyDetail)
        {
            DisplayName = "Army List";
            ArmyList = armyList;
            ArmyDetail = armyDetail;
        }
    }
}