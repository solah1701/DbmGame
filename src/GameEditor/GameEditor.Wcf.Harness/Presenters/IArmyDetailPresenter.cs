using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IArmyDetailPresenter : IController<IArmyDetailView>
    {
        void ClearArmyDetail();
        void DeleteArmyDetail();
        void SelectArmyDetail(int id);
        void UpdateArmyDetail();
        void AddArmyUnit();
    }
}