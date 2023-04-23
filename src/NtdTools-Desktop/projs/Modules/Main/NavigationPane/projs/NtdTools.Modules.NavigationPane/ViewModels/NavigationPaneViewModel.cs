using NtdTools.Presentation.Events;
using NtdTools.Presentation.Navigation;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.NavigationPane.ViewModels
{
    public class NavigationPaneViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public NavigationPaneViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

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

        private void HomeNavItemOnSelected(object sender, EventArgs e)
        {
            var homeItem = sender as NavigationMenuItemModel;
            if (homeItem != null)
            {
                var payload = new NavigationMenuItemSelectedEventPayload
                {
                    ModuleName = homeItem.ModuleName
                };
                _eventAggregator.GetEvent<NavigationMenuItemSelectedEvent>().Publish(payload);

                // so the Home Nav Item won't keep the focus next time
                homeItem.IsSelected = false;
            }
        }
    }
}
