using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyUnitTabViewModel : Screen, IMainScreenTabItem
    {
        public ArmyUnitTabViewModel()
        {
            DisplayName = "Army Unit";
        }
    }
}