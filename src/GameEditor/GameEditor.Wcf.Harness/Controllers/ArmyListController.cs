using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyListController : Controller<IArmyListView>, IArmyListController
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

          public ArmyListController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
        }

        public void PopulateList()
        {
            var items = _model.GetArmyDefinitions();
            View.ArmyDefinitions = items;
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