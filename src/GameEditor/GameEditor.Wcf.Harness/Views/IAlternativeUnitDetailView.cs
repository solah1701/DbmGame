namespace GameEditor.Wcf.Harness.Views
{
    public interface IAlternativeUnitDetailView
    {
        int Id { get; set; }
        string Name { get; set; }
        int AlternativeUnitId { get; set; }
        int UnitId { get; set; }
        bool Upgrade { get; set; }
        int MinValue { get; set; }
        int MaxValue { get; set; }
        bool Percent { get; set; }
    }
}