using System.Windows.Forms;
using GameEditor.Views.Base;
using GameEditor.Controllers.Base;
using GameEditor.Extensions;
using System;
using System.Collections.Generic;

namespace GameEditor
{
    public partial class ListControl : UserControl, IListView
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
        public List<string> Items { get; set; }

        private IListController _controller;

        public ListControl()
        {
            InitializeComponent();
            Items = new List<string>();
        }

        public void SetController(IController controller)
        {
            throw new NotImplementedException();
        }

        public void SetController(IListController controller)
        {
            _controller = controller;
        }

        protected void AddItem(string item)
        {
            listView1.Items.Add(item);
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
