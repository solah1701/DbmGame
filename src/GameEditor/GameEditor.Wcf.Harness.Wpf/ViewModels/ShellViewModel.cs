using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ShellViewModel : Conductor<IMainScreenTabItem>.Collection.OneActive
    {
        public ShellViewModel(ArmyListTabViewModel armyListTab, ArmyUnitTabViewModel armyUnitTab)
        {
            Items.Add(armyListTab);
            Items.Add(armyUnitTab);
        }
    }
}