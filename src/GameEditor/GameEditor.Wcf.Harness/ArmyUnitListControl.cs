using System;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyUnitListControl : UserControl, IArmyUnitListView
    {
        private readonly IArmyUnitListController _controller;

        public ArmyUnitListControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IArmyUnitListController>();
            _controller.SetView(this);
            _controller.PopulateList();
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
            _controller.AddArmyUnit();
        }

        private void ArmyUnitListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArmyListView.SelectedItems.Count == 0) return;
            _controller.SelectUnitArmy(int.Parse(ArmyListView.SelectedItems[0].SubItems[0].Text));
        }
    }
}
