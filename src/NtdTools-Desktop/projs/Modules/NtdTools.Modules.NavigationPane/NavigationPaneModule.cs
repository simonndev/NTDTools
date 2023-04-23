using NtdTools.Presentation;
using NtdTools.Presentation.Modularity;
using Prism.Ioc;
using Prism.Regions;

namespace NtdTools.Modules.NavigationPane
{
    public class NavigationPaneModule : NtdModuleBase
    {
        public override void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.NavigationPaneView>(RegionNames.LeftContentRegion);
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
