using GameEditor.Wcf.Harness.Presenters;
using Ninject.Modules;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.IoC
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainPagePresenter>().To<MainPagePresenter>();
            Bind<IArmyListPresenter>().To<ArmyListPresenter>();
            Bind<IArmyDetailPresenter>().To<ArmyDetailPresenter>();
            Bind<IArmyUnitListPresenter>().To<ArmyUnitListPresenter>();
            Bind<IArmyUnitDetailPresenter>().To<ArmyUnitDetailPresenter>();
            Bind<IAllyListPresenter>().To<AllyListPresenter>();
            Bind<IArmyAllyListPresenter>().To<ArmyAllyListPresenter>();
        }
    }
}