using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels.Base
{
    public class DetailViewModel : Screen, IHandle<UpdateView>, IHandle<CheckDirtyStatus>
    {
        public IGameModel GameModel { get; set; }
        public IEventAggregator EventAggregator { get; set; }
        protected virtual int CurrentId { get; }

        public DetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            GameModel = gameModel;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
        }

        protected virtual void InitialiseView() { ViewChanged(); }
        protected virtual void ViewChanged() { }
        public virtual void ClearDetail() { }
        public virtual void SelectDetail(int currentId) { }
        public virtual void Update() { PublishToUIUpdateView(); }
        public virtual void Add() { PublishToUIUpdateView(); }
        public virtual void Delete() { ClearDetail(); PublishToUIUpdateView(); }
        public virtual void Copy() { ViewChanged(); }

        protected void PublishToUI(object message) { EventAggregator.PublishOnUIThread(message); }
        protected void PublishToUIUpdateView()
        {
            PublishToUI(new UpdateView());
        }

        public virtual void Handle(UpdateView message)
        {
            if (CurrentId == 0) ClearDetail();
            else SelectDetail(CurrentId);
            ViewChanged();
        }

        public void Handle(CheckDirtyStatus message)
        {
            ViewChanged();
        }
    }
}