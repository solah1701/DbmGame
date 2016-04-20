using GameEditor.Views;
using GameEditor.Controllers;
using GameEditor.IoC;

namespace GameEditor
{
    public sealed partial class GoodsControl : BaseControl, IGoodsView
    {
        public GoodsControl()
        {
            InitializeComponent();
            var controller = IoCContainer.Resolve<IGoodsController>();
            controller.SetView(this);
            SetController(controller);
            CanCreate = true;
            CanUpdate = true;
            CanRead = true;
            CanDelete = true;
            controller.UpdateView();
        }
    }
}
