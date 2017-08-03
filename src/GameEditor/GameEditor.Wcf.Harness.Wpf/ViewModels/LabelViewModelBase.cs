using Caliburn.Micro;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelViewModelBase : PropertyChangedBase
    {
        private string _label;
        private int _labelWidth;

        public string Label
        {
            get { return _label; }
            set
            {
                if (_label == value) return;
                _label = value;
                NotifyOfPropertyChange(() => Label);
            }
        }

        public int LabelWidth
        {
            get { return _labelWidth; }
            set
            {
                if (_labelWidth == value) return;
                _labelWidth = value;
                NotifyOfPropertyChange(() => LabelWidth);
            }
        }


        public LabelViewModelBase()
        {
            Label = "label";
        }        
    }
}