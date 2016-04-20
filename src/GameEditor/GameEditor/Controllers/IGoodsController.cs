using GameEditor.Controllers.Base;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public interface IGoodsController : IController
    {
        void SetView(IGoodsView view);
    }
}