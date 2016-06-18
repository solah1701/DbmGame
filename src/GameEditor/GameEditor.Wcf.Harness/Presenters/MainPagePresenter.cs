using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class MainPagePresenter : Controller<IMainPageView>, IHandle<UpdateTabPage>, IMainPagePresenter
    {
        public MainPagePresenter(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public void Handle(UpdateTabPage message)
        {
            SelectTab(message.Message);
        }

        public void SelectTab(string tabName)
        {
            View.SelectTab(tabName);
        }
    }
}