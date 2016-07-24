using System;
using System.Collections.Generic;
using System.Windows.Data;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Helpers;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ArmyUnitDetailViewModel : Screen, IHandle<UpdateView>, IArmyUnitDetailView
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public ArmyUnitDetailViewModel(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
            InitialiseView();
        }

        protected void InitialiseView()
        {
            IdControl = new LabelTextboxViewModel { Label = "Id:" };
            NameControl = new LabelTextboxViewModel { Label = "Name:" };
            CostControl = new LabelTextboxViewModel { Label = "Cost:" };
            MinCountControl = new LabelTextboxViewModel { Label = "Min Count:" };
            MaxCountControl = new LabelTextboxViewModel { Label = "Max Count:" };
            MinYearControl = new LabelTextboxViewModel { Label = "Min Year:" };
            MaxYearControl = new LabelTextboxViewModel { Label = "Max Year:" };
            IsAllyControl = new LabelCheckboxViewModel { Label = "Ally:" };
            IsGeneralControl = new LabelCheckboxViewModel { Label = "General:" };
            IsChariotControl = new LabelCheckboxViewModel { Label = "Chariot:" };
            IsDoubleElementControl = new LabelCheckboxViewModel { Label = "Double Element:" };
            IsMountedInfantryControl = new LabelCheckboxViewModel { Label = "Mounted Infantry:" };
            DisciplineTypeControl = new LabelComboboxViewModel { Label = "Discipline Type:", ComboboxItem = EnumHelper.ListOfString<DisciplineTypeEnum>() };
            UnitTypeControl = new LabelComboboxViewModel { Label = "Unit Type:", ComboboxItem = EnumHelper.ListOfString<UnitTypeEnum>() };
            DispositionTypeControl = new LabelComboboxViewModel { Label = "Disposition Type:", ComboboxItem = EnumHelper.ListOfString<DispositionTypeEnum>() };
            //DispositionTypeControl = new LabelComboboxViewModel { Label = "Disposition Type:", ItemSource = new CollectionView(Enum.GetValues(typeof(DispositionTypeEnum))), DisplayMemberPath = "DispositionTypeEnum", SelectedValuePath = "DispositionTypeEnum" };
            GradeTypeControl = new LabelComboboxViewModel { Label = "Grade Type:", ComboboxItem = EnumHelper.ListOfString<GradeTypeEnum>() };

            //base.InitialiseView();
            //DisciplineData = Enum.GetValues(typeof(DisciplineTypeEnum));
            //UnitData = Enum.GetValues(typeof(UnitTypeEnum));
            //DispositionData = Enum.GetValues(typeof(DispositionTypeEnum));
            //GradeData = Enum.GetValues(typeof(GradeTypeEnum));
            //ShowAlternativeList = true;
            ViewChanged();
        }

        protected void ViewChanged()
        {
            CanUpdate = ArmyUnitName != string.Empty && MaxCount != 0;
            CanCopy = ArmyUnitDefinitionId != 0;
            CanDelete = ArmyUnitDefinitionId != 0;
        }

        public void CopyArmyUnitDetail()
        {
            ArmyUnitDefinitionId = 0;
            ViewChanged();
        }

        private void ClearArmyUnitDetail()
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
        }

        public void UpdateArmyUnitDetail()
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
            ArmyUnitDefinitionId = _model.AddArmyUnitDefinition(definition);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void DeleteArmyUnitDetail()
        {
            _model.DeleteArmyUnitDefinition(ArmyUnitDefinitionId);
            ClearArmyUnitDetail();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        private void SelectArmyUnitDetail(int id)
        {
            var item = _model.GetArmyUnitDefinition(id);
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
        }

        public void Handle(UpdateView message)
        {
            if (_model.CurrentArmyUnitDefinitionId == 0) ClearArmyUnitDetail();
            else SelectArmyUnitDetail(_model.CurrentArmyUnitDefinitionId);
            ViewChanged();
        }

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

        public bool CanUpdate { get; set; }
        public bool CanCopy { get; set; }
        public bool CanDelete { get; set; }
    }
}