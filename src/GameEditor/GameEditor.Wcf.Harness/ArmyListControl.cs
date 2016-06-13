//#define DESIGNMODE

using System;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Vews;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyListControl : UserControl, IArmyListView
    {

        private IArmyListController _controller;

        public ArmyListControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IArmyListController>();
            _controller.SetView(this);
            _controller.PopulateList();
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
            _controller.AddArmy();
        }

        private void ArmyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.SelectArmy();
        }
    }
}
