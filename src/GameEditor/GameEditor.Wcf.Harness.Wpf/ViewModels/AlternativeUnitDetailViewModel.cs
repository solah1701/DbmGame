using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Extensions;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class AlternativeUnitDetailViewModel : DetailViewModel, IAlternativeUnitDetailViewModel
    {
        public LabelTextboxViewModel AlternativeUnitIdControl { get; set; }
        public LabelComboboxViewModel AlternativeUnitNameControl { get; set; }
        public LabelTextboxViewModel MinValueControl { get; set; }
        public LabelTextboxViewModel MaxValueControl { get; set; }
        public LabelCheckboxViewModel PercentControl { get; set; }
        public LabelCheckboxViewModel UpgradeControl { get; set; }
        public LabelTextboxViewModel AlternativeIdControl { get; set; }

        public int AlternativeUnitId
        {
            get
            {
                int value;
                return int.TryParse(AlternativeUnitIdControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (AlternativeUnitIdControl.TextBox == value.ToString()) return;
                AlternativeUnitIdControl.TextBox = value.ToString();
            }
        }
        public string AlternativeUnitName
        {
            get { return AlternativeUnitNameControl.SelectedComboboxItem; }
            set
            {
                if (AlternativeUnitNameControl.SelectedComboboxItem == value) return;
                AlternativeUnitNameControl.SelectedComboboxItem = value;
            }
        }
        public int MinValue
        {
            get
            {
                int value;
                return int.TryParse(MinValueControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MinValueControl.TextBox == value.ToString()) return;
                MinValueControl.TextBox = value.ToString();
            }
        }
        public int MaxValue
        {
            get
            {
                int value;
                return int.TryParse(MaxValueControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MaxValueControl.TextBox == value.ToString()) return;
                MaxValueControl.TextBox = value.ToString();
            }
        }
        public bool Percent
        {
            get { return PercentControl.CheckBox; }
            set
            {
                if (PercentControl.CheckBox == value) return;
                PercentControl.CheckBox = value;
            }
        }
        public bool Upgrade
        {
            get { return UpgradeControl.CheckBox; }
            set
            {
                if (UpgradeControl.CheckBox == value) return;
                UpgradeControl.CheckBox = value;
            }
        }
        public int AlternativeId
        {
            get
            {
                int value;
                return int.TryParse(AlternativeIdControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (AlternativeIdControl.TextBox == value.ToString()) return;
                AlternativeIdControl.TextBox = value.ToString();
            }
        }

        protected override int CurrentId => GameModel.CurrentAlternativeUnitDefinitionId;

        public AlternativeUnitDetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
            DisplayName = "Alt Detail";
            InitialiseView();
        }

        protected override void InitialiseView()
        {
            AlternativeUnitIdControl = new LabelTextboxViewModel(EventAggregator) { Label = "Id:" };
            PopulateList();
            MinValueControl = new LabelTextboxViewModel(EventAggregator) { Label = "Min Value:" };
            MaxValueControl = new LabelTextboxViewModel(EventAggregator) { Label = "Max Value:" };
            PercentControl = new LabelCheckboxViewModel { Label = "Percent" };
            UpgradeControl = new LabelCheckboxViewModel { Label = "Upgrade" };
            AlternativeIdControl = new LabelTextboxViewModel(EventAggregator) { Label = "Alt Id:" };
            base.InitialiseView();
        }

        private void PopulateList()
        {
            var definitions = GameModel.GetArmyUnitDefinitions();
            AlternativeUnitNameControl = new LabelComboboxViewModel { Label = "Name:", ComboboxItem = definitions.ConvertToStringList(GameModel.CurrentArmyDefinitionId) };
        }

        protected override void ViewChanged()
        {
            AlternativeUnitIdControl.CanTextBox = false;
            AlternativeIdControl.CanTextBox = false;
            MinValueControl.CanTextBox = MaxValueControl.CanTextBox = Upgrade;
            CanUpdate = !string.IsNullOrEmpty(AlternativeUnitName);
            CanDelete = AlternativeUnitId > 0;
            CanCopy = AlternativeUnitId > 0;
            base.ViewChanged();
        }

        public override void Clear()
        {
            AlternativeUnitId = 0;
            AlternativeUnitName = string.Empty;
            MinValue = 0;
            MaxValue = 0;
            Percent = false;
            Upgrade = false;
            AlternativeId = 0;
            base.Clear();
        }

        public override void Select(int currentId)
        {
            var item = GameModel.GetAlternativeUnitDefinition(currentId);
            if (item == null) return;
            AlternativeUnitId = item.Id;
            AlternativeUnitName = item.Name;
            MinValue = item.MinValue;
            MaxValue = item.MaxValue;
            Percent = item.Percent;
            Upgrade = item.Upgrade;
            AlternativeId = item.AlternativeUnitId;
            base.Select(currentId);
        }

        public override void Handle(UpdateView message)
        {
            if (GameModel.CurrentArmyUnitDefinitionId != 0) PopulateList();
            base.Handle(message);
        }

        public void ShowList() { }
    }
}