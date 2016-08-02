using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels.Base
{
    public class ListViewModel : BaseViewModel, IHandle<UpdateList>
    {
        protected bool IsUpdating { get; set; }

        public ListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
            IsUpdating = false;
        }

        public virtual void PopulateList()
        {

        }

        public virtual void Add()
        {
            PublishToUIUpdateView();
        }

        public virtual void Select(int id)
        {
            PublishToUIUpdateView();
        }

        public void Handle(UpdateList message)
        {
            IsUpdating = true;
            PopulateList();
            IsUpdating = false;
        }
    }
}