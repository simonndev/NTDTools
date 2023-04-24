using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NtdTools.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.ShellView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.MainView>();
            containerRegistry.RegisterForNavigation<Views.ContentView>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Modules.NavigationPane.NavigationPaneModule>();
            moduleCatalog.AddModule<Modules.NtdAdmin.NtdAdminModule>(InitializationMode.WhenAvailable, dependsOn: nameof(Modules.NavigationPane.NavigationPaneModule));
            moduleCatalog.AddModule<Modules.Customer.CustomerModule>(InitializationMode.WhenAvailable, dependsOn: nameof(Modules.NavigationPane.NavigationPaneModule));
            moduleCatalog.AddModule<Modules.TrainingSolutions.TrainingSolutionsModule>(InitializationMode.WhenAvailable, dependsOn: nameof(Modules.NavigationPane.NavigationPaneModule));
        }
    }
}
