//#define DESIGNMODE

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
            if (items == null) return;
            View.ArmyUnitDefinitions = items;
#endif
        }

        public void AddArmyUnit()
        {
            // Navigate to Detail page
            _model.CurrentArmyUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectUnitArmy(int armyUnitId)
        {
            // Navigate to Detail page
            _model.CurrentArmyUnitDefinitionId = armyUnitId;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}