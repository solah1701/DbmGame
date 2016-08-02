using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class ArmyListViewModel : ListViewModel
    {
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
                if (!IsUpdating && _selected != null) Select(_selected.Id);
            }
        }

        public ArmyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel) : base(eventAggregator, gameModel)
        {
            ArmyDefinitions = new BindableCollection<ArmyDefinition>();
            PopulateList();
        }

        public override void PopulateList()
        {
#if !DESIGNMODE
            ArmyDefinitions.Clear();
            ArmyDefinitions.AddRange(GameModel.GetArmyDefinitions());
#endif
        }

        public override void Add()
        {
            GameModel.CurrentArmyDefinitionId = 0;
            GameModel.CurrentArmyUnitDefinitionId = 0;
            GameModel.CurrentAllyArmyDefinitionId = 0;
            GameModel.CurrentAllyDefinitionId = 0;
            GameModel.CurrentAlternativeUnitDefinitionId = 0;
            base.Add();
        }

        public override void Select(int armyId)
        {
            // Navigate to Detail page
            GameModel.CurrentArmyDefinitionId = armyId;
            GameModel.CurrentArmyUnitDefinitionId = 0;
            GameModel.CurrentAllyArmyDefinitionId = 0;
            GameModel.CurrentAllyDefinitionId = 0;
            GameModel.CurrentAlternativeUnitDefinitionId = 0;
            EventAggregator.PublishOnUIThread(new UpdateList());
            base.Select(armyId);
        }
    }
}