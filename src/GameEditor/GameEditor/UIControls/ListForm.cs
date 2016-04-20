using GameEditor.Extensions;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameEditor.UIControls
{
    public partial class ListForm : Form
    {
        public string Selected { get; private set; }
        public List<string> Items { set { this.InvokeIfRequired(() => PopulateList(value)); } }

        public ListForm()
        {
            InitializeComponent();
        }

        private void PopulateList(List<string> items)
        {
            listView1.ClearList("Name");
            listView1.Items.Clear();
            foreach (var item in items)
            {
                listView1.Items.Add(item);
            }
            listView1.Update();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Selected = e.Item.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
