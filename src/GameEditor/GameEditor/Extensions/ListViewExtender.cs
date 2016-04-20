using System.Windows.Forms;

namespace GameEditor.Extensions
{
    public static class ListViewExtender
    {
        public static void UpdateItem(this ListView listView, string key)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Selected)
                {
                    item.Text = key;
                    return;
                }
            }
        }

        public static void SelectItem(this ListView listView, string key)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text == key) item.Selected = true;
            }
        }

        public static void RemoveItem(this ListView listView, string key)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text == key)
                {
                    if (item.Selected)
                    {
                        var index = item.Index;
                        listView.Items.Remove(item);
                        if (listView.Items.Count <= index) index--;
                        if (listView.Items.Count == 0) return;
                        listView.Items[index].Selected = true;
                    }
                    else listView.Items.Remove(item);
                }
            }
        }

        public static void AddItem(this ListView listView, string key)
        {
            var item = listView.Items.Add(key);
            foreach (ListViewItem goodsItem in listView.Items)
            {
                goodsItem.Selected = false;
            }
            item.Selected = true;
        }

        public static void ClearList(this ListView listView, params string[] names)
        {
            listView.Columns.Clear();
            foreach (var name in names)
                listView.Columns.Add(name);
            listView.Items.Clear();
        }
    }
}
