using GameEditor.Controllers.Base;
using GameEditor.Views;

namespace GameEditor.Controllers
{
    public class MainController : Controller
    {
        private readonly IMainView _view;

        public MainController(IMainView view)
            : base(view)
        {
            _view = view;
        }

        public override void Create()
        {
            _view.Pressed = "Create";
        }

        public override void Read()
        {
            _view.Pressed = "Read";
        }

        public override void Update()
        {
            _view.Pressed = "Update";
        }

        public override void Delete()
        {
            _view.Pressed = "Delete";
        }
    }
}
