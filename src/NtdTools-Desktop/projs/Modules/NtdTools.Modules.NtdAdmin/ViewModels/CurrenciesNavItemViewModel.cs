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
    public class CurrenciesNavItemViewModel : NavigationMenuItemModel
    {
        public CurrenciesNavItemViewModel(IRegionManager regionManager)
        {
            Heading = "Currencies";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(NtdAdminModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, nameof(Views.CurrenciesView));
            };
        }
    }
}
