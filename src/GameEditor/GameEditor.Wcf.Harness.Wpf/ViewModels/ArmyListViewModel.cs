using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ArmyListViewModel : Screen, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        private ArmyDefinition _selected;

        public ArmyDefinitions ArmyDefinitions { get; set; }

        public ArmyDefinition SelectedArmyDefinition
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                NotifyOfPropertyChange(() =>  SelectedArmyDefinition);
                SelectArmy(_selected.Id);
            }
        }

        public ArmyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
            PopulateList();
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetArmyDefinitions();
            ArmyDefinitions = items;
#endif
        }

        public void AddArmy()
        {
            _model.CurrentArmyDefinitionId = 0;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _model.CurrentAllyDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectArmy(int armyId)
        {
            // Navigate to Detail page
            _model.CurrentArmyDefinitionId = armyId;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _model.CurrentAllyDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}