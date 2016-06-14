using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IArmyUnitListController : IController<IArmyUnitListView>
    {
        void AddArmyUnit();
        void PopulateList();
        void SelectUnitArmy(int armyUnitId);
    }
}