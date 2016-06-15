using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyUnitDetailControl : UserControl, IArmyUnitDetailView
    {
        private readonly IArmyUnitDetailController _controller;

        public ArmyUnitDetailControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IArmyUnitDetailController>();
            _controller.SetView(this);
        }

        public string ArmyUnitName
        {
            get { return NameTextBox.Text; }
            set { this.InvokeIfRequired(() => NameTextBox.Text = value); }
        }

        public decimal? Cost
        {
            get { return decimal.Parse(CostTextBox.Text); }
            set { this.InvokeIfRequired(() => CostTextBox.Text = value.ToString()); }
        }

        public bool IsGeneral
        {
            get { return IsGeneralCheckBox.Checked; }
            set { this.InvokeIfRequired(() => IsGeneralCheckBox.Checked = value); }
        }

        public bool IsChariot
        {
            get { return ChariotCheckBox.Checked; }
            set { this.InvokeIfRequired(() => ChariotCheckBox.Checked = value); }
        }

        public bool IsMountedInfantry
        {
            get { return MountedInfantryCheckBox.Checked; }
            set { this.InvokeIfRequired(() => MountedInfantryCheckBox.Checked = value); }
        }

        public bool IsAlly
        {
            get { return AllyCheckBox.Checked; }
            set { this.InvokeIfRequired(() => AllyCheckBox.Checked = value); }
        }

        public bool IsDoubleElement
        {
            get { return DoubleElementCheckBox.Checked; }
            set { this.InvokeIfRequired(() => DoubleElementCheckBox.Checked = value); }
        }

        public int MinCount
        {
            get { return int.Parse(MinCountTextBox.Text); }
            set { this.InvokeIfRequired(() => MinCountTextBox.Text = value.ToString()); }
        }

        public int MaxCount
        {
            get { return int.Parse(MaxCountTextBox.Text); }
            set { this.InvokeIfRequired(() => MaxCountTextBox.Text = value.ToString()); }
        }

        public int ArmyUnitDefinitionId
        {
            get
            {
                int result;
                if (!int.TryParse(IdTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => IdTextBox.Text = value.ToString()); }
        }
        public int MaxYear
        {
            get { return int.Parse(MaxYearTextBox.Text); }
            set { this.InvokeIfRequired(() => MaxYearTextBox.Text = value.ToString()); }
        }

        public DisciplineTypeEnum DisciplineType { get; set; }
        public UnitTypeEnum UnitType { get; set; }
        public GradeTypeEnum GradeType { get; set; }
        public DispositionTypeEnum DispositionType { get; set; }

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
            _controller.UpdateArmyUnitDetail();
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            _controller.DeleteArmyUnitDetail();
        }
    }
}
