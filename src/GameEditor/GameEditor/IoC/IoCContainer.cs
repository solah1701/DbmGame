using Ninject;
using Ninject.Modules;

namespace GameEditor.IoC
{
    public static class IoCContainer
    {
        private static IKernel _kernel;

        public static T Resolve<T>()
        {
            if (_kernel != null) return _kernel.Get<T>();
            INinjectModule bindings = new Bindings();
            INinjectModule staticBindings = new StaticBindings();
            var modules = new[] { bindings, staticBindings };
            _kernel = new StandardKernel(modules);
            return _kernel.Get<T>();
        }
    }
}