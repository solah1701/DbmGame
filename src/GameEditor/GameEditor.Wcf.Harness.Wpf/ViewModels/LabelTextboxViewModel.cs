using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelTextboxViewModel : LabelViewModelBase
    {
        private string _textBox;
        private bool _canTextBox;
        private IEventAggregator _event;

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

        public bool CanTextBox
        {
            get { return _canTextBox; }
            set
            {
                if (_canTextBox == value) return;
                _canTextBox = value;
                NotifyOfPropertyChange(() => CanTextBox);
            }
        }

        public string TextWrapping { get; set; }

        public LabelTextboxViewModel(IEventAggregator eventAggregator)
        {
            _event = eventAggregator;
            TextBox = string.Empty;
            CanTextBox = true;
        }

        public void KeyPressed(ActionExecutionContext context)
        {
            _event.PublishOnCurrentThread(new CheckDirtyStatus());
        }
    }
}