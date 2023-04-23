using NtdTools.Presentation;
using NtdTools.Presentation.Events;
using NtdTools.Presentation.Navigation;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Desktop.ViewModels
{
    public class ContentViewModel : INavigationAware
    {
        private readonly IRegionManager _regionManager;

        public ContentViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            eventAggregator.GetEvent<NavigationMenuItemSelectedEvent>().Subscribe(NavigateBackHome);


        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        private void NavigateBackHome(NavigationMenuItemSelectedEventPayload from)
        {
            var parameters = new NavigationParameters
            {
                { "FirstLoad", false },
                { "Module", from.ModuleName }
            };

            _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(Views.MainView), parameters);
        }
    }
}
