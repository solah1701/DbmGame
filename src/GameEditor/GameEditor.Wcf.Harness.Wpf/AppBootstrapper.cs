using System.Linq;
using Autofac;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf
{
    public class AppBootstrapper : TypedAutofacBootstrapper<IShellViewModel>
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            // Register View Models
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.GetInterface(typeof (IMainScreenTabItem).Name) != null)
                .As<IMainScreenTabItem>().InstancePerLifetimeScope();

            builder.Register<IGameModel>(c => new GameModel()).InstancePerLifetimeScope();
        }
    }
}