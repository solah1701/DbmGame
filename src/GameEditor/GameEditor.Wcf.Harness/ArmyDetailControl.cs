using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyDetailControl : UserControl, IArmyDetailView
    {
        private readonly IArmyDetailController _controller;

        public ArmyDetailControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IArmyDetailController>();
            _controller.SetView(this);
        }

        public string ArmyName
        {
            get { return NameTextBox.Text; }
            set { this.InvokeIfRequired(() => NameTextBox.Text = value); }
        }
        public int ArmyBook
        {
            get { return int.Parse(BookTextBox.Text); }
            set { this.InvokeIfRequired(() => BookTextBox.Text = value.ToString()); }
        }
        public int ArmyId
        {
            get
            {
                int result;
                if (!int.TryParse(IdTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => IdTextBox.Text = value.ToString()); }
        }
        public int ArmyList
        {
            get { return int.Parse(ListTextBox.Text); }
            set { this.InvokeIfRequired(() => ListTextBox.Text = value.ToString()); }
        }
        public int MaxYear
        {
            get { return int.Parse(MaxYearTextBox.Text); }
            set { this.InvokeIfRequired(() => MaxYearTextBox.Text = value.ToString()); }
        }

        public string Notes
        {
            get { return NotesTextBox.Text; }
            set { this.InvokeIfRequired(() => NotesTextBox.Text = value); }
        }

        public int MinYear
        {
            get { return int.Parse(MinYearTextBox.Text); }
            set { this.InvokeIfRequired(() => MinYearTextBox.Text = value.ToString()); }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, System.EventArgs e)
        {
            _controller.UpdateArmyDetail();
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            _controller.DeleteArmyDetail();
        }
    }
}
