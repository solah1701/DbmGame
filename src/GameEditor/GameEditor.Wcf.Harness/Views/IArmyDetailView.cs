namespace GameEditor.Wcf.Harness.Views
{
    public interface IArmyDetailView
    {
        int ArmyId { get; set; }
        string ArmyName { get; set; }
        int ArmyBook { get; set; }
        int ArmyList { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
        string Notes { get; set; }
    }
}