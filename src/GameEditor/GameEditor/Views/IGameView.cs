using GameEditor.Views.Base;

namespace GameEditor.Views
{
    public interface IGameView : IView
    {
        string Name { get; set; }
        string Path { get; }
    }
}
