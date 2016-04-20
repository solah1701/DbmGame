using GameEditor.Controllers;
using GameEditor.Controllers.UI;
using GameEditor.Views;
using Ninject.Modules;

namespace GameEditor.IoC
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameView>().To<GameControl>();
            Bind<IGoodsListView>().To<GoodsListControl>();
            Bind<IGoodsView>().To<GoodsControl>();
            Bind<IPrimaryProducerListView>().To<PrimaryProducerListControl>();
            Bind<ISecondaryProducerListView>().To<SecondaryProducerListControl>();
            Bind<IMainView>().To<MainControl>();

            Bind<IGameController>().To<GameController>();
            Bind<IGoodsController>().To<GoodsController>();
            Bind<IGoodsListController>().To<GoodsListController>();
            Bind<IPrimaryProducerListController>().To<PrimaryProducerListController>();
            Bind<ISecondaryProducerListController>().To<SecondaryProducerListController>();
            Bind<IUIListController>().To<UIListController>();
        }
    }
}