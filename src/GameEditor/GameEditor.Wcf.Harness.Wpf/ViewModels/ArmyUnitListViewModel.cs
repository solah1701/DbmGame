using System.Collections.Generic;
using System.Windows.Media;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ArmyUnitListViewModel : ListViewModel
    {
        private readonly IGameModel _model;
        private ArmyUnitDefinition _selected;
        private Dictionary<int, IndexedItem> ListIndex { get; set; }

        //private ObservableCollection<ArmyUnitDefinition> _armyUnitDefinitions;
        public BindableCollection<ArmyUnitDefinition> ArmyUnitDefinitions { get; set; }

        public ArmyUnitDefinition SelectedArmyUnitDefinition
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                NotifyOfPropertyChange(() => SelectedArmyUnitDefinition);
                if (!IsUpdating && _selected != null) Select(_selected.Id);
            }
        }

        public Dictionary<int, IndexedItem> IndexedItemDictionary { get; set; }

        public class IndexedItem
        {
            public int Id { get; set; }
            public Color BackgroundColor { get; set; }
        }

        public ArmyUnitListViewModel(IEventAggregator eventAggregator, IGameModel gameModel) : base(eventAggregator, gameModel)
        {
            _model = gameModel;
            ArmyUnitDefinitions = new BindableCollection<ArmyUnitDefinition>();
        }

        public override void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetArmyUnitDefinitions();
            var altItems = _model.GetAlternativeUnitDefinitions();
            if (items == null) return;
            ListIndex = new Dictionary<int, IndexedItem>();
            //var count = 0;
            //foreach (var armyUnitDefinition in items)
            //{
            //    var altItem = altItems.Find(a => a.AlternativeUnitId == armyUnitDefinition.Id);
            //    var colour = altItem != null ? Color.FromArgb(255, 255, 255, 255) : Color.FromArgb(127, 255, 0, 0);
            //    ListIndex.Add(count++, new IndexedItem { Id = armyUnitDefinition.Id, BackgroundColor = colour });
            //}
            ArmyUnitDefinitions.Clear();
            ArmyUnitDefinitions.AddRange(items);
            IndexedItemDictionary = ListIndex;
#endif
        }

        public override void Add()
        {
            // Navigate to Detail page
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            base.Add();
        }

        public override void Select(int id)
        {
            // Navigate to Detail page
            _model.CurrentArmyUnitDefinitionId = id;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            PublishToUI(new UpdateList());
            base.Select(id);
        }
    }
}