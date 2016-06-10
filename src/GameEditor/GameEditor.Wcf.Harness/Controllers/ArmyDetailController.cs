using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Vews;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyDetailController
    {
        private readonly IGameModel _model;
        private readonly IArmyDetailView _view;

        public ArmyDetailController(IArmyDetailView view) : this(view, new GameModel()) { }

        public ArmyDetailController(IArmyDetailView view, IGameModel model)
        {
            _view = view;
            _model = model;
        }

        public void AddList()
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
            _model.AddArmyDefinition(definition);
        }

        public void DeleteList()
        {

        }

        public void SelectList(int id)
        {
            var item = _model.GetArmyDefinition(id.ToString());
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