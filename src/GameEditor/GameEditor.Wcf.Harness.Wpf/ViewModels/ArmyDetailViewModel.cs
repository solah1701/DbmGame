using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
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

        public int ArmyId { get { return _armyId; } set { _armyId = value; NotifyOfPropertyChange(() => ArmyId); } }
        public string ArmyName { get { return _armyName; } set { _armyName = value; NotifyOfPropertyChange(() => ArmyName); } }
        public int ArmyBook { get { return _armyBook; } set { _armyBook = value; NotifyOfPropertyChange(() => ArmyBook); } }
        public int ArmyList { get { return _armyList; } set { _armyList = value; NotifyOfPropertyChange(() => ArmyList); } }
        public int MinYear { get { return _minYear; } set { _minYear = value; NotifyOfPropertyChange(() => MinYear); } }
        public int MaxYear { get { return _maxYear; } set { _maxYear = value; NotifyOfPropertyChange(() => MaxYear); } }
        public string Notes { get { return _notes; } set { _notes = value; NotifyOfPropertyChange(() => Notes); } }

        public ArmyDetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
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