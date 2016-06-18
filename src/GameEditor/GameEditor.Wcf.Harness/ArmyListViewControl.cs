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
    public partial class ArmyListViewControl : UserControl, IArmyListView
    {
        private readonly IArmyListPresenter _presenter;

        public ArmyListViewControl()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IArmyListPresenter>();
            _presenter.SetView(this);
            _presenter.PopulateList();
        }

        public ArmyDefinitions ArmyDefinitions
        {
            set
            {
                this.InvokeIfRequired(() =>
                {
                    ArmyListView.Items.Clear();
                    ArmyListView.Items.AddRange(value.ConvertToListViewItems());
                });
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _presenter.AddArmy();
        }

        private void ArmyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArmyListView.SelectedItems.Count == 0) return;
            _presenter.SelectArmy(int.Parse(ArmyListView.SelectedItems[0].SubItems[0].Text));
        }
    }
}
