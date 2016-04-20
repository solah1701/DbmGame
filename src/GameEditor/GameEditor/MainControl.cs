using System;
using GameEditor.Controllers;
using GameEditor.Extensions;
using GameEditor.Views;

namespace GameEditor
{
    public partial class MainControl : BaseControl, IMainView
    {
        private readonly MainController _controller;

        public new bool CanCreate
        {
            get { return CreateCheckBox.Checked; }
            set { base.CanCreate = value; }
        }

        public new bool CanRead
        {
            get { return ReadCheckBox.Checked; }
            set { base.CanRead = value; }
        }

        public new bool CanUpdate
        {
            get { return UpdateCheckBox.Checked; }
            set { base.CanUpdate = value; }
        }

        public new bool CanDelete
        {
            get { return DeleteCheckBox.Checked; }
            set { base.CanDelete = value; }
        }

        public new int BoolValue
        {
            set { this.InvokeIfRequired(() => BoolValueTextBox.Text = value.ToString()); }
        }

        public string Pressed
        {
            set { this.InvokeIfRequired(() => PressedTextBox.Text = value); }
        }

        public MainControl()
        {
            InitializeComponent();
            _controller = new MainController(this);
            SetController(_controller);
            _controller.UpdateView();
        }

        private void CreateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.UpdateView();
        }

        private void ReadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.UpdateView();
        }

        private void UpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.UpdateView();
        }

        private void DeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.UpdateView();
        }
    }
}
