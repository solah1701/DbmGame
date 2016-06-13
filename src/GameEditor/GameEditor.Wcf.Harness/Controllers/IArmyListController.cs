using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IArmyListController
    {
        void SetView(IArmyListView view);
        void AddArmy();
        void PopulateList();
        void SelectArmy();
    }
}