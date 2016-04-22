using GameEditor.Views.Base;

namespace GameEditor.Views
{
    public interface IDbmGameView : IView
    {
        string Name { get; set; }
        string Path { get; } 
    }
}