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
    public class CustomersNavigationMenuItemViewModel : NavigationMenuItemModel
    {
        public CustomersNavigationMenuItemViewModel(IRegionManager regionManager)
        {
            Heading = "Customers";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(CustomerModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, nameof(Views.CustomersView));
            };
        }
    }
}
