using GameEditor.Controllers.UI;
using System.Collections.Generic;

namespace GameEditor.Views.UI
{
    public interface IUIListView
    {
        IUIListController Controller { get; }
        List<string> Items { get; set; }
        string Selected { get; }
        void ClearList();
        void AddItem(string item);
        void RemoveItem(string item);
    }
}
