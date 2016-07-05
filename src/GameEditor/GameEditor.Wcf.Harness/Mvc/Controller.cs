namespace GameEditor.Wcf.Harness.Mvc
{
    public class Controller<T> : IController<T>
    {
        protected T View { get; private set; }

        void IController<T>.SetView(T view)
        {
            View = view;
            InitialiseView();
        }

        public virtual void ViewChanged() { }

        protected virtual void InitialiseView() { }
    }
}