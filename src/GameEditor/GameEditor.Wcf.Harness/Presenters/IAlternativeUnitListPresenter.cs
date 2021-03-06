﻿using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IAlternativeUnitListPresenter : IController<IAlternativeUnitListView>
    {
        void PopulateList();
        void Select(int id);
        void Add();
    }
}