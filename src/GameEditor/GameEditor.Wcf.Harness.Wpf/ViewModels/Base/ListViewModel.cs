using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels.Base
{
    public class ListViewModel : Screen, IHandle<UpdateList>
    {
        protected IEventAggregator EventAggregator { get; set; }
        protected bool IsUpdating { get; set; }

        public ListViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
            IsUpdating = false;
        }

        public virtual void PopulateList()
        {
            
        }

        public void Handle(UpdateList message)
        {
            IsUpdating = true;
            PopulateList();
            IsUpdating = false;
        }
    }
}