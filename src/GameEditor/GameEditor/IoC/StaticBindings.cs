using GameEditor.Helpers;
using GameEditor.Models;
using Ninject.Modules;

namespace GameEditor.IoC
{
    class StaticBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameModel>().To<GameModel>().InSingletonScope();
            Bind<IDbmGameModel>().To<DbmGameModel>().InSingletonScope();
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
        }
    }
}
