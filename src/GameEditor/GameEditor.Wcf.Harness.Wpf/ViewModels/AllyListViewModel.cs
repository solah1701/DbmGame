using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AllyListViewModel : ListViewModel
    {
        private readonly IGameModel _model;

        private AlliedArmyDefinition _selectedAllied;
        public BindableCollection<AlliedArmyDefinition> AlliedArmyDefinitions { get; set; }

        public AlliedArmyDefinition SelectedAlliedArmyDefinition
        {
            get { return _selectedAllied; }
            set
            {
                if (_selectedAllied == value) return;
                _selectedAllied = value; NotifyOfPropertyChange(() => SelectedAlliedArmyDefinition);
                if (!IsUpdating) SelectAlly(_selectedAllied.Id);
            }
        }

        public AllyListViewModel(IEventAggregator eventAggregator, IGameModel gameModel) : base(eventAggregator)
        {
            _model = gameModel;
            AlliedArmyDefinitions = new BindableCollection<AlliedArmyDefinition>();
        }

        public override void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetAlliedArmyDefinitions();
            if (items == null) return;
            AlliedArmyDefinitions.Clear();
            AlliedArmyDefinitions.AddRange(items);
#endif
        }

        public void Add()
        {
            _model.CurrentAllyDefinitionId = 0;
            EventAggregator.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectAlly(int allyId)
        {
            _model.CurrentAllyArmyDefinitionId = allyId;
            EventAggregator.PublishOnCurrentThread(new UpdateView());
        }
    }
}