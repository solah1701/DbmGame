using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Views;
using Ninject.Modules;

namespace GameEditor.Wcf.Harness.IoC
{
    class StaticBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainPageView>().To<MainPageViewForm>().InSingletonScope();
            Bind<IArmyListView>().To<ArmyListViewControl>().InSingletonScope();
            Bind<IArmyDetailView>().To<ArmyDetailViewControl>().InSingletonScope();
            Bind<IArmyUnitListView>().To<ArmyUnitListViewControl>().InSingletonScope();
            Bind<IArmyDetailView>().To<ArmyDetailViewControl>().InSingletonScope();
            Bind<IAllyListView>().To<AllyListViewControl>().InSingletonScope();

            Bind<IGameModel>().To<GameModel>().InSingletonScope();
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
        }
    }
}
