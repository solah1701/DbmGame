using GameEditor.Controllers.Base;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public interface IGoodsController : IController
    {
        void Create();
        void Delete();
        void Read();
        void Update();
        void SetView(IGoodsView view);
    }
}