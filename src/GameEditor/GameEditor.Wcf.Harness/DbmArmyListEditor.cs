﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;

namespace GameEditor.Wcf.Harness
{
    public partial class DbmArmyListEditor : Form
    {
        private readonly ArmyListController _controller;

        public DbmArmyListEditor()
        {
            _controller = new ArmyListController(armyListControl1);
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _controller.AddList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _controller.DeleteList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            _controller.SelectList(selectedId);
        }
    }
}
