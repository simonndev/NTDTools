using NtdTools.Desktop.Models;
using NtdTools.Presentation;
using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NtdTools.Desktop.ViewModels
{
    public class ShellViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IModuleManager _moduleManager;

        private bool _isFirstLoad;

        public ShellViewModel(IRegionManager regionManager, IModuleManager moduleManager)
        {
            _regionManager = regionManager;
            _moduleManager = moduleManager;

            
        }

        

        public void OnViewLoaded()
        {
            List<IModuleInfo> modules = new List<IModuleInfo>();

            if (!_isFirstLoad)
            {
                _moduleManager.LoadModuleCompleted += ModuleLoadedCompleted;
                modules.AddRange(_moduleManager.Modules);
                _isFirstLoad = true;
            }
            
            var parameters = new NavigationParameters
            {
                { "FirstLoad", true },
                { "Modules", modules }
            };

            _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(Views.MainView), parameters);
        }

        private void ModuleLoadedCompleted(object? sender, LoadModuleCompletedEventArgs e)
        {
            //LoadedModules.Add(new ModuleModel { Name = e.ModuleInfo.ModuleName });
        }
    }
}
