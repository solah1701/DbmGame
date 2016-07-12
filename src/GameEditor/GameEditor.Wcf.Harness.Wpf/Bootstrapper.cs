using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Dynamic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.ViewModels;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf
{
    public class Bootstrapper : BootstrapperBase
    {
        private CompositionContainer _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var catalog = new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>());
            _container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);

            _container.Compose(batch);
        }

        protected override object GetInstance(Type service, string key)
        {
            var contract = string.IsNullOrEmpty(key)
                ? AttributedModelServices.GetContractName(service)
                : key;
            var exports = _container.GetExportedValues<object>(contract);
            if (exports.Any()) return exports.First();
            throw new Exception($"Could not locate any instanxes of contract {contract}.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            dynamic settings = new ExpandoObject();
            settings.Height = 600;
            settings.Width = 600;
            settings.SizeToContent = SizeToContent.Manual;
            settings.WindowState = WindowState.Maximized;
            settings.Title = "Game Editor";

            DisplayRootViewFor<IShell>(settings);
        }
    }
}