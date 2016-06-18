using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IArmyUnitListPresenter : IController<IArmyUnitListView>
    {
        void AddArmyUnit();
        void PopulateList();
        void SelectUnitArmy(int armyUnitId);
    }
}