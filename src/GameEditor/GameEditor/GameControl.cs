using System;
using GameEditor.Controllers;
using GameEditor.Extensions;
using GameEditor.Views;
using System.Windows.Forms;
using GameEditor.IoC;

namespace GameEditor
{
    public sealed partial class GameControl : BaseControl, IGameView
    {
        public string Path
        {
            get { return PathTextBox.Text; }
            set { this.InvokeIfRequired(() => PathTextBox.Text = value); }
        }

        public new string Name
        {
            get { return NameTextBox.Text; }
            set { this.InvokeIfRequired(() => NameTextBox.Text = value); }
        }

        public string Pressed
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public GameControl()
        {
            InitializeComponent();
            var controller = IoCContainer.Resolve<IGameController>();
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
