using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IArmyAllyListPresenter : IController<IArmyAllyListView>
    {
        void PopulateList();
        void SelectAlly(int allyId);
    }
}