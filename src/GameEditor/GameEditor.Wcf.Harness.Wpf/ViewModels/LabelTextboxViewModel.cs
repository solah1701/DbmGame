using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelTextboxViewModel : LabelViewModelBase
    {
        private string _textBox;
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

        public string TextWrapping { get; set; }

        public LabelTextboxViewModel(IEventAggregator eventAggregator)
        {
            _event = eventAggregator;
            TextBox = string.Empty;
        }

        public void KeyPressed(ActionExecutionContext context)
        {
            _event.PublishOnCurrentThread(new CheckDirtyStatus());
        }
    }
}