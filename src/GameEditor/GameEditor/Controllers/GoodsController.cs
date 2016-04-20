using GameEditor.Views;
using GameEditor.Controllers.Base;

namespace GameEditor.Controllers
{
    public class GoodsController : Controller, IGoodsController
    {
        private IGoodsView _view;

        public void SetView(IGoodsView view)
        {
            _view = view;
            base.SetView(view);
        }

        public override void Create()
        {
            //throw new System.NotImplementedException();
        }

        public override void Read()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
