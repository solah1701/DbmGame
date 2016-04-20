using System.Windows.Forms;
using GameEditor.Views;
using GameEditor.Controllers;
using Ninject;
using GameEditor.IoC;

namespace GameEditor
{
    public partial class GoodsControl : BaseControl, IGoodsView
    {
        private readonly IGoodsController _controller;

        public GoodsControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IGoodsController>();
            _controller.SetView(this);
            SetController(_controller);
            CanCreate = true;
            CanUpdate = true;
            CanRead = true;
            CanDelete = true;
            _controller.UpdateView();
        }
    }
}
