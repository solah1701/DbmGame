using System.Collections.Generic;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyListController
    {
        private readonly IList<IArmyDefinition> _model;
        private readonly IArmyListView _view;

        public ArmyListController(IArmyListView view) : this(view, new ArmyDefinitions()) { }

        public ArmyListController(IArmyListView view, IList<IArmyDefinition> model)
        {
            _view = view;
            _model = model;
        }

        public void AddList()
        {

        }

        public void DeleteList()
        {

        }

        public void SelectList(int id)
        {

        }
    }
}