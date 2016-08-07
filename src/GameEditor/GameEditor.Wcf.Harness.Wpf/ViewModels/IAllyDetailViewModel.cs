using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public interface IAllyDetailViewModel : IDetailView
    {
        int AllyListId { get; set; }
        string AllyName { get; set; }
        int Book { get; set; }
        int List { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
    }
}