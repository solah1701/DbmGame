using System;
using GameEditor.Controllers.Base;
using GameEditor.Views;
using System.IO;
using GameEditor.IoC;
using GameEditor.Models;
using GameEditor.Helpers;
using GameEditor.Extensions;

namespace GameEditor.Controllers
{
    public class GameController : Controller, IGameController
    {
        private IGameView _view;
        private readonly IGameModel _model;
        private readonly IEventAggregator _eventAggregator;

        public GameController(IEventAggregator eventAggregator)
        {
            _model = IoCContainer.Resolve<IGameModel>();
            _eventAggregator = eventAggregator;
        }

        public void SetView(IGameView view)
        {
            _view = view;
            base.SetView(view);
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

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
