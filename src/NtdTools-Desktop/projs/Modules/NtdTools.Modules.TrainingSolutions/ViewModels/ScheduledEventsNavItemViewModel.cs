using NtdTools.Presentation;
using NtdTools.Presentation.Navigation;
using Prism.Regions;

namespace NtdTools.Modules.TrainingSolutions.ViewModels
{
    public class ScheduledEventsNavItemViewModel : NavigationMenuItemModel
    {
        public ScheduledEventsNavItemViewModel(IRegionManager regionManager)
        {
            Heading = "Scheduled events";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(TrainingSolutionsModule);
            ItemSelected += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.MainContentRegion, nameof(Views.ScheduledEventsView));
            };
        }
    }
}
