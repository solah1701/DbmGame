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
        int UnitId { get; set; }
        bool Upgrade { get; set; }
        int MinValue { get; set; }
        int MaxValue { get; set; }
        bool Percent { get; set; }
    }
}