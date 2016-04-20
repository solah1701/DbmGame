using System.Windows.Forms;
using GameEditor.Views;
using GameCore;
using GameEditor.Views.Base;
using GameEditor.Extensions;
using System.Collections.Generic;
using GameEditor.Views.UI;
using GameEditor.Controllers;

namespace GameEditor
{
    public partial class SecondaryProducerListControl : UserControl, ISecondaryProducerListView
    {
        private readonly ISecondaryProducerListController _controller;

        public new string Name { get { return NameTextBox.Text; } set { this.InvokeIfRequired(() => NameTextBox.Text = value); } }
        public List<IGoods> Consumes { get; set; }
        public int MaxConsumers { get { return 0; } set { } }
        public string Produces { get { return ProductComboBox.Text; } set { this.InvokeIfRequired(() => ProductComboBox.Text = value); } }
        public List<string> GoodsList { set { this.InvokeIfRequired(() => PopulateProductList(value)); } }
        public IView SubView => baseControl1;
        public IUIListView UIListView => userListControl1;
        public int Amount { get { return (int)AmountNumericUpDown.Value; } set { this.InvokeIfRequired(() => AmountNumericUpDown.Value = value); } }
        public int Rate { get { return (int)RateNumericUpDown.Value; } set { this.InvokeIfRequired(() => RateNumericUpDown.Value = value); } }

        public SecondaryProducerListControl()
        {
            InitializeComponent();
            _controller = IoC.IoCContainer.Resolve<ISecondaryProducerListController>();
            _controller.SetView(this);
        }

        private void PopulateProductList(List<string> goodsList)
        {
            ProductComboBox.Items.Clear();
            ProductComboBox.Items.AddRange(new object[] { goodsList.ToArray() });
        }

        public void AddItem(ISecondaryProducer item)
        {
            SecondaryProducerListView.AddItem(item.Name);
        }

        public void ClearList()
        {
            SecondaryProducerListView.ClearList("Name");
        }

        public void RemoveItem(ISecondaryProducer item)
        {
            SecondaryProducerListView.RemoveItem(item.Name);
        }

        public void SelectItem(ISecondaryProducer item)
        {
            SecondaryProducerListView.SelectItem(item.Name);
        }

        public void UpdateItem(ISecondaryProducer item)
        {
            SecondaryProducerListView.UpdateItem(item.Name);
        }

        private void SecondaryProducerListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (SecondaryProducerListView.Items.Count > 0 && e.Item.Selected) _controller.SelectedItemChanged(e.Item.Text);
        }
    }
}
