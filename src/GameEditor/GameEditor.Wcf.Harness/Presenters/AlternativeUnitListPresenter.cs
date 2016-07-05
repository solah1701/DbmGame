using System.Linq;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class AlternativeUnitListPresenter : Controller<IAlternativeUnitListView>, IAlternativeUnitListPresenter, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public AlternativeUnitListPresenter(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            _model = gameModel;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        protected override void InitialiseView()
        {
            base.InitialiseView();
            View.ShowList = false;
        }

        public override void ViewChanged()
        {
            View.ShowList = _model.GetAlternativeUnitDefinitions().Any();
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetAlternativeUnitDefinitions();
            if (items == null) return;
            View.AlternativeUnitDefinitions = items;
            ViewChanged();
#endif
        }

        public void Select(int id)
        {
            _model.CurrentAlternativeUnitDefinitionId = id;
            _event.PublishOnCurrentThread(new UpdateView());
            _event.PublishOnCurrentThread(new ShowAlternativeUnit());
        }

        public void Add()
        {
            _model.CurrentAlternativeUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new ShowAlternativeUnit());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}