using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels.Base
{
    public class DetailViewModel : BaseViewModel, IHandle<UpdateView>, IHandle<CheckDirtyStatus>
    {
        protected virtual int CurrentId { get; }

        public DetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
        }

        protected virtual void InitialiseView() { ViewChanged(); }
        protected virtual void ViewChanged() { }
        public virtual void Clear() { }
        public virtual void Select(int currentId) { }
        public virtual void Update() { PublishToUIUpdateView(); }
        public virtual void Add() { PublishToUIUpdateView(); }
        public virtual void Delete() { Clear(); PublishToUIUpdateView(); }
        public virtual void Copy() { ViewChanged(); }

        public virtual void Handle(UpdateView message)
        {
            if (CurrentId == 0) Clear();
            else Select(CurrentId);
            ViewChanged();
        }

        public void Handle(CheckDirtyStatus message)
        {
            ViewChanged();
        }
    }
}