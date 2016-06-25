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

        public AlliedArmyDefinitions AlliedArmyDefinitions
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

        public string AllyName { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public bool CanUpdate { get; set; }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _presenter.UpdateArmy();
        }

        private void ArmyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArmyListView.SelectedItems.Count == 0) return;
            _presenter.SelectArmy(int.Parse(ArmyListView.SelectedItems[0].SubItems[0].Text));
        }
    }
}
