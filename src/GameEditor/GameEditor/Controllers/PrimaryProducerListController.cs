using GameEditor.Controllers.Base;
using GameEditor.Views;
using GameEditor.Models;
using GameEditor.Helpers;
using GameCore;
using System.Linq;

namespace GameEditor.Controllers
{
    public class PrimaryProducerListController : ListController, IPrimaryProducerListController, IHandle<string>
    {
        private readonly IGameModel _model;

        private IPrimaryProducerListView _view;
        private IPrimaryProducer _currentItem;

        public PrimaryProducerListController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            eventAggregator.Subscribe(this);
        }

        public void SelectedItemChanged(string value)
        {
            foreach (var item in _model.Game.PrimaryProducerList)
            {
                if (item.Name == value)
                {
                    _currentItem = item;
                    _view.Name = value;
                    _view.Amount = item.Amount;
                    _view.Produces = item.Produces.Name;
                    _view.ProductionRate = item.ProductionRate;
                }
            }
        }

        public void SetView(IPrimaryProducerListView view)
        {
            _view = view;
            SetView(view.SubView);
            _view.SubView.SetController(this);
            _view.SubView.CanCreate = true;
            _view.SubView.CanUpdate = true;
            _view.SubView.CanDelete = true;
            _view.SubView.CanRead = false;
            UpdateView();
        }

        public override void UpdateView()
        {
            base.UpdateView();
            PopulateList();
            PopulateDropdown();
        }

        private void PopulateList()
        {
            _view.ClearList();
            if (_model.Game.GoodsList.Count == 0)
            {
                _view.Name = string.Empty;
                Create();
                return;
            }
            foreach (var item in _model.Game.PrimaryProducerList)
            {
                _view.AddItem(item);
            }
        }

        private void PopulateDropdown()
        {
            var names = _model.Game.GoodsList.Select(g => g.Name).ToList();
            _view.GoodsList = names;
        }

        public override void Create()
        {
            _currentItem = new PrimaryProducer();
            _view.Name = _currentItem.Name;
            _view.Produces = _currentItem.Produces.Name;
            _view.Amount = _currentItem.Amount;
            _view.ProductionRate = _currentItem.ProductionRate;
        }

        public override void Update()
        {
            _currentItem.Name = _view.Name;
            _currentItem.Produces = _model.Game.GoodsList.Find(g => g.Name == _view.Produces);
            _currentItem.Amount = _view.Amount;
            _currentItem.ProductionRate = _view.ProductionRate;

            if (!_model.Game.PrimaryProducerList.Contains(_currentItem))
            {
                _model.Game.PrimaryProducerList.Add(_currentItem);
                _view.AddItem(_currentItem);
            }
            else
                _view.UpdateItem(_currentItem);
        }

        public override void Delete()
        {
            if (_model.Game.PrimaryProducerList.Contains(_currentItem))
            {
                _model.Game.PrimaryProducerList.Remove(_currentItem);
                _view.RemoveItem(_currentItem);
            }
        }

        public void Handle(string message)
        {
            if (message == "UpdateView") UpdateView();
        }
    }
}
