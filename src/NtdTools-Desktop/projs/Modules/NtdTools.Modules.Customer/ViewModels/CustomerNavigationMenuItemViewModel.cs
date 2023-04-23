using NtdTools.Presentation;
using NtdTools.Presentation.Navigation;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.Customer.ViewModels
{
    public class CustomerNavigationMenuItemViewModel : NavigationMenuItemModel
    {
        public CustomerNavigationMenuItemViewModel(IRegionManager regionManager)
        {
            Heading = "Customer";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(CustomerModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, nameof(Views.CustomerView));
            };
        }
    }
}
