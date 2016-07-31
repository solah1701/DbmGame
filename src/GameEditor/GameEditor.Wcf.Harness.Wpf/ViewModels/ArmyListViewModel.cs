using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ArmyListViewModel : ListViewModel
    {
        private readonly IGameModel _model;

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
                if (!IsUpdating && _selected != null) SelectArmy(_selected.Id);
            }
        }

        public ArmyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel) : base(eventAggregator)
        {
            _model = gameModel;
            ArmyDefinitions = new BindableCollection<ArmyDefinition>();
            PopulateList();
        }

        public override void PopulateList()
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
            EventAggregator.PublishOnUIThread(new UpdateView());
        }

        public void SelectArmy(int armyId)
        {
            // Navigate to Detail page
            _model.CurrentArmyDefinitionId = armyId;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _model.CurrentAllyDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            EventAggregator.PublishOnUIThread(new UpdateView());
            EventAggregator.PublishOnUIThread(new UpdateList());
        }
    }
}