namespace GameEditor.Wcf.Harness.Wpf.Views.Interfaces
{
    public interface IAllyDetailView
    {
        int AllyListId { get; set; } 
        string AllyName { get; set; }
        int Book { get; set; }
        int List { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }

        bool CanUpdate { get; set; }
        bool CanDelete { get; set; }

        void Add();
        void Delete();
        void Update();
        void SelectDetail(int id);
        void ClearDetail();
    }
}