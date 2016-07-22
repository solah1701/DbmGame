using System.Collections.Generic;
using System.Windows.Media;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class ArmyUnitListViewModel : Screen, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;
        private ArmyUnitDefinition _selected;
        private Dictionary<int, IndexedItem> ListIndex { get; set; }

        public ArmyUnitDefinitions ArmyUnitDefinitions { get; set; }
        public ArmyUnitDefinition SelecteArmyUnitDefinition
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                NotifyOfPropertyChange(() => SelecteArmyUnitDefinition);
                SelectUnitArmy(_selected.Id);
            }
        }

        public Dictionary<int, IndexedItem> IndexedItemDictionary { get; set; }

        public class IndexedItem
        {
            public int Id { get; set; }
            public Color BackgroundColor { get; set; }
        }

        public ArmyUnitListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        public void PopulateList()
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
            ArmyUnitDefinitions = items;
            IndexedItemDictionary = ListIndex;
#endif
        }

        public void AddArmyUnit()
        {
            // Navigate to Detail page
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectUnitArmy(int armyUnitId)
        {
            // Navigate to Detail page
            _model.CurrentArmyUnitDefinitionId = armyUnitId;
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}