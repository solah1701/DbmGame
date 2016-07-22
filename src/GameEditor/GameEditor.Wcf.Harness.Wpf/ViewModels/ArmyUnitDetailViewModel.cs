using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
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
            IsAllyControl = new LabelCheckboxViewModel { Label = "Is Ally:" };
            IsGeneralControl = new LabelCheckboxViewModel { Label = "Is General:" };
            IsChariotControl = new LabelCheckboxViewModel { Label = "Is Chariot:" };
            IsDoubleElementControl = new LabelCheckboxViewModel { Label = "Is Double Element:" };
            IsMountedInfantryControl = new LabelCheckboxViewModel { Label = "Is Mounted Infantry:" };
            DisciplineTypeControl = new LabelTextboxViewModel { Label = "Discipline Type:" };
            UnitTypeControl = new LabelTextboxViewModel { Label = "Unit Type:" };
            DispositionTypeControl = new LabelTextboxViewModel { Label = "Disposition Type:" };
            GradeTypeControl = new LabelTextboxViewModel { Label = "Grade Type:" };

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

        public LabelTextboxViewModel DisciplineTypeControl { get; set; }
        public LabelTextboxViewModel UnitTypeControl { get; set; }
        public LabelTextboxViewModel DispositionTypeControl { get; set; }
        public LabelTextboxViewModel GradeTypeControl { get; set; }

        public int ArmyUnitDefinitionId
        {
            get
            {
                int value;
                return int.TryParse(IdControl.TextBox, out value) ? value : 0;
            }
            set
            {
                IdControl.TextBox = value.ToString(); NotifyOfPropertyChange(() => IdControl);
            }
        }
        public string ArmyUnitName { get; set; }
        public decimal? Cost { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public bool IsAlly { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsChariot { get; set; }
        public bool IsDoubleElement { get; set; }
        public bool IsMountedInfantry { get; set; }
        public DisciplineTypeEnum DisciplineType { get; set; }
        public UnitTypeEnum UnitType { get; set; }
        public DispositionTypeEnum DispositionType { get; set; }
        public GradeTypeEnum GradeType { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanCopy { get; set; }
        public bool CanDelete { get; set; }
    }
}