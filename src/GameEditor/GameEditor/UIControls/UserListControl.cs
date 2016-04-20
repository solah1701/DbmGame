using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameEditor.Views.UI;
using GameEditor.Controllers.UI;
using GameEditor.IoC;
using GameEditor.Extensions;

namespace GameEditor.UIControls
{
    public partial class UserListControl : UserControl, IUIListView
    {
        public IUIListController Controller { get; }
        public List<string> Items { get; set; }
        public string Selected => listView1.SelectedItems[0].Text;

        public UserListControl()
        {
            InitializeComponent();
            Controller = IoCContainer.Resolve<IUIListController>();
            Controller.SetView(this);
        }

        public void ClearList()
        {
            listView1.ClearList("Name");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var dialog = new ListForm {Items = Controller.GetAvailableItems()};
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                Controller.AddItem(dialog.Selected);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Controller.RemoveItem();
        }

        public void AddItem(string item)
        {
            listView1.AddItem(item);
        }

        public void RemoveItem(string item)
        {
            listView1.RemoveItem(item);
        }
    }
}
