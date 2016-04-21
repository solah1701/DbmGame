using GameEditor.Controllers.Base;
using System.Linq;
using GameEditor.Views;
using GameEditor.Models;
using GameEditor.Helpers;
using GameCore;
using System.Collections.Generic;

namespace GameEditor.Controllers
{
    public class SecondaryProducerListController : ListController, ISecondaryProducerListController, IHandle<string>
    {
        private readonly IGameModel _model;

        private ISecondaryProducerListView _view;
        private ISecondaryProducer _currentItem;

        public SecondaryProducerListController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            eventAggregator.Subscribe(this);
        }

        public void SelectedItemChanged(string value)
        {
            foreach (var item in _model.Game.SecondaryProducerList.Where(item => item.Name == value))
            {
                _currentItem = item;
                _view.Name = value;
                _view.MaxConsumers = item.MaxConsumers;
                _view.Produces = item.Produces == null ? string.Empty : item.Produces.Name;
                if (item.Consumes != null) _view.UIListView.Controller.AddItems(item.Consumes.Select(c => c.Name).ToList());
                //_view.Consumes = item.Consumes;
                _view.Amount = item.Amount;
                _view.Rate = item.Rate;
            }
        }

        public void SetView(ISecondaryProducerListView view)
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
            PopulateUIList();
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
            foreach (var item in _model.Game.SecondaryProducerList)
            {
                _view.AddItem(item);
            }
        }

        private void PopulateUIList()
        {
            _view.UIListView.Controller.SetupList(_model.Game.GoodsList.Select(g => g.Name).ToList());
            _view.UIListView.Controller.PopulateList(_currentItem.Consumes.Select(g => g.Name).ToList());
        }

        private void PopulateDropdown()
        {
            var names = _model.Game.GoodsList.Select(g => g.Name).ToList();
            _view.GoodsList = names;
        }

        public override void Create()
        {
            _currentItem = new SecondaryProducer();
            _view.Name = _currentItem.Name;
        }

        public override void Update()
        {
            _currentItem.Name = _view.Name;
            _currentItem.Amount = _view.Amount;
            _currentItem.Rate = _view.Rate;
            _currentItem.MaxConsumers = _view.MaxConsumers;
            var goods = new HashSet<string>(_view.UIListView.Items);
            _currentItem.Consumes = _model.Game.GoodsList.Where(g => goods.Contains(g.Name)).ToList();
            _currentItem.Produces = _model.Game.GoodsList.Find(g => g.Name == _view.Produces);
            if (!_model.Game.SecondaryProducerList.Contains(_currentItem))
            {
                _model.Game.SecondaryProducerList.Add(_currentItem);
                _view.AddItem(_currentItem);
            }
            else
                _view.UpdateItem(_currentItem);
        }

        public override void Delete()
        {
            _currentItem.Name = _view.Name;
            if (!_model.Game.SecondaryProducerList.Contains(_currentItem)) return;
            _model.Game.SecondaryProducerList.Remove(_currentItem);
            _view.RemoveItem(_currentItem);
        }

        public void Handle(string message)
        {
            if (message == "UpdateView") UpdateView();
        }
    }
}
