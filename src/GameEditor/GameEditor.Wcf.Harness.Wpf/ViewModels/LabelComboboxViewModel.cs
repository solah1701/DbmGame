using System.Collections.Generic;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelComboboxViewModel : LabelViewModelBase
    {
        private string _selectedValue;

        public List<string> ComboboxItem { get; set; }
        public string SelectedComboboxItem { get { return _selectedValue; } set { if (_selectedValue == value) return; _selectedValue = value; NotifyOfPropertyChange(() => SelectedComboboxItem); } }

        public LabelComboboxViewModel()
        {
            LabelWidth = 100;
        }
    }
}