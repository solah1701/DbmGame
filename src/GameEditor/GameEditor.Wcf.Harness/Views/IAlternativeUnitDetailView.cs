using System;

namespace GameEditor.Wcf.Harness.Views
{
    public interface IAlternativeUnitDetailView
    {
        int Id { get; set; }
        Array NameData { set; }
        int SelectedIndex { get; set; }
        string UnitName { get; set; }
        int AlternativeUnitId { get; set; }
        bool Upgrade { get; set; }
        int MinValue { get; set; }
        int MaxValue { get; set; }
        bool Percent { get; set; }
        bool CanUpdate { set; }
        bool CanDelete { set; }
        bool CanSetMin { set; }
        bool CanSetMax { set; }
        bool CanSetPercent { set; }
    }
}