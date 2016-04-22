using System;
using System.Windows.Forms;
using GameEditor.Controllers;
using GameEditor.Extensions;
using GameEditor.IoC;
using GameEditor.Views;

namespace GameEditor
{
    public sealed partial class DbmGameControl : BaseControl, IDbmGameView
    {
        public string Path
        {
            get { return PathTextBox.Text; }
            private set { this.InvokeIfRequired(() => PathTextBox.Text = value); }
        }

        public new string Name
        {
            get { return NameTextBox.Text; }
            set { this.InvokeIfRequired(() => NameTextBox.Text = value); }
        }

        public DbmGameControl()
        {
            InitializeComponent();
            var controller = IoCContainer.Resolve<IDbmGameController>();
            controller.SetView(this);
            SetController(controller);
            CanCreate = true;
            CanUpdate = true;
            CanDelete = false;
            CanRead = true;
            controller.UpdateView();
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Path;
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                Path = folderBrowserDialog1.SelectedPath;
        }
    }
}
