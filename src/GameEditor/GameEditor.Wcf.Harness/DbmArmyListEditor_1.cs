using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class DbmArmyListEditor_1 : Form, IArmyListView
    {
        private readonly IArmyListController _controller;
        private readonly IArmyDetailController _detailController;

        public DbmArmyListEditor_1()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IArmyListController>();
            _controller.SetView(this);
            _detailController = IoCContainer.Resolve<IArmyDetailController>();
            _detailController.SetView(ArmyDetailControl);
            _controller.PopulateList();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _detailController.UpdateArmyDetail();
            _controller.PopulateList();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _detailController.ClearArmyDetail();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _detailController.DeleteArmyDetail();
            _controller.PopulateList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selectedId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            _detailController.SelectArmyDetail(selectedId);
        }

        public ArmyDefinitions ArmyDefinitions
        {
            set
            {
                this.InvokeIfRequired(() =>
                  {
                      listView1.Items.Clear();
                      listView1.Items.AddRange(value.ConvertToListViewItems());
                  });
            }
        }
    }
}
