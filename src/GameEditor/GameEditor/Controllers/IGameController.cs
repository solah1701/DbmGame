using GameEditor.Controllers.Base;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public interface IGameController : IController
    {
        void SetView(IGameView view);
    }
}