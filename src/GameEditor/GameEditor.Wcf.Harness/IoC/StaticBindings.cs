using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using Ninject.Modules;

namespace GameEditor.Wcf.Harness.IoC
{
    class StaticBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameModel>().To<GameModel>().InSingletonScope();
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
        }
    }
}
