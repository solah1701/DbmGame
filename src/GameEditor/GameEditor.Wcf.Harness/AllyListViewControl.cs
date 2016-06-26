using System;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class AllyListViewControl : UserControl, IAllyListView
    {
        private readonly IAllyListPresenter _presenter;

        public AllyListViewControl()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IAllyListPresenter>();
            _presenter.SetView(this);
            _presenter.PopulateList();
        }

        public Array AlliedArmyDefinitions
        {
            set { this.InvokeIfRequired(() => AlliedListComboBox.DataSource = value); }
        }

        public string SelectedAlly
        {
            get { return AlliedListComboBox.Text; }
            set { this.InvokeIfRequired(() => AlliedListComboBox.Text = value); }
        }

        public string AllyName
        {
            get { return AllyNameTextBox.Text; }
            set { this.InvokeIfRequired(() => AllyNameTextBox.Text = value); }
        }

        public int Book
        {
            get { return int.Parse(BookTextBox.Text); }
            set { this.InvokeIfRequired(() => BookTextBox.Text = value.ToString()); }
        }

        public int List
        {
            get { return int.Parse(ListTextBox.Text); }
            set { this.InvokeIfRequired(() => ListTextBox.Text = value.ToString()); }
        }

        //public int MinYear { get; set; }
        //public int MaxYear { get; set; }

        public int MinYear
        {
            get
            {
                int result;
                if (!int.TryParse(MinYearTextBox.Text, out result)) result = 0;
                return result;
            }
            set { this.InvokeIfRequired(() => MinYearTextBox.Text = value.ToString()); }
        }

        public int MaxYear
        {
            get
            {
                int result;
                if (!int.TryParse(MaxYearTextBox.Text, out result)) result = 0;
                return result;

            }
            set { this.InvokeIfRequired(() => MaxYearTextBox.Text = value.ToString()); }
        }

        public bool CanUpdate
        {
            get { return UpdateButton.Enabled; }
            set { this.InvokeIfRequired(() => UpdateButton.Enabled = value); }
        }

        public bool CanDelete
        {
            get { return DeleteButton.Enabled; }
            set { this.InvokeIfRequired(() => DeleteButton.Enabled = value); }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _presenter.UpdateArmy();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _presenter.DeleteArmy();
        }

        private void AlliedListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlliedListComboBox.SelectedIndex < 0) return;
            _presenter.SelectArmy(AlliedListComboBox.SelectedIndex);
        }

        private void MinYearTextBox_TextChanged(object sender, EventArgs e)
        {
            _presenter.PopulateList();
        }

        private void MaxYearTextBox_TextChanged(object sender, EventArgs e)
        {
            _presenter.PopulateList();
        }
    }
}
