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

        public void PopulateList()
        {
            var items = _model.GetArmyDefinitions();
            _view.ArmyDefinitions = items;
        }
    }
}