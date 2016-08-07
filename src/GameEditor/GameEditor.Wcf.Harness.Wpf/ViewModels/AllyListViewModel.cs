using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AllyListViewModel : ListViewModel, IAllyListViewModel
    {
        private AlliedArmyDefinition _selectedAllied;
        public BindableCollection<AlliedArmyDefinition> AlliedArmyDefinitions { get; }

        public AlliedArmyDefinition SelectedAlliedArmyDefinition
        {
            get { return _selectedAllied; }
            set
            {
                if (_selectedAllied == value) return;
                _selectedAllied = value; NotifyOfPropertyChange(() => SelectedAlliedArmyDefinition);
                if (!IsUpdating && _selectedAllied != null) Select(_selectedAllied.Id);
            }
        }

        public AllyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
            AlliedArmyDefinitions = new BindableCollection<AlliedArmyDefinition>();
        }

        public override void PopulateList()
        {
#if !DESIGNMODE
            var items = GameModel.GetAlliedArmyDefinitions();
            if (items == null) return;
            AlliedArmyDefinitions.Clear();
            AlliedArmyDefinitions.AddRange(items);
#endif
        }

        public override void Add()
        {
            GameModel.CurrentAllyDefinitionId = 0;
            base.Add();
        }

        public override void Select(int allyId)
        {
            GameModel.CurrentAllyArmyDefinitionId = allyId;
            base.Select(allyId);
        }
    }
}