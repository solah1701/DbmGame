using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class MainPageController : IHandle<string>, IMainPageController
    {
        private IMainPageView _view;

        public void SetView(IMainPageView view)
        {
            _view = view;
        }

        public void Handle(string message)
        {
            SelectTab(message);
        }

        public void SelectTab(string tabName)
        {
            _view.SelectTab(tabName);
        }
    }
}