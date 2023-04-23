using NtdTools.Presentation;
using NtdTools.Presentation.Navigation;
using Prism.Regions;

namespace NtdTools.Modules.TrainingSolutions.ViewModels
{
    public class WholesalersNavItemViewModel : NavigationMenuItemModel
    {
        public WholesalersNavItemViewModel(IRegionManager regionManager)
        {
            Heading = "Wholesalers";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(TrainingSolutionsModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, nameof(Views.WholesalersView));
            };
        }
    }
}
