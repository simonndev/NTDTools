using NtdTools.Desktop.Models;
using NtdTools.Presentation;
using NtdTools.Presentation.Modularity;
using Prism.Commands;
using Prism.Events;
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
    public class MainViewModel : INavigationAware
    {
        private readonly IRegionManager _regionManager;
        
        //private readonly IModuleTracker _moduleTracker;

        

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            LoadedModules = new ObservableCollection<ModuleModel>();
        }

        public ObservableCollection<ModuleModel> LoadedModules { get; private set; }

        private ICommand _openModuleCommand;
        public ICommand OpenModuleCommand
        {
            get
            {
                return _openModuleCommand ?? new DelegateCommand<object>(OpenModule);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleInfo"><see cref="ModuleModel"/>.</param>
        private void OpenModule(object moduleInfo)
        {
            if (moduleInfo != null)
            {
                var parameters = new NavigationParameters
                {
                    { "FirstLoad", false },
                    { "Module", (moduleInfo as ModuleModel).Name }
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
            if (navigationContext.Parameters.TryGetValue("Modules", out IEnumerable<IModuleInfo> modules))
            {
                foreach (var module in modules)
                {
                    LoadedModules.Add(new ModuleModel { Name = module.ModuleName });
                }
            }
        }

        
        #endregion
    }
}
