using NtdTools.Presentation;
using NtdTools.Presentation.Modularity;
using Prism.Ioc;
using Prism.Regions;

namespace NtdTools.Modules.TrainingSolutions
{
    public class TrainingSolutionsModule : NtdModuleBase, INtdUIContentModule
    {
        public override void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.WholesalersNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.CustomersNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.TrainingCatalogNavItemView>(RegionNames.DynamicNavigationRegion);
            rm.RegisterViewWithRegion<Views.ScheduledEventsNavItemView>(RegionNames.DynamicNavigationRegion);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterScoped<NtdDbContext>();
            //containerRegistry.RegisterScoped<CustomerService>();

            containerRegistry.RegisterForNavigation<Views.WholesalersView>();
            containerRegistry.RegisterForNavigation<Views.CustomersView>(typeof(Views.CustomersView).FullName);
            containerRegistry.RegisterForNavigation<Views.TrainingCatalogView>();
            containerRegistry.RegisterForNavigation<Views.ScheduledEventsView>();
        }
    }
}
