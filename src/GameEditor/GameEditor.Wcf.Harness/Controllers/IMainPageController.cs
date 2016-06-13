using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IMainPageController
    {
        void SelectTab(string tabName);
        void SetView(IMainPageView view);
    }
}