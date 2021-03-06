﻿using System;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness
{
    public partial class AlternativeUnitListControl : UserControl, IAlternativeUnitListView
    {
        private readonly IAlternativeUnitListPresenter _presenter;

        public AlternativeUnitListControl()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IAlternativeUnitListPresenter>();
            _presenter.SetView(this);
            _presenter.PopulateList();
        }

        public AlternativeUnitDefinitions AlternativeUnitDefinitions
        {
            set
            {
                this.InvokeIfRequired(() =>
                {
                    AlternativeUnitListView.Items.Clear();
                    AlternativeUnitListView.Items.AddRange(value.ConvertToListViewItems());
                });
            }
        }

        public bool CanAdd { set { this.InvokeIfRequired(() => AddButton.Enabled = value); } }
        public bool ShowList { set { this.InvokeIfRequired(() => AlternativeUnitListView.Visible = value); } }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void AlternativeUnitListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlternativeUnitListView.SelectedItems.Count == 0) return;
            _presenter.Select(int.Parse(AlternativeUnitListView.SelectedItems[0].SubItems[0].Text));
        }
    }
}
