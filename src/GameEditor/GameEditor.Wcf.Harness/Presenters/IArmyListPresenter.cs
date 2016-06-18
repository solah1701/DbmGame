using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IArmyListPresenter : IController<IArmyListView>
    {
        void AddArmy();
        void PopulateList();
        void SelectArmy(int armyId);
    }
}