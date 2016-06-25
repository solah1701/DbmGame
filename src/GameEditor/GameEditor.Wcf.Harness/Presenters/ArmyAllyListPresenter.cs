//#undef DESIGNMODE 

using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class ArmyAllyListPresenter : Controller<IArmyAllyListView>, IArmyAllyListPresenter, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public ArmyAllyListPresenter(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetAlliedArmyDefinitions();
            View.AlliedArmyDefinitions = items;
#endif
        }

        public void SelectAlly(int allyId)
        {
            _model.CurrentAllyDefinitionId = allyId;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}