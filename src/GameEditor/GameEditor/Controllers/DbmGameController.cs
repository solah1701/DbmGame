using System.IO;
using GameEditor.Controllers.Base;
using GameEditor.Extensions;
using GameEditor.Helpers;
using GameEditor.Models;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public class DbmGameController : Controller, IDbmGameController
    {
        private IDbmGameView _view;
        private readonly IDbmGameModel _model;
        private readonly IEventAggregator _eventAggregator;

        public void SetView(IDbmGameView view)
        {
            _view = view;
            base.SetView(view);
        }

        public DbmGameController(IEventAggregator eventAggregator, IDbmGameModel model)
        {
            _eventAggregator = eventAggregator;
            _model = model;
        }


        public override void Create()
        {
            _model.Game.Name = _view.Name;
            var fileName = $"{_view.Path}\\{_view.Name}.xml";
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                _model.Game.WriteObject(writer);
            }
        }

        public override void Read()
        {
            var fileName = $"{_view.Path}\\{_view.Name}.xml";
            using (var reader = new FileStream(fileName, FileMode.Open))
            {
                _model.Game = _model.Game.ReadObject(reader);
            }
            _view.Name = _model.Game.Name;
            _eventAggregator.PublishOnCurrentThread("UpdateView");
        }
    }
}