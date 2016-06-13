using System.Collections.Generic;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Vews;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyListController : IArmyListController
    {
        private readonly IGameModel _model;
        private IArmyListView _view;
        private readonly IEventAggregator _event;

          public ArmyListController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
        }

        public void PopulateList()
        {
            var items = _model.GetArmyDefinitions();
            _view.ArmyDefinitions = items;
        }

        public void SetView(IArmyListView view)
        {
            _view = view;
        }

        public void AddArmy()
        {
            // Navigate to Detail page
        }

        public void SelectArmy()
        {
            // Navigate to Detail page
        }
    }
}