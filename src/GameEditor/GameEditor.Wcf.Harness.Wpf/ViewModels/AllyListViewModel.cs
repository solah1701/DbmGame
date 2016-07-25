using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AllyListViewModel : Screen, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        private AlliedArmyDefinition _selectedAllied;
        private AlliedArmyDefinitions _alliedArmyDefinitions;
        public AlliedArmyDefinitions AlliedArmyDefinitions => _alliedArmyDefinitions;

        public AlliedArmyDefinition SelectedAlliedArmyDefinition
        {
            get { return _selectedAllied; }
            set
            {
                if (_selectedAllied == value) return;
                _selectedAllied = value; NotifyOfPropertyChange(() => SelectedAlliedArmyDefinition);
                SelectAlly(_selectedAllied.Id);
            }
        }

        public AllyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
            PopulateList();
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetAlliedArmyDefinitions();
            if (items == null) return;
            _alliedArmyDefinitions = items;
#endif
        }

        public void Add()
        {
            _model.CurrentAllyDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectAlly(int allyId)
        {
            _model.CurrentAllyDefinitionId = allyId;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}