using System;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness
{
    public partial class AlternativeUnitDetailControl : UserControl, IAlternativeUnitDetailView
    {
        private readonly IAlternativeUnitDetailPresenter _presenter;
        private readonly bool _initialised;

        public AlternativeUnitDetailControl()
        {
            _initialised = false;
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IAlternativeUnitDetailPresenter>();
            _presenter.SetView(this);
            _initialised = true;
        }

        public int Id
        {
            get
            {
                int result;
                if (!int.TryParse(IdTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => IdTextBox.Text = value.ToString()); }
        }

        public Array NameData { set { this.InvokeIfRequired(() => UnitComboBox.DataSource = value); } }

        public int SelectedIndex
        {
            get { return UnitComboBox.SelectedIndex; }
            set { this.InvokeIfRequired(() => UnitComboBox.SelectedIndex = value); }
        }

        public string UnitName
        {
            get { return UnitComboBox.SelectedItem.ToString(); }
            set { if (_initialised) this.InvokeIfRequired(() => UnitComboBox.SelectedItem = value); }
        }

        public int AlternativeUnitId
        {
            get
            {
                int result;
                if (!int.TryParse(AltUnitIdTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => AltUnitIdTextBox.Text = value.ToString()); }
        }

        public bool Upgrade
        {
            get { return UpgradeCheckBox.Checked; }
            set { this.InvokeIfRequired(() => UpgradeCheckBox.Checked = value); }
        }

        public int MinValue
        {
            get
            {
                int result;
                if (!int.TryParse(MinCountTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => MinCountTextBox.Text = value.ToString()); }
        }

        public int MaxValue
        {
            get
            {
                int result;
                if (!int.TryParse(MaxCountTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => MaxCountTextBox.Text = value.ToString()); }
        }

        public bool Percent
        {
            get { return IsPercentCheckBox.Checked; }
            set { this.InvokeIfRequired(() => IsPercentCheckBox.Checked = value); }
        }

        public bool CanUpdate { set { this.InvokeIfRequired(() => UpdateButton.Enabled = value); } }
        public bool CanDelete { set { this.InvokeIfRequired(() => DeleteButton.Enabled = value); } }
        public bool CanSetMin { set { this.InvokeIfRequired(() => MinCountTextBox.Enabled = value); } }
        public bool CanSetMax { set { this.InvokeIfRequired(() => MaxCountTextBox.Enabled = value); } }
        public bool CanSetPercent { set { this.InvokeIfRequired(() => IsPercentCheckBox.Enabled = value); } }

        private void ListButton_Click(object sender, EventArgs e)
        {
            _presenter.ShowList();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _presenter.UpdateAlternativeUnitDetail();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _presenter.DeleteAlternativeUnitDetail();
        }

        private void UnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.ViewChanged();
        }

        private void UpgradeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.ViewChanged();
        }
    }
}
