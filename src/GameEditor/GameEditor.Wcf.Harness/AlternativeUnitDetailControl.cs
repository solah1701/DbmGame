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

        public AlternativeUnitDetailControl()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IAlternativeUnitDetailPresenter>();
            _presenter.SetView(this);
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

        public int UnitId
        {
            get
            {
                int result;
                if (!int.TryParse(UnitIdTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => UnitIdTextBox.Text = value.ToString()); }
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

        private void ListButton_Click(object sender, System.EventArgs e)
        {
            _presenter.ShowList();
        }

        private void UpdateButton_Click(object sender, System.EventArgs e)
        {
            _presenter.UpdateAlternativeUnitDetail();
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            _presenter.DeleteAlternativeUnitDetail();
        }
    }
}
