using NtdTools.Presentation;
using NtdTools.Presentation.Modularity;
using Prism.Ioc;
using Prism.Regions;
using System;

namespace NtdTools.Modules.NtdAdmin
{
    public class NtdAdminModule : NtdModuleBase, INtdUIContentModule
    {
        public override void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.CountriesNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.LanguagesNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.CurrenciesNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.CustomersNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.CustomerNavItemView>(RegionNames.DynamicNavigationRegion);
            //rm.RegisterViewWithRegion<Views.ScheduledEventsNavItemView>(RegionNames.DynamicNavigationRegion);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.CountriesView>();
            containerRegistry.RegisterForNavigation<Views.LanguagesView>();
            containerRegistry.RegisterForNavigation<Views.CurrenciesView>();
            containerRegistry.RegisterForNavigation<Views.CustomersView>(typeof(Views.CustomersView).FullName);
            containerRegistry.RegisterForNavigation<Views.CustomerView>(typeof(Views.CustomerView).FullName);
            //containerRegistry.RegisterForNavigation<Views.ScheduledEventsView>();
        }
    }
}
