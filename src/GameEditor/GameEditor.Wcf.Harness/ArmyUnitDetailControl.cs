using System;
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
        private readonly bool _initialised;

        public ArmyUnitDetailControl()
        {
            _initialised = false;
            InitializeComponent();
            _controller = IoCContainer.Resolve<IArmyUnitDetailController>();
            _controller.SetView(this);
            _initialised = true;
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

        public DisciplineTypeEnum DisciplineType
        {
            get { return (DisciplineTypeEnum)Enum.Parse(typeof(DisciplineTypeEnum), DisciplineComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => DisciplineComboBox.SelectedItem = value.ToString()); }
        }

        public UnitTypeEnum UnitType
        {
            get { return (UnitTypeEnum)Enum.Parse(typeof(UnitTypeEnum), UnitComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => UnitComboBox.SelectedItem = value.ToString()); }
        }

        public GradeTypeEnum GradeType
        {
            get { return (GradeTypeEnum)Enum.Parse(typeof(GradeTypeEnum), GradeComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => GradeComboBox.SelectedItem = value.ToString()); }
        }

        public DispositionTypeEnum DispositionType
        {
            get { return (DispositionTypeEnum)Enum.Parse(typeof(DispositionTypeEnum), DispositionComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => DispositionComboBox.SelectedItem = value.ToString()); }
        }

        public Array DisciplineData
        {
            set { this.InvokeIfRequired(() => DisciplineComboBox.DataSource = value); }
        }

        public Array UnitData
        {
            set { this.InvokeIfRequired(() => UnitComboBox.DataSource = value); }
        }

        public Array GradeData
        {
            set { this.InvokeIfRequired(() => GradeComboBox.DataSource = value); }
        }

        public Array DispositionData
        {
            set { this.InvokeIfRequired(() => DispositionComboBox.DataSource = value); }
        }

        public int MinYear
        {
            get { return int.Parse(MinYearTextBox.Text); }
            set { this.InvokeIfRequired(() => MinYearTextBox.Text = value.ToString()); }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateArmyUnitDetail();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _controller.DeleteArmyUnitDetail();
        }
    }
}
