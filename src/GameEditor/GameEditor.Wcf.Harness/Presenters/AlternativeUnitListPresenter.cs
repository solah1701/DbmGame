using GameEditor.Wcf.Harness.EventAggregators;
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

        public void Populate()
        {
#if !DESIGNMODE
            var items = _model.GetAlternativeUnitDefinitions();
            if (items == null) return;
            View.AlternativeUnitDefinitions = items;
#endif
        }

        public void Select(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(UpdateView message)
        {
            throw new System.NotImplementedException();
        }
    }
}