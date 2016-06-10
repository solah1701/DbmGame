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
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Vews;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class DbmArmyListEditor : Form, IArmyListView
    {
        private readonly ArmyListController _controller;
        private readonly ArmyDetailController _detailController;

        public DbmArmyListEditor()
        {
            InitializeComponent();
            _controller = new ArmyListController(this);
            _detailController = new ArmyDetailController(armyListControl1);
            _controller.PopulateList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _detailController.AddList();
            _controller.PopulateList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _detailController.DeleteList();
            _controller.PopulateList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selectedId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            _detailController.SelectList(selectedId);
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
