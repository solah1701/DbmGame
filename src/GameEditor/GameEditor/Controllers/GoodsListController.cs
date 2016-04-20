using GameCore;
using GameEditor.Controllers.Base;
using GameEditor.Extensions;
using GameEditor.Helpers;
using GameEditor.Models;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public class GoodsListController : ListController, IGoodsListController, IHandle<string>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _eventAggregator;

        private IGoodsListView _view;
        private IGoods _currentGoods;

        public GoodsListController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void SetView(IGoodsListView view)
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
            PopulateView();
        }

        private void PopulateView()
        {
            _view.ClearList();
            if (_model.Game.GoodsList.Count == 0)
            {
                _view.Name = string.Empty;
                Create();
                return;
            }
            foreach (var item in _model.Game.GoodsList)
            {
                _view.AddItem(item);
            }
        }

        public void SelectedItemChanged(string value)
        {
            foreach (var item in _model.Game.GoodsList)
            {
                if (item.Name == value)
                {
                    _currentGoods = item;
                    _view.Name = value;
                }
            }
        }

        public override void Create()
        {
            _currentGoods = new Goods();
            _view.Name = _currentGoods.Name;
        }

        public override void Update()
        {
            _currentGoods.Name = _view.Name;
            if (!_model.Game.GoodsList.Contains(_currentGoods))
            {
                _model.Game.GoodsList.Add(_currentGoods);
                _view.AddItem(_currentGoods);
            }
            else
                _view.UpdateItem(_currentGoods);
            _eventAggregator.PublishOnCurrentThread("UpdateView");
        }

        public override void Delete()
        {
            _currentGoods.Name = _view.Name;
            if (_model.Game.GoodsList.Contains(_currentGoods))
                _view.RemoveItem(_currentGoods);
        }

        public void Handle(string message)
        {
            if (message == "UpdateView") UpdateView();
        }
    }
}
