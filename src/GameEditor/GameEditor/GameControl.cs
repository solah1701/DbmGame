using System;
using GameEditor.Controllers;
using GameEditor.Extensions;
using GameEditor.Views;
using System.Windows.Forms;
using GameEditor.IoC;

namespace GameEditor
{
    public partial class GameControl : BaseControl, IGameView
    {
        private IGameController _controller;

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
            _controller = IoCContainer.Resolve<IGameController>();
            _controller.SetView(this);
            SetController(_controller);
            CanCreate = true;
            CanUpdate = true;
            CanDelete = false;
            CanRead = true;
            _controller.UpdateView();
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
