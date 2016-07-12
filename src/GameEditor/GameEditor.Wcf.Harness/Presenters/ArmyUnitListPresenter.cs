//#define DESIGNMODE

using System.Collections.Generic;
using System.Drawing;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class ArmyUnitListPresenter : Controller<IArmyUnitListView>, IArmyUnitListPresenter, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;
        private Dictionary<int, IndexedItem> ListIndex { get; set; }

        public class IndexedItem
        {
            public int Id { get; set; }
            public Color BackgroundColor { get; set; }
        }

        public ArmyUnitListPresenter(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
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
            var count = 0;
            foreach (var armyUnitDefinition in items)
            {
                var altItem = altItems.Find(a => a.AlternativeUnitId == armyUnitDefinition.Id);
                var colour = altItem != null ? Color.Gainsboro : Color.Red;
                ListIndex.Add(count++, new IndexedItem { Id = armyUnitDefinition.Id, BackgroundColor = colour });
            }
            View.ArmyUnitDefinitions = items;
            View.IndexedItem = ListIndex;
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