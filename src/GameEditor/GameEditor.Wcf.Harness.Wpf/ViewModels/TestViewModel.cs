using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    [Export(typeof(ITest))]
    public class TestViewModel : PropertyChangedBase, ITest
    {
        string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            MessageBox.Show($"Hello {Name}");
        }
    }
}