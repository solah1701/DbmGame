using System;
using System.Collections.Generic;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Views
{
    public interface IAllyListView
    {
        List<string> AlliedArmyDefinitions { set; }
        string SelectedAlly { get; set; }
        string AllyName { get; set; }
        int Book { get; set; }
        int List { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
        bool CanUpdate { set; }
        bool CanDelete { set; }
    }
}