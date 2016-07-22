namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelCheckboxViewModel : LabelViewModelBase
    {
        private bool _checkBox;
        public bool CheckBox
        {
            get { return _checkBox; }
            set
            {
                if (_checkBox == value) return;
                _checkBox = value;
                NotifyOfPropertyChange(() => CheckBox);
            }
        }

        public LabelCheckboxViewModel()
        {
            CheckBox = false;
            LabelWidth = 120;
        }
    }
}