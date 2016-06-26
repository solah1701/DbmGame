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
    public partial class ArmyUnitListViewControl : UserControl, IArmyUnitListView
    {
        private readonly IArmyUnitListPresenter _presenter;

        public ArmyUnitListViewControl()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IArmyUnitListPresenter>();
            _presenter.SetView(this);
            _presenter.PopulateList();
        }

        public ArmyUnitDefinitions ArmyUnitDefinitions
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
            _presenter.AddArmyUnit();
        }

        private void ArmyUnitListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArmyListView.SelectedItems.Count == 0) return;
            _presenter.SelectUnitArmy(int.Parse(ArmyListView.SelectedItems[0].SubItems[0].Text));
        }
    }
}
