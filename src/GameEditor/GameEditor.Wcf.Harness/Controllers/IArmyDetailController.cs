using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IArmyDetailController : IController<IArmyDetailView>
    {
        void ClearArmyDetail();
        void DeleteArmyDetail();
        void SelectArmyDetail(int id);
        void UpdateArmyDetail();
    }
}