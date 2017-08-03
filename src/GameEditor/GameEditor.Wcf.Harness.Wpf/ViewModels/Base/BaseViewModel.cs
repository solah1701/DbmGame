using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels.Base
{
    public class BaseViewModel : Screen
    {
        protected IGameModel GameModel { get; }
        protected IEventAggregator EventAggregator { get; }

        private bool _canUpdate;
        private bool _canCopy;
        private bool _canDelete;

        public bool CanUpdate
        {
            get { return _canUpdate; }
            set
            {
                if (_canUpdate == value) return;
                _canUpdate = value; NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public bool CanCopy
        {
            get { return _canCopy; }
            set
            {
                if (_canCopy == value) return;
                _canCopy = value; NotifyOfPropertyChange(() => CanCopy);
            }
        }
        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                if (_canDelete == value) return;
                _canDelete = value; NotifyOfPropertyChange(() => CanDelete);
            }
        }

        public BaseViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            GameModel = gameModel;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
        }

        protected void PublishToUI(object message) { EventAggregator.PublishOnUIThread(message); }
        protected void PublishToUIUpdateView()
        {
            PublishToUI(new UpdateView());
        }
    }
}