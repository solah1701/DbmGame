using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IMainPageController : IController<IMainPageView>
    {
        void SelectTab(string tabName);
    }
}