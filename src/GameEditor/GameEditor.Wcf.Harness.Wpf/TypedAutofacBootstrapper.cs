using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Autofac;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using IContainer = Autofac.IContainer;

namespace GameEditor.Wcf.Harness.Wpf
{
    public class TypedAutofacBootstrapper<TRootViewModel> : Bootstrapper<TRootViewModel>
    {
        #region Fields

        private readonly ILog _logger = LogManager.GetLog(typeof(Type));
        private IContainer _container;

        #endregion

        protected IContainer Container { get { return _container; } }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();
            // Register View Models
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.EndsWith("ViewModel"))
                .Where(type => !(string.IsNullOrWhiteSpace(type.Namespace)) && type.Namespace.EndsWith("ViewModels"))
                .Where(type => type.GetInterface(typeof(INotifyPropertyChanged).Name) != null)
                .AsSelf()
                .InstancePerDependency();

            // Register Views
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.EndsWith("View"))
                .Where(type => !(string.IsNullOrWhiteSpace(type.Namespace)) && type.Namespace.EndsWith("Views"))
                .AsSelf()
                .InstancePerDependency();

            builder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();
            builder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();
            ConfigureContainer(builder);
            _container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Container.IsRegistered(service)) return Container.Resolve(service);
            }
            else
            {
                //                if (Container.IsRegistered(key, service)) return Container.Resolve(key, service);
            }
            throw new Exception($"Could not locate any instances of contract {service.Name}");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            Container.InjectProperties(instance);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {

        }
    }
}