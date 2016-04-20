using System.Windows.Forms;
using GameEditor.Views.Base;
using GameEditor.Extensions;
using GameEditor.Controllers.Base;

namespace GameEditor
{
    public partial class BaseControl : UserControl, IView
    {

        public virtual bool CanCreate { get; set; }
        public virtual bool CanRead { get; set; }
        public virtual bool CanUpdate { get; set; }
        public virtual bool CanDelete { get; set; }
        public virtual int BoolValue { private get; set; }
        public bool Button1Visible { set { this.InvokeIfRequired(() => { button1.Visible = value; }); } }
        public bool Button2Visible { set { this.InvokeIfRequired(() => { button2.Visible = value; }); } }
        public bool Button3Visible { set { this.InvokeIfRequired(() => { button3.Visible = value; }); } }
        public bool Button4Visible { set { this.InvokeIfRequired(() => { button4.Visible = value; }); } }
        public string Button1Text { set { this.InvokeIfRequired(() => { button1.Text = value; }); } }
        public string Button2Text { set { this.InvokeIfRequired(() => { button2.Text = value; }); } }
        public string Button3Text { set { this.InvokeIfRequired(() => { button3.Text = value; }); } }
        public string Button4Text { set { this.InvokeIfRequired(() => { button4.Text = value; }); } }

        private IController _controller;

        public BaseControl()
        {
            InitializeComponent();
        }

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _controller.Button1();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            _controller.Button2();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            _controller.Button3();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            _controller.Button4();
        }
    }
}
