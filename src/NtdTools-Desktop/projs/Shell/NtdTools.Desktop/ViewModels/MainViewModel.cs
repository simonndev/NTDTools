using NtdTools.Presentation;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NtdTools.Desktop.ViewModels
{
    public class MainViewModel : INavigationAware
    {
        private readonly IRegionManager _regionManager;

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private ICommand _openModuleCommand;
        public ICommand OpenModuleCommand
        {
            get
            {
                return _openModuleCommand ?? new DelegateCommand<string>(OpenModule);
            }
        }

        private void OpenModule(string moduleName)
        {
            if (moduleName != null)
            {
                var parameters = new NavigationParameters
                {
                    { "FirstLoad", false },
                    { "Module", moduleName }
                };

                _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(Views.ContentView), parameters);
            }
        }

        #region INavigationAware implementation
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
        #endregion
    }
}
