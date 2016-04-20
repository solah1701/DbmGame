using System.Windows.Forms;
using GameEditor.Views;
using GameCore;
using GameEditor.Views.Base;
using GameEditor.Extensions;
using GameEditor.Controllers;
using System.Collections.Generic;
using System.Globalization;

namespace GameEditor
{
    public partial class PrimaryProducerListControl : UserControl, IPrimaryProducerListView
    {
        private readonly IPrimaryProducerListController _controller;

        public new string Name { get { return NameTextBox.Text; } set { this.InvokeIfRequired(() => NameTextBox.Text = value); } }
        public int Amount { get { return int.Parse(AmountNumericUpDown.Value.ToString(CultureInfo.InvariantCulture)); } set { this.InvokeIfRequired(() => AmountNumericUpDown.Value = value); } }
        public string Produces { get { return ProductComboBox.Text; } set { this.InvokeIfRequired(() => ProductComboBox.Text = value); } }
        public List<string> GoodsList { set { this.InvokeIfRequired(() => PopulateProductList(value)); } }
        public int ProductionRate { get { return int.Parse(RateNumericUpDown.Value.ToString(CultureInfo.InvariantCulture)); } set { this.InvokeIfRequired(() => RateNumericUpDown.Value = value); } }
        public IView SubView => baseControl1;

        public PrimaryProducerListControl()
        {
            InitializeComponent();
            _controller = IoC.IoCContainer.Resolve<IPrimaryProducerListController>();
            _controller.SetView(this);
        }

        private void PopulateProductList(List<string> goodsList)
        {
            ProductComboBox.Items.Clear();
            ProductComboBox.Items.AddRange(new object[] { goodsList.ToArray() });
        }

        public void AddItem(IPrimaryProducer item)
        {
            PrimaryProducerListView.AddItem(item.Name);
        }

        public void ClearList()
        {
            PrimaryProducerListView.ClearList("Name");
        }

        public void RemoveItem(IPrimaryProducer item)
        {
            PrimaryProducerListView.RemoveItem(item.Name);
        }

        public void SelectItem(IPrimaryProducer item)
        {
            PrimaryProducerListView.SelectItem(item.Name);
        }

        public void UpdateItem(IPrimaryProducer item)
        {
            PrimaryProducerListView.UpdateItem(item.Name);
        }

        private void PrimaryProducerListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (PrimaryProducerListView.Items.Count > 0 && e.Item.Selected) _controller.SelectedItemChanged(e.Item.Text);
        }
    }
}
