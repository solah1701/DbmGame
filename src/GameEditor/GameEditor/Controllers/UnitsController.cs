using System.Linq;
using GameCore.DebellisMultitudinis;
using GameEditor.Controllers.Base;
using GameEditor.Extensions;
using GameEditor.Helpers;
using GameEditor.Models;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public class UnitsController : ListController, IUnitsController, IHandle<string>
    {
        private readonly IDbmGameModel _model;
        private readonly IEventAggregator _eventAggregator;

        private IUnitsView _view;
        private IConstructableUnit _current;

        public UnitsController(IEventAggregator eventAggregator, IDbmGameModel model)
        {
            _model = model;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        public void SetView(IUnitsView view)
        {
            _view = view;
            SetView(_view.SubView);
            _view.SubView.SetController(this);
            _view.SubView.CanCreate = true;
            _view.SubView.CanUpdate = true;
            _view.SubView.CanDelete = true;
            _view.SubView.CanRead = false;
            UpdateView();
        }

        public void SelectedItemChanged(string value)
        {
            foreach (var constructableUnit in _model.Game.ConstructableUnits.Where(constructableUnit => constructableUnit.Name == value))
            {
                PopulateViewFromModel(constructableUnit);
                return;
            }
        }

        public override void Create()
        {
            PopulateViewFromModel(new Unit());
        }

        public override void Update()
        {
            PopulateModelFromView();
            if (!_model.Game.ConstructableUnits.Contains(_current))
            {
                _model.Game.ConstructableUnits.Add(_current);
                _view.AddItem(_current);
            }
            else
                _view.UpdateItem(_current);
            _eventAggregator.PublishOnCurrentThread("UpdateView");
        }

        public override void Delete()
        {
            PopulateModelFromView();
            if (_model.Game.ConstructableUnits.Contains(_current)) _model.Game.ConstructableUnits.Remove(_current);
        }

        public void Handle(string message)
        {
            if (message == "UpdateView") UpdateView();
        }

        public override void UpdateView()
        {
            base.UpdateView();
            PopulateView();
        }

        private void PopulateView()
        {
            _view.ClearList();
            if (_model.Game.ConstructableUnits.Count == 0)
            {
                _view.Name = string.Empty;
                Create();
                return;
            }
            foreach (var item in _model.Game.ConstructableUnits)
            {
                _view.AddItem(item);
            }
        }
        private void PopulateViewFromModel(IConstructableUnit constructableUnit)
        {
            _current = constructableUnit;
            _view.Name = constructableUnit.Name;
            _view.Attack = constructableUnit.Attack;
            _view.ConstructionTime = constructableUnit.ConstructionTime;
            _view.Cost = constructableUnit.Cost;
            _view.Defence = constructableUnit.Defence;
            _view.Level = constructableUnit.Level;
            _view.Morale = constructableUnit.Morale;
            _view.Move = constructableUnit.Move;
            _view.Range = constructableUnit.Range;
            _view.Speed = constructableUnit.Speed;
            _view.Stamina = constructableUnit.Stamina;
            _view.Upkeep = constructableUnit.Upkeep;
        }

        private void PopulateModelFromView()
        {
            _current.Name = _view.Name;
            _current.Attack = _view.Attack;
            _current.ConstructionTime = _view.ConstructionTime;
            _current.Cost = _view.Cost;
            _current.Defence = _view.Defence;
            _current.Level = _view.Level;
            _current.Morale = _view.Morale;
            _current.Move = _view.Move;
            _current.Range = _view.Range;
            _current.Speed = _view.Speed;
            _current.Stamina = _view.Stamina;
            _current.Upkeep = _view.Upkeep;
        }
    }
}