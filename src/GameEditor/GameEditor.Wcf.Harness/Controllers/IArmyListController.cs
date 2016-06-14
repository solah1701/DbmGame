﻿using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Controllers
{
    public interface IArmyListController : IController<IArmyListView>
    {
        void AddArmy();
        void PopulateList();
        void SelectArmy(int armyId);
    }
}