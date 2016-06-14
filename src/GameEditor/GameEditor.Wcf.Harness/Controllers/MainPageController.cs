using System;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class MainPageController : Controller<IMainPageView>, IHandle<UpdateTabPage>, IMainPageController
    {
        public MainPageController(IEventAggregator eventAggregator)
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