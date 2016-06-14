using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class MainPageController : Controller<IMainPageView>, IHandle<string>, IMainPageController
    {
        public void Handle(string message)
        {
            SelectTab(message);
        }

        public void SelectTab(string tabName)
        {
            View.SelectTab(tabName);
        }
    }
}