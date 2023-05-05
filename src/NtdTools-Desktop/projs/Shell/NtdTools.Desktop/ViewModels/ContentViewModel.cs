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
using System.Windows.Media;
using System.Windows;

namespace NtdTools.Desktop.ViewModels
{
    public class ContentViewModel : INavigationAware
    {
        private readonly IRegionManager _regionManager;

        public ContentViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            eventAggregator.GetEvent<NavigateBackHomeEvent>().Subscribe(NavigateBackHome);
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

        private void NavigateBackHome(string fromModuleName)
        {
            var parameters = new NavigationParameters
            {
                { "FirstLoad", false },
                { "Module", fromModuleName }
            };

            _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(Views.MainView), parameters);
        }
    }
}
