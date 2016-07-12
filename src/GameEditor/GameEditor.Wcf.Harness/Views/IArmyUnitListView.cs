using System.Collections.Generic;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Views
{
    public interface IArmyUnitListView
    {
        ArmyUnitDefinitions ArmyUnitDefinitions { set; }
        Dictionary<int,ArmyUnitListPresenter.IndexedItem> IndexedItem { get; set; }
    }
}