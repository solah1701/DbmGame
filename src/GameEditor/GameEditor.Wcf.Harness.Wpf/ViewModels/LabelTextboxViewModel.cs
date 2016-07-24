using System.Net.NetworkInformation;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelTextboxViewModel : LabelViewModelBase
    {
        private string _textBox;

        public string TextBox
        {
            get { return _textBox; }
            set
            {
                if (_textBox == value) return;
                _textBox = value;
                NotifyOfPropertyChange(() => TextBox);
            }
        }

        public string TextWrapping { get; set; }

        public LabelTextboxViewModel()
        {
            TextBox = string.Empty;
        }
    }
}