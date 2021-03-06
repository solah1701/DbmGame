﻿using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IAllyListPresenter : IController<IAllyListView>
    {
        void PopulateList();
        void SelectArmy();
        void SelectAlly(int allyId);
        void UpdateArmy();
        void DeleteArmy();
    }
}