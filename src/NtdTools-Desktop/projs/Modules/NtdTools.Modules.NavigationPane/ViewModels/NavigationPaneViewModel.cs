using NtdTools.Presentation.Events;
using NtdTools.Presentation.Navigation;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NtdTools.Modules.NavigationPane.ViewModels
{
    public class NavigationPaneViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ModuleNavigationTracker _moduleNavigationTracker;

        public NavigationPaneViewModel(IEventAggregator eventAggregator, ModuleNavigationTracker moduleNavigationTracker)
        {
            _eventAggregator = eventAggregator;
            _moduleNavigationTracker = moduleNavigationTracker;

            var homeItem = new NavigationMenuItemModel()
            {
                Icon = NavIcons.Home,
                Kind = NavKind.Default,
                Heading = "Home",
                Selectable = true, IsSelected = false
            };

            homeItem.ItemSelected += HomeNavItemOnSelected;

            StaticItems = new ObservableCollection<NavigationMenuItemModel> {
                homeItem,
                new NavigationMenuItemModel { Kind = NavKind.Input, Selectable = false }
            };

            SelectedStaticItemIndex = 1;
        }

        public ObservableCollection<NavigationMenuItemModel> StaticItems { get; private set; }

        private int _selectedStaticItemIndex;
        public int SelectedStaticItemIndex
        {
            get { return _selectedStaticItemIndex; }
            set { SetProperty(ref _selectedStaticItemIndex, value); }
        }

        private string _moduleNameFilter;
        public string ModuleNameFilter
        {
            get { return _moduleNameFilter; }
            set { SetProperty(ref _moduleNameFilter, value); }
        }

        private ICommand _viewLoadedCommand;
        public ICommand ViewLoadedCommand => _viewLoadedCommand ?? new DelegateCommand(OnViewLoaded);

        private void HomeNavItemOnSelected(object sender, EventArgs e)
        {
            var homeItem = sender as NavigationMenuItemModel;
            if (homeItem != null)
            {
                _eventAggregator.GetEvent<NavigateBackHomeEvent>().Publish(_moduleNavigationTracker.ModuleName);

                // so the Home Nav Item won't keep the focus next time
                homeItem.IsSelected = false;
            }
        }

        private void OnViewLoaded()
        {
            // At first load, the navigation pane items (from other modules) have not been populated yet.
            ModuleNameFilter = _moduleNavigationTracker.ModuleName;
        }
    }
}
