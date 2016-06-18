using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IArmyUnitDetailPresenter : IController<IArmyUnitDetailView>
    {
        void ClearArmyUnitDetail();
        void DeleteArmyUnitDetail();
        void SelectArmyUnitDetail(int id);
        void UpdateArmyUnitDetail();
    }
}