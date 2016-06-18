using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class DbmArmyListEditor_1 : Form, IArmyListView
    {
        private readonly IArmyListPresenter _presenter;
        private readonly IArmyDetailPresenter _detailPresenter;

        public DbmArmyListEditor_1()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IArmyListPresenter>();
            _detailPresenter = IoCContainer.Resolve<IArmyDetailPresenter>();
            _presenter.PopulateList();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _detailPresenter.UpdateArmyDetail();
            _presenter.PopulateList();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _detailPresenter.ClearArmyDetail();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _detailPresenter.DeleteArmyDetail();
            _presenter.PopulateList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selectedId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            _detailPresenter.SelectArmyDetail(selectedId);
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
