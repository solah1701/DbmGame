using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels.Base
{
    public class DetailViewModel : Screen, IHandle<UpdateView>
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
        protected virtual void ClearDetail() { }
        protected virtual void SelectDetail(int currentId) { }
        protected virtual void Update() { PublishToUIUpdateView(); }
        protected virtual void Add() { PublishToUIUpdateView(); }
        protected virtual void Delete() { ClearDetail(); PublishToUIUpdateView(); }

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
    }
}