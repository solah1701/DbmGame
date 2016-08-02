using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Helpers;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyUnitDetailViewModel : DetailViewModel, IArmyUnitDetailView
    {
        public LabelTextboxViewModel IdControl { get; set; }
        public LabelTextboxViewModel NameControl { get; set; }
        public LabelTextboxViewModel CostControl { get; set; }
        public LabelTextboxViewModel MinCountControl { get; set; }
        public LabelTextboxViewModel MaxCountControl { get; set; }
        public LabelTextboxViewModel MinYearControl { get; set; }
        public LabelTextboxViewModel MaxYearControl { get; set; }

        public LabelCheckboxViewModel IsAllyControl { get; set; }
        public LabelCheckboxViewModel IsGeneralControl { get; set; }
        public LabelCheckboxViewModel IsChariotControl { get; set; }
        public LabelCheckboxViewModel IsDoubleElementControl { get; set; }
        public LabelCheckboxViewModel IsMountedInfantryControl { get; set; }

        public LabelComboboxViewModel DisciplineTypeControl { get; set; }
        public LabelComboboxViewModel UnitTypeControl { get; set; }
        public LabelComboboxViewModel DispositionTypeControl { get; set; }
        public LabelComboboxViewModel GradeTypeControl { get; set; }

        public AlternativeUnitViewModel AlternativeTabControl { get; set; }

        public int ArmyUnitDefinitionId
        {
            get
            {
                int value;
                return int.TryParse(IdControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (IdControl.TextBox == value.ToString()) return; IdControl.TextBox = value.ToString();
            }
        }
        public string ArmyUnitName
        {
            get { return NameControl.TextBox; }
            set
            {
                if (NameControl.TextBox == value) return; NameControl.TextBox = value;
            }
        }

        public decimal? Cost
        {
            get
            {
                decimal value;
                return decimal.TryParse(CostControl.TextBox, out value) ? value : 0;
            }
            set { if (CostControl.TextBox == value.ToString()) return; CostControl.TextBox = value.ToString(); }
        }

        public int MinCount
        {
            get
            {
                int value;
                return int.TryParse(MinCountControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MinCountControl.TextBox == value.ToString()) return;
                MinCountControl.TextBox = value.ToString();
            }
        }
        public int MaxCount
        {
            get
            {
                int value;
                return int.TryParse(MaxCountControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MaxCountControl.TextBox == value.ToString()) return;
                MaxCountControl.TextBox = value.ToString();
            }
        }
        public int MinYear
        {
            get
            {
                int value;
                return int.TryParse(MinYearControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MinYearControl.TextBox == value.ToString()) return;
                MinYearControl.TextBox = value.ToString();
            }
        }
        public int MaxYear
        {
            get
            {
                int value;
                return int.TryParse(MaxYearControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MaxYearControl.TextBox == value.ToString()) return;
                MaxYearControl.TextBox = value.ToString();
            }
        }
        public bool IsAlly { get { return IsAllyControl.CheckBox; } set { if (IsAllyControl.CheckBox == value) return; IsAllyControl.CheckBox = value; } }
        public bool IsGeneral { get { return IsGeneralControl.CheckBox; } set { if (IsGeneralControl.CheckBox == value) return; IsGeneralControl.CheckBox = value; } }
        public bool IsChariot { get { return IsChariotControl.CheckBox; } set { if (IsChariotControl.CheckBox == value) return; IsChariotControl.CheckBox = value; } }
        public bool IsDoubleElement { get { return IsDoubleElementControl.CheckBox; } set { if (IsDoubleElementControl.CheckBox == value) return; IsDoubleElementControl.CheckBox = value; } }
        public bool IsMountedInfantry { get { return IsMountedInfantryControl.CheckBox; } set { if (IsMountedInfantryControl.CheckBox == value) return; IsMountedInfantryControl.CheckBox = value; } }

        public DisciplineTypeEnum DisciplineType
        {
            get
            {
                return EnumHelper.ParseString<DisciplineTypeEnum>(DisciplineTypeControl.SelectedComboboxItem);
            }
            set
            {
                if (DisciplineTypeControl.SelectedComboboxItem == value.ToString()) return;
                DisciplineTypeControl.SelectedComboboxItem = value.ToString();
                NotifyOfPropertyChange(() => DisciplineTypeControl);
            }
        }
        public UnitTypeEnum UnitType
        {
            get
            {
                return EnumHelper.ParseString<UnitTypeEnum>(UnitTypeControl.SelectedComboboxItem);
            }
            set
            {
                if (UnitTypeControl.SelectedComboboxItem == value.ToString()) return;
                UnitTypeControl.SelectedComboboxItem = value.ToString();
                NotifyOfPropertyChange(() => UnitTypeControl);
            }
        }
        public DispositionTypeEnum DispositionType
        {
            get
            {
                return EnumHelper.ParseString<DispositionTypeEnum>(DispositionTypeControl.SelectedComboboxItem);
            }
            set
            {
                if (DispositionTypeControl.SelectedComboboxItem == value.ToString()) return;
                DispositionTypeControl.SelectedComboboxItem = value.ToString();
                NotifyOfPropertyChange(() => DispositionTypeControl);
            }
        }
        public GradeTypeEnum GradeType
        {
            get
            {
                return EnumHelper.ParseString<GradeTypeEnum>(GradeTypeControl.SelectedComboboxItem);
            }
            set
            {
                if (GradeTypeControl.SelectedComboboxItem == value.ToString()) return;
                GradeTypeControl.SelectedComboboxItem = value.ToString();
                NotifyOfPropertyChange(() => GradeTypeControl);
            }
        }

        protected override int CurrentId => GameModel.CurrentArmyUnitDefinitionId;

        public ArmyUnitDetailViewModel(IEventAggregator eventAggregator, IGameModel model, AlternativeUnitViewModel alternativeUnitView)
            : base(eventAggregator, model)
        {
            AlternativeTabControl = alternativeUnitView;
            InitialiseView();
        }

        protected override void InitialiseView()
        {
            IdControl = new LabelTextboxViewModel(EventAggregator) { Label = "Id:" };
            NameControl = new LabelTextboxViewModel(EventAggregator) { Label = "Name:" };
            CostControl = new LabelTextboxViewModel(EventAggregator) { Label = "Cost:" };
            MinCountControl = new LabelTextboxViewModel(EventAggregator) { Label = "Min Count:" };
            MaxCountControl = new LabelTextboxViewModel(EventAggregator) { Label = "Max Count:" };
            MinYearControl = new LabelTextboxViewModel(EventAggregator) { Label = "Min Year:" };
            MaxYearControl = new LabelTextboxViewModel(EventAggregator) { Label = "Max Year:" };
            IsAllyControl = new LabelCheckboxViewModel { Label = "Ally:" };
            IsGeneralControl = new LabelCheckboxViewModel { Label = "General:" };
            IsChariotControl = new LabelCheckboxViewModel { Label = "Chariot:" };
            IsDoubleElementControl = new LabelCheckboxViewModel { Label = "Double Element:" };
            IsMountedInfantryControl = new LabelCheckboxViewModel { Label = "Mounted Infantry:" };
            DisciplineTypeControl = new LabelComboboxViewModel { Label = "Discipline Type:", ComboboxItem = EnumHelper.ListOfString<DisciplineTypeEnum>() };
            UnitTypeControl = new LabelComboboxViewModel { Label = "Unit Type:", ComboboxItem = EnumHelper.ListOfString<UnitTypeEnum>() };
            DispositionTypeControl = new LabelComboboxViewModel { Label = "Disposition Type:", ComboboxItem = EnumHelper.ListOfString<DispositionTypeEnum>() };
            GradeTypeControl = new LabelComboboxViewModel { Label = "Grade Type:", ComboboxItem = EnumHelper.ListOfString<GradeTypeEnum>() };

            //base.InitialiseView();
            //DisciplineData = Enum.GetValues(typeof(DisciplineTypeEnum));
            //UnitData = Enum.GetValues(typeof(UnitTypeEnum));
            //DispositionData = Enum.GetValues(typeof(DispositionTypeEnum));
            //GradeData = Enum.GetValues(typeof(GradeTypeEnum));
            //ShowAlternativeList = true;
            base.InitialiseView();
        }

        protected override void ViewChanged()
        {
            CanUpdate = ArmyUnitName != string.Empty && MaxCount != 0;
            CanCopy = ArmyUnitDefinitionId != 0;
            CanDelete = ArmyUnitDefinitionId != 0;
            base.ViewChanged();
        }

        public override void Copy()
        {
            ArmyUnitDefinitionId = 0;
            base.Copy();
        }

        public override void Clear()
        {
            ArmyUnitDefinitionId = 0;
            ArmyUnitName = string.Empty;
            Cost = 0;
            MinCount = 0;
            MaxCount = 0;
            MinYear = 0;
            MaxYear = 0;
            IsAlly = false;
            IsGeneral = false;
            IsChariot = false;
            IsDoubleElement = false;
            IsMountedInfantry = false;
            DisciplineType = 0;
            UnitType = 0;
            DispositionType = 0;
            GradeType = 0;
            base.Clear();
        }

        public override void Update()
        {
            var definition = new ArmyUnitDefinition
            {
                Id = ArmyUnitDefinitionId,
                UnitName = ArmyUnitName,
                Cost = Cost,
                MinCount = MinCount,
                MaxCount = MaxCount,
                MinYear = MinYear,
                MaxYear = MaxYear,
                IsAlly = IsAlly,
                IsGeneral = IsGeneral,
                IsChariot = IsChariot,
                IsDoubleElement = IsDoubleElement,
                IsMountedInfantry = IsMountedInfantry,
                DisciplineType = DisciplineType,
                UnitType = UnitType,
                DispositionType = DispositionType,
                GradeType = GradeType
            };
            ArmyUnitDefinitionId = GameModel.AddArmyUnitDefinition(definition);
            base.Update();
        }

        public override void Delete()
        {
            GameModel.DeleteArmyUnitDefinition(ArmyUnitDefinitionId);
            base.Delete();
        }

        public override void Select(int currentId)
        {
            var item = GameModel.GetArmyUnitDefinition(currentId);
            if (item == null) return;
            ArmyUnitDefinitionId = item.Id;
            ArmyUnitName = item.UnitName;
            Cost = item.Cost;
            MinCount = item.MinCount;
            MaxCount = item.MaxCount;
            MinYear = item.MinYear;
            MaxYear = item.MaxYear;
            IsAlly = item.IsAlly;
            IsGeneral = item.IsGeneral;
            IsChariot = item.IsChariot;
            IsDoubleElement = item.IsDoubleElement;
            IsMountedInfantry = item.IsMountedInfantry;
            DisciplineType = item.DisciplineType;
            UnitType = item.UnitType;
            DispositionType = item.DispositionType;
            GradeType = item.GradeType;
            base.Select(currentId);
        }
    }
}