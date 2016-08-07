using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public interface IAlternativeUnitListViewModel : IAlternativeScreenTabItem
    {
        bool CanUpdate { get; set; }
        bool CanCopy { get; set; }
        bool CanDelete { get; set; }
        void PopulateList();
        void Select(int id);
        void Add();
    }
}