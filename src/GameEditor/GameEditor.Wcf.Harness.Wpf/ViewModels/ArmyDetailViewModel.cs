using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Extensions;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels

{
    public class ArmyDetailViewModel : DetailViewModel, IArmyDetailView
    {
        //private int _armyId;
        //private string _armyName;
        //private int _armyBook;
        //private int _armyList;
        //private int _minYear;
        //private int _maxYear;
        //private string _notes;

        public LabelTextboxViewModel ArmyIdControl { get; set; }
        public LabelTextboxViewModel ArmyNameControl { get; set; }
        public LabelTextboxViewModel ArmyBookControl { get; set; }
        public LabelTextboxViewModel ArmyListControl { get; set; }
        public LabelTextboxViewModel MinYearControl { get; set; }
        public LabelTextboxViewModel MaxYearControl { get; set; }
        public LabelTextboxViewModel NotesControl { get; set; }

        public int ArmyId { get { return ArmyIdControl.TextBox.ConvertToInt(); } set { ArmyIdControl.TextBox = value.ToString(); NotifyOfPropertyChange(() => ArmyIdControl); } }
        public string ArmyName { get { return ArmyNameControl.TextBox; } set { ArmyNameControl.TextBox = value; NotifyOfPropertyChange(() => ArmyNameControl); } }
        public int ArmyBook { get { return ArmyBookControl.TextBox.ConvertToInt(); } set { ArmyBookControl.TextBox = value.ToString(); NotifyOfPropertyChange(() => ArmyBookControl); } }
        public int ArmyList { get { return ArmyListControl.TextBox.ConvertToInt(); } set { ArmyListControl.TextBox = value.ToString(); NotifyOfPropertyChange(() => ArmyListControl); } }
        public int MinYear { get { return MinYearControl.TextBox.ConvertToInt(); } set { MinYearControl.TextBox = value.ToString(); NotifyOfPropertyChange(() => MinYearControl); } }
        public int MaxYear { get { return MaxYearControl.TextBox.ConvertToInt(); } set { MaxYearControl.TextBox = value.ToString(); NotifyOfPropertyChange(() => MaxYearControl); } }
        public string Notes { get { return NotesControl.TextBox; } set { NotesControl.TextBox = value; NotifyOfPropertyChange(() => NotesControl); } }

        protected override int CurrentId => GameModel.CurrentArmyDefinitionId;

        public ArmyDetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
            InitialiseView();
        }

        protected override void InitialiseView()
        {
            ArmyIdControl = new LabelTextboxViewModel(EventAggregator) { Label = "Id:" };
            ArmyNameControl = new LabelTextboxViewModel(EventAggregator) { Label = "Name:" };
            ArmyBookControl = new LabelTextboxViewModel(EventAggregator) { Label = "Book:" };
            ArmyListControl = new LabelTextboxViewModel(EventAggregator) { Label = "List:" };
            MinYearControl = new LabelTextboxViewModel(EventAggregator) { Label = "Min Year:" };
            MaxYearControl = new LabelTextboxViewModel(EventAggregator) { Label = "Max Year:" };
            NotesControl = new LabelTextboxViewModel(EventAggregator) { Label = "Notes:", TextWrapping = "WrapWithOverflow" };
            base.InitialiseView();
        }

        public override void ClearDetail()
        {
            ArmyId = 0;
            ArmyName = string.Empty;
            ArmyBook = 0;
            ArmyList = 0;
            MinYear = 0;
            MaxYear = 0;
            Notes = string.Empty;
            base.ClearDetail();
        }

        public override void Update()
        {
            var definition = new ArmyDefinition
            {
                Id = ArmyId,
                ArmyName = ArmyName,
                ArmyBook = ArmyBook,
                ArmyList = ArmyList,
                MinYear = MinYear,
                MaxYear = MaxYear,
                Notes = Notes
            };
            ArmyId = GameModel.AddArmyDefinition(definition);
            base.Update();
        }

        public override void Delete()
        {
            GameModel.DeleteArmyDefinition(ArmyId);
            base.Delete();
        }

        public override void SelectDetail(int currentId)
        {
            var item = GameModel.GetArmyDefinition(currentId);
            ArmyId = item.Id;
            ArmyName = item.ArmyName;
            ArmyBook = item.ArmyBook;
            ArmyList = item.ArmyList;
            MinYear = item.MinYear;
            MaxYear = item.MaxYear;
            Notes = item.Notes;
            base.SelectDetail(currentId);
        }
    }
}