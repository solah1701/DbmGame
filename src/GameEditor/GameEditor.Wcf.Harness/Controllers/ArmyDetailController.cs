using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyDetailController : Controller<IArmyDetailView>, IArmyDetailController, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public ArmyDetailController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        public void ClearArmyDetail()
        {
            View.ArmyId = 0;
            View.ArmyName = string.Empty;
            View.ArmyBook = 0;
            View.ArmyList = 0;
            View.MinYear = 0;
            View.MaxYear = 0;
            View.Notes = string.Empty;
        }

        public void UpdateArmyDetail()
        {
            var definition = new ArmyDefinition
            {
                Id = View.ArmyId,
                ArmyName = View.ArmyName,
                ArmyBook = View.ArmyBook,
                ArmyList = View.ArmyList,
                MinYear = View.MinYear,
                MaxYear = View.MaxYear,
                Notes = View.Notes
            };
            View.ArmyId = _model.AddArmyDefinition(definition);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void AddArmyUnit()
        {
            //_model.CurrentArmyDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
            _event.PublishOnCurrentThread(new UpdateTabPage("ArmyUnitTabPage"));
        }

        public void DeleteArmyDetail()
        {
            _model.DeleteArmyDefinition(View.ArmyId);
            ClearArmyDetail();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectArmyDetail(int id)
        {
            var item = _model.GetArmyDefinition(id);
            View.ArmyId = item.Id;
            View.ArmyName = item.ArmyName;
            View.ArmyBook = item.ArmyBook;
            View.ArmyList = item.ArmyList;
            View.MinYear = item.MinYear;
            View.MaxYear = item.MaxYear;
            View.Notes = item.Notes;
        }

        public void Handle(UpdateView message)
        {
            if (_model.CurrentArmyDefinitionId == 0) ClearArmyDetail();
            else SelectArmyDetail(_model.CurrentArmyDefinitionId);
        }
    }
}