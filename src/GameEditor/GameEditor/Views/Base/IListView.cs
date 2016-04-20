using System.Collections.Generic;

namespace GameEditor.Views.Base
{
    public interface IListView<T>
    {
        string Name { get; set; }
        IView SubView { get; }
        void ClearList();
        void AddItem(T item);
        void RemoveItem(T item);
        void UpdateItem(T item);
        void SelectItem(T item);
    }

    public interface IListView : IView
    {
        List<string> Items { get; set; }
    }
}
