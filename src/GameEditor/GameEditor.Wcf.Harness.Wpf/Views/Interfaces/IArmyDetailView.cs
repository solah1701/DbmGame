namespace GameEditor.Wcf.Harness.Wpf.Views.Interfaces
{
    public interface IArmyDetailView
    {
        int ArmyBook { get; set; }
        int ArmyId { get; set; }
        int ArmyList { get; set; }
        string ArmyName { get; set; }
        int MaxYear { get; set; }
        int MinYear { get; set; }
        string Notes { get; set; }

        void Add();
        void ClearArmyDetail();
        void Delete();
        void SelectArmyDetail(int id);
        void Update();
    }
}