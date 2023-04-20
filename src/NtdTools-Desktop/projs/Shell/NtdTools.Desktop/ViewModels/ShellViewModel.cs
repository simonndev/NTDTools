using NtdTools.Presentation;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NtdTools.Desktop.ViewModels
{
    public class ShellViewModel
    {
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnViewLoaded()
        {
            var parameters = new NavigationParameters
            {
                { "FirstLoad", true }
            };

            _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(Views.MainView), parameters);
        }
    }
}
