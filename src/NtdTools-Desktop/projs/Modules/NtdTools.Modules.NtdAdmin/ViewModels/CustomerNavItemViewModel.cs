using NtdTools.Modules.NtdAdmin;
using NtdTools.Presentation;
using NtdTools.Presentation.Navigation;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.NtdAdmin.ViewModels
{
    public class CustomerNavItemViewModel : NavigationMenuItemModel
    {
        public CustomerNavItemViewModel(IRegionManager regionManager)
        {
            Heading = "Customer";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(NtdAdminModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, typeof(Views.CustomerView).FullName);
            };
        }
    }
}
