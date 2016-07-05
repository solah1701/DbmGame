using System;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyUnitDetailViewControl : UserControl, IArmyUnitDetailView
    {
        private readonly IArmyUnitDetailPresenter _presenter;
        private readonly bool _initialised;

        public ArmyUnitDetailViewControl()
        {
            _initialised = false;
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IArmyUnitDetailPresenter>();
            _presenter.SetView(this);
            _initialised = true;
        }

        public string ArmyUnitName
        {
            get { return NameTextBox.Text; }
            set { this.InvokeIfRequired(() => NameTextBox.Text = value); }
        }

        public decimal? Cost
        {
            get { return decimal.Parse(CostTextBox.Text != string.Empty ? CostTextBox.Text : "0.0"); }
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
            get { return int.Parse(MinCountTextBox.Text != string.Empty ? MinCountTextBox.Text : "0"); }
            set { this.InvokeIfRequired(() => MinCountTextBox.Text = value.ToString()); }
        }

        public int MaxCount
        {
            get { return int.Parse(MaxCountTextBox.Text != string.Empty ? MaxCountTextBox.Text : "0"); }
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
            set { if (_initialised) this.InvokeIfRequired(() => DisciplineComboBox.SelectedIndex = (int)value); }
        }

        public UnitTypeEnum UnitType
        {
            get { return (UnitTypeEnum)Enum.Parse(typeof(UnitTypeEnum), UnitComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => UnitComboBox.SelectedIndex = (int)value); }
        }

        public GradeTypeEnum GradeType
        {
            get { return (GradeTypeEnum)Enum.Parse(typeof(GradeTypeEnum), GradeComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => GradeComboBox.SelectedIndex = (int)value); }
        }

        public DispositionTypeEnum DispositionType
        {
            get { return (DispositionTypeEnum)Enum.Parse(typeof(DispositionTypeEnum), DispositionComboBox.SelectedItem.ToString()); }
            set { if (_initialised) this.InvokeIfRequired(() => DispositionComboBox.SelectedIndex = (int)value); }
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

        public bool CanCopy { set { this.InvokeIfRequired(() => CopyButton.Enabled = value); } }
        public bool CanUpdate { set { this.InvokeIfRequired(() => UpdateButton.Enabled = value); } }
        public bool CanDelete { set { this.InvokeIfRequired(() => DeleteButton.Enabled = value); } }
        public bool CanAddAlternative { set { this.InvokeIfRequired(() => AlternativeButton.Enabled = value); } }
        public bool ShowAlternativeList { get; set; }

        public int MinYear
        {
            get { return int.Parse(MinYearTextBox.Text); }
            set { this.InvokeIfRequired(() => MinYearTextBox.Text = value.ToString()); }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _presenter.UpdateArmyUnitDetail();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _presenter.DeleteArmyUnitDetail();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            _presenter.CopyArmyUnitDetail();
        }

        private void AlternativeButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            _presenter.ViewChanged();
        }

        private void MaxCountTextBox_TextChanged(object sender, EventArgs e)
        {
            _presenter.ViewChanged();
        }
    }
}
