using NtdTools.Presentation;
using NtdTools.Presentation.Modularity;
using Prism.Ioc;
using Prism.Regions;
using System;

namespace NtdTools.Modules.Customer
{
    public class CustomerModule : NtdModuleBase
    {
        public override void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.CustomerNavigationMenuItemView>(RegionNames.DynamicNavigationRegion);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
