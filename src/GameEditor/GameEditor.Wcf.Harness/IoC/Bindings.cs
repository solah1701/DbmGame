using GameEditor.Wcf.Harness.Controllers;
using Ninject.Modules;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness.IoC
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainPageView>().To<DbmArmyListEditor>();
            Bind<IArmyListView>().To<ArmyListControl>();
            Bind<IArmyDetailView>().To<ArmyDetailControl>();

            Bind<IMainPageController>().To<MainPageController>();
            Bind<IArmyListController>().To<ArmyListController>();
            Bind<IArmyDetailController>().To<ArmyDetailController>();
        }
    }
}