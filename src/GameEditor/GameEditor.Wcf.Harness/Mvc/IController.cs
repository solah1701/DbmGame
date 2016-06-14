namespace GameEditor.Wcf.Harness.Mvc
{
    public interface IController<in T>
    {
        void SetView(T view);
    }
}