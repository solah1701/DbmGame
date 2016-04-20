using GameEditor.Views.Base;

namespace GameEditor.Views
{
    public interface IMainView : IView
    {
        string Pressed { set; }
    }
}
