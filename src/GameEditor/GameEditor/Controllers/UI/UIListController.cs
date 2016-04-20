using GameEditor.Views.UI;
using System.Collections.Generic;
using System.Linq;

namespace GameEditor.Controllers.UI
{
    public class UIListController : IUIListController
    {
        private IUIListView _view;
        private List<string> _completeList;

        public UIListController()
        {
            _completeList = new List<string>();
        }

        public void SetView(IUIListView view)
        {
            _view = view;
            _view.ClearList();
        }

        public void AddItems(List<string> items)
        {
            _view.Items.Clear();
            _view.ClearList();
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void AddItem(string item)
        {
            if (_view.Items.Contains(item)) return;
            _view.Items.Add(item);
            _view.AddItem(item);
        }

        public void RemoveItem()
        {
            if (!_view.Items.Contains(_view.Selected)) return;
            _view.Items.Remove(_view.Selected);
            _view.RemoveItem(_view.Selected);
        }

        public List<string> GetAvailableItems()
        {
            return _completeList.Where(item => !_view.Items.Contains(item)).ToList();
        }

        public void SetupList(List<string> items)
        {
            _completeList = items;
        }
    }
}
