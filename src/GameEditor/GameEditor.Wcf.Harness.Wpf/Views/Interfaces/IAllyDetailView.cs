namespace GameEditor.Wcf.Harness.Wpf.Views.Interfaces
{
    public interface IAllyDetailView : IDetailView
    {
        int AllyListId { get; set; }
        string AllyName { get; set; }
        int Book { get; set; }
        int List { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
    }
}