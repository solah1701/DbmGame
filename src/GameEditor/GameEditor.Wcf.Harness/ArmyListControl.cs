using System.Windows.Forms;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyListControl : UserControl, IArmyDetailView
    {
        public ArmyListControl()
        {
            InitializeComponent();
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
            get { return int.Parse(IdTextBox.Text); }
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
        public int MinYear
        {
            get { return int.Parse(MinYearTextBox.Text); }
            set { this.InvokeIfRequired(() => MinYearTextBox.Text = value.ToString()); }
        }
    }
}
