using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IMainPagePresenter : IController<IMainPageView>
    {
        void SelectTab(string tabName);
    }
}