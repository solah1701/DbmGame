using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IArmyUnitDetailPresenter : IController<IArmyUnitDetailView>
    {
        void CopyArmyUnitDetail();
        void DeleteArmyUnitDetail();
        void UpdateArmyUnitDetail();
    }
}