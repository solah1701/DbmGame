using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IArmyDetailController
    {
        void SetView(IArmyDetailView view);
        void ClearArmyDetail();
        void DeleteArmyDetail();
        void SelectArmyDetail(int id);
        void UpdateArmyDetail();
    }
}