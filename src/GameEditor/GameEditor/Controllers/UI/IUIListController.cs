using GameEditor.Views.UI;
using System.Collections.Generic;

namespace GameEditor.Controllers.UI
{
    public interface IUIListController
    {
        void SetView(IUIListView view);
        void SetupList(List<string> items);
        void AddItem(string item);
        void AddItems(List<string> items);
        void RemoveItem();
        List<string> GetAvailableItems();
    }
}
