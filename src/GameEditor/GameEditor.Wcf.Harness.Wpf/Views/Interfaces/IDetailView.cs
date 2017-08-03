namespace GameEditor.Wcf.Harness.Wpf.Views.Interfaces
{
    public interface IDetailView
    {
        bool CanUpdate { get; set; }
        bool CanCopy { get; set; }
        bool CanDelete { get; set; }

        void Add();
        void Delete();
        void Update();
        void Select(int id);
        void Clear();
    }
}