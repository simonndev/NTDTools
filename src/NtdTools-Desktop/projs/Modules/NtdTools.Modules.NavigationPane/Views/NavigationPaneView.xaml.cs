using NtdTools.Presentation.Events;
using NtdTools.Presentation.Navigation;
using Prism.Events;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace NtdTools.Modules.NavigationPane.Views
{
    /// <summary>
    /// Interaction logic for NavigationPaneView.xaml
    /// </summary>
    public partial class NavigationPaneView : UserControl
    {
        public NavigationPaneView(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<NavigationMenuItemSelectedEvent>().Subscribe(UpdateNavigationPaneFilter);

            InitializeComponent();
        }

        private void UpdateNavigationPaneFilter(NavigationMenuItemSelectedEventPayload payload)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(NavigationPane.Items);
            cv.Filter = item => Filter(item, payload.ModuleName);
        }

        private bool Filter(object item, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return false;

            if (item != null && item is ListBoxItem && (item as ListBoxItem).DataContext is NavigationMenuItemModel)
            {
                return ((item as ListBoxItem).DataContext as NavigationMenuItemModel).ModuleName == filter;
            }

            return false;
        }
    }
}
