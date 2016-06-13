using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Vews;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyDetailController : IArmyDetailController
    {
        private readonly IGameModel _model;
        private IArmyDetailView _view;
        private readonly IEventAggregator _event;

        public ArmyDetailController(IEventAggregator eventAggregator, IArmyDetailView view, IGameModel model)
        {
            _view = view;
            _model = model;
            _event = eventAggregator;
        }

        public void SetView(IArmyDetailView view)
        {
            _view = view;
        }

        public void ClearArmyDetail()
        {
            _view.ArmyId = 0;
            _view.ArmyName = string.Empty;
            _view.ArmyBook = 0;
            _view.ArmyList = 0;
            _view.MinYear = 0;
            _view.MaxYear = 0;
            _view.Notes = string.Empty;
        }

        public void UpdateArmyDetail()
        {
            var definition = new ArmyDefinition
            {
                Id = _view.ArmyId,
                ArmyName = _view.ArmyName,
                ArmyBook = _view.ArmyBook,
                ArmyList = _view.ArmyList,
                MinYear = _view.MinYear,
                MaxYear = _view.MaxYear,
                Notes = _view.Notes
            };
            _view.ArmyId = _model.AddArmyDefinition(definition);
        }

        public void DeleteArmyDetail()
        {
            _model.DeleteArmyDefinition(_view.ArmyId);
            ClearArmyDetail();
        }

        public void SelectArmyDetail(int id)
        {
            var item = _model.GetArmyDefinition(id);
            _view.ArmyId = item.Id;
            _view.ArmyName = item.ArmyName;
            _view.ArmyBook = item.ArmyBook;
            _view.ArmyList = item.ArmyList;
            _view.MinYear = item.MinYear;
            _view.MaxYear = item.MaxYear;
            _view.Notes = item.Notes;
        }
    }
}