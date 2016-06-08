using System.Collections.Generic;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Vews;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyListController
    {
        private readonly IGameModel _model;
        private readonly IArmyListView _view;

        public ArmyListController(IArmyListView view) : this(view, new GameModel()) { }

        public ArmyListController(IArmyListView view, IGameModel model)
        {
            _view = view;
            _model = model;
        }

        public void AddList()
        {
            var definition = new ArmyDefinition
            {
                ArmyName = _view.ArmyName,
                ArmyBook = _view.ArmyBook.ToString(),
                ArmyList = _view.ArmyList.ToString(),
                MinYear = _view.MinYear,
                MaxYear = _view.MaxYear
            };
            _model.AddArmyDefinition(definition);
        }

        public void DeleteList()
        {

        }

        public void SelectList(int id)
        {
            var item = _model.GetArmyDefinition(id.ToString());
            _view.ArmyId = int.Parse(item.Id);
            _view.ArmyName = item.ArmyName;
            _view.ArmyBook = int.Parse(item.ArmyBook);
            _view.ArmyList = int.Parse(item.ArmyList);
            _view.MinYear = item.MinYear;
            _view.MaxYear = item.MaxYear;
        }
    }
}