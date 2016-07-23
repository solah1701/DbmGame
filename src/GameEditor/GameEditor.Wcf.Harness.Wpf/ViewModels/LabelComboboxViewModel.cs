using System.Windows.Data;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class LabelComboboxViewModel : LabelViewModelBase
    {
        private CollectionView _itemSource;
        private string _displayMemberPath;
        private string _selectedValuePath;
        private string _selectedValue;

        public CollectionView ItemSource { get { return _itemSource; } set { _itemSource = value; NotifyOfPropertyChange(() => ItemSource); } }
        public string DisplayMemberPath { get { return _displayMemberPath; } set { if (_displayMemberPath == value) return; _displayMemberPath = value; NotifyOfPropertyChange(() => DisplayMemberPath); } }
        public string SelectedValuePath { get { return _selectedValuePath; } set { if (_selectedValuePath == value) return; _selectedValuePath = value; NotifyOfPropertyChange(() => SelectedValuePath); } }
        public string SelectedValue { get { return _selectedValue; } set { if (_selectedValue == value) return; _selectedValue = value; NotifyOfPropertyChange(() => SelectedValue); } }

        public LabelComboboxViewModel()
        {
            LabelWidth = 100;
        }
    }
}