namespace GameEditor.Controllers.Base
{
    public interface IListController : IController { }
    public interface IListController<T> : IController
    {
        void SetView(T view);
        void SelectedItemChanged(string value);
    }
}
