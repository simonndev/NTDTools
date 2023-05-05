using NtdTools.Presentation;
using NtdTools.Presentation.Navigation;
using Prism.Regions;

namespace NtdTools.Modules.TrainingSolutions.ViewModels
{
    public class CustomersNavItemViewModel : NavigationMenuItemModel
    {
        public CustomersNavItemViewModel(IRegionManager regionManager)
        {
            Heading = "Customers";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(TrainingSolutionsModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, typeof(Views.CustomersView).FullName);
            };
        }
    }
}
