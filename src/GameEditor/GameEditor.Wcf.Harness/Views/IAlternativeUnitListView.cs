﻿using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Views
{
    public interface IAlternativeUnitListView
    {
        AlternativeUnitDefinitions AlternativeUnitDefinitions { set; } 
        bool CanAdd { set; }
        bool ShowList { set; }
    }
}