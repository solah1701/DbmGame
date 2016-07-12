using System.ComponentModel.Composition;
using System.Dynamic;
using System.Windows;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        public ShellViewModel()
        {
            ActivateItem(new TabViewModel { DisplayName = "Army List" });
            ActivateItem(new TabViewModel { DisplayName = "Army Unit" });
        }
    }
}