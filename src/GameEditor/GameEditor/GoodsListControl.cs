using System;
using GameCore;
using GameEditor.Views;
using GameEditor.Controllers;
using System.Windows.Forms;
using GameEditor.Views.Base;
using GameEditor.Extensions;
using GameEditor.IoC;

namespace GameEditor
{
    public partial class GoodsListControl : UserControl, IGoodsListView
    {
        private readonly IGoodsListController _controller;

        public new string Name { get { return NameTextBox.Text; } set { this.InvokeIfRequired(() => NameTextBox.Text = value); } }
        public IView SubView { get { return baseControl1; } }

        public GoodsListControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IGoodsListController>();
            _controller.SetView(this);
        }

        public void LoadView()
        {
            ClearList();
        }

        public void ClearList()
        {
            GoodsListView.ClearList("Name");
        }

        public void AddItem(IGoods goods)
        {
            GoodsListView.AddItem(goods.Name);
        }

        public void RemoveItem(IGoods goods)
        {
            GoodsListView.RemoveItem(goods.Name);
        }

        public void SelectItem(IGoods goods)
        {
            GoodsListView.SelectItem(goods.Name);
        }

        public void UpdateItem(IGoods goods)
        {
            GoodsListView.UpdateItem(goods.Name);
        }

        private void GoodsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (GoodsListView.Items.Count > 0 && e.Item.Selected) _controller.SelectedItemChanged(e.Item.Text);
        }
    }
}
