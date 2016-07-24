using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Extensions;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels

{
    public class ArmyDetailViewModel : Screen, IHandle<UpdateView>, IArmyDetailView
    {
        private readonly IEventAggregator _event;
        private readonly IGameModel _model;

        private int _armyId;
        private string _armyName;
        private int _armyBook;
        private int _armyList;
        private int _minYear;
        private int _maxYear;
        private string _notes;

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

        public ArmyDetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
            Initialize();
        }

        public void Initialize()
        {
            ArmyIdControl = new LabelTextboxViewModel {Label = "Id:"};
            ArmyNameControl = new LabelTextboxViewModel {Label = "Name:"};
            ArmyBookControl = new LabelTextboxViewModel {Label = "Book:"};
            ArmyListControl = new LabelTextboxViewModel {Label = "List:"};
            MinYearControl = new LabelTextboxViewModel {Label = "Min Year:"};
            MaxYearControl = new LabelTextboxViewModel {Label = "Max Year:"};
            NotesControl = new LabelTextboxViewModel {Label = "Notes:", TextWrapping = "WrapWithOverflow" };
        }
        public void ClearArmyDetail()
        {
            ArmyId = 0;
            ArmyName = string.Empty;
            ArmyBook = 0;
            ArmyList = 0;
            MinYear = 0;
            MaxYear = 0;
            Notes = string.Empty;
        }

        public void Update()
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
            ArmyId = _model.AddArmyDefinition(definition);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Add()
        {
            //_model.CurrentArmyDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
            //_event.PublishOnCurrentThread(new UpdateTabPage("ArmyUnitTabPage"));
        }

        public void Delete()
        {
            _model.DeleteArmyDefinition(ArmyId);
            ClearArmyDetail();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectArmyDetail(int id)
        {
            var item = _model.GetArmyDefinition(id);
            ArmyId = item.Id;
            ArmyName = item.ArmyName;
            ArmyBook = item.ArmyBook;
            ArmyList = item.ArmyList;
            MinYear = item.MinYear;
            MaxYear = item.MaxYear;
            Notes = item.Notes;
        }

        public void Handle(UpdateView message)
        {
            if (_model.CurrentArmyDefinitionId == 0) ClearArmyDetail();
            else SelectArmyDetail(_model.CurrentArmyDefinitionId);
        }
    }
}