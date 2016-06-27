//#define DESIGNMODE

using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class ArmyListPresenter : Controller<IArmyListView>, IArmyListPresenter, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public ArmyListPresenter(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetArmyDefinitions();
            View.ArmyDefinitions = items;
#endif
        }

        public void AddArmy()
        {
            // Navigate to Detail page
            _model.CurrentArmyDefinitionId = 0;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectArmy(int armyId)
        {
            // Navigate to Detail page
            _model.CurrentArmyDefinitionId = armyId;
            _model.CurrentArmyUnitDefinitionId = 0;
            _model.CurrentAllyArmyDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}