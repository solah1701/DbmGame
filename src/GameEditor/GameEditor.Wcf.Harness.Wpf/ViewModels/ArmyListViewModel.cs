using System.Collections.ObjectModel;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ArmyListViewModel : Screen, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;
        private bool _updatingList;

        private ArmyDefinition _selected;

        public BindableCollection<ArmyDefinition> ArmyDefinitions { get; set; }

        public ArmyDefinition SelectedArmyDefinition
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                NotifyOfPropertyChange(() => SelectedArmyDefinition);
                if (!_updatingList && _selected != null) SelectArmy(_selected.Id);
            }
        }

        public ArmyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
            ArmyDefinitions = new BindableCollection<ArmyDefinition>();
            PopulateList();
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            ArmyDefinitions.Clear();
            ArmyDefinitions.AddRange(_model.GetArmyDefinitions());
#endif
        }

        public void AddArmy()
        {
            _model.CurrentArmyDefinitionId = 0;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _model.CurrentAllyDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnUIThread(new UpdateView());
        }

        public void SelectArmy(int armyId)
        {
            // Navigate to Detail page
            _model.CurrentArmyDefinitionId = armyId;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _model.CurrentAllyDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnUIThread(new UpdateView());
            _event.PublishOnUIThread(new UpdateList());
        }

        public void Handle(UpdateView message)
        {
            _updatingList = true;
            PopulateList();
            _updatingList = false;
        }
    }
}