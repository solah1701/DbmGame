using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class AlternativeUnitDetailPresenter : Controller<IAlternativeUnitDetailView>, IAlternativeUnitDetailPresenter, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public AlternativeUnitDetailPresenter(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        private void ClearDetail()
        {
            View.Id = 0;
            View.Name = string.Empty;
            View.AlternativeUnitId = 0;
            View.UnitId = 0;
            View.Upgrade = false;
            View.MinValue = 0;
            View.MaxValue = 0;
            View.Percent = false;
        }

        private void SelectDetail(int id)
        {
            var item = _model.GetAlternativeUnitDefinition(id);
            if (item == null) return;
            View.Id = item.Id;
            View.Name = item.Name;
            View.AlternativeUnitId = item.AlternativeUnitId;
            View.UnitId = item.UnitId;
            View.Upgrade = item.Upgrade;
            View.MinValue = item.MinValue;
            View.MaxValue = item.MaxValue;
            View.Percent = item.Percent;
        }

        public void DeleteAlternativeUnitDetail()
        {
            _model.DeleteAlternativeDefinition(View.Id);
            ClearDetail();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void UpdateAlternativeUnitDetail()
        {
            var definition = new AlternativeUnitDefinition
            {
                Id = View.Id,
                Name = View.Name,
                AlternativeUnitId = View.AlternativeUnitId,
                UnitId = View.UnitId,
                Upgrade = View.Upgrade,
                MinValue = View.MinValue,
                MaxValue = View.MaxValue,
                Percent = View.Percent
            };
            View.Id = _model.AddAlternativeDefinition(definition);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void ShowList()
        {
            _event.PublishOnCurrentThread(new ShowAlternativeUnit(true));
        }

        public void Handle(UpdateView message)
        {
            if (_model.CurrentAlternativeUnitDefinitionId == 0) ClearDetail();
            else SelectDetail(_model.CurrentAlternativeUnitDefinitionId);
        }
    }
}