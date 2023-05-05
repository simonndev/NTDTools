using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace NtdTools.Presentation.Navigation
{
    public class FilterByNameListBoxProps
    {
        public static string GetNameFilter(DependencyObject obj)
        {
            return (string)obj.GetValue(NameFilterProperty);
        }

        public static void SetNameFilter(DependencyObject obj, string value)
        {
            obj.SetValue(NameFilterProperty, value);
        }

        // Using a DependencyProperty as the backing store for ModuleNameFilter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameFilterProperty =
            DependencyProperty.RegisterAttached("NameFilter", typeof(string), typeof(FilterByNameListBoxProps), new PropertyMetadata(null, OnNameFilterChanged));

        private static void OnNameFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lb = d as ListBox;
            if (lb != null)
            {
                ICollectionView cv = CollectionViewSource.GetDefaultView(lb.Items);
                string filter = GetNameFilter(d);
                cv.Filter = item => UpdateFilter(item, filter);
            }
        }

        private static bool UpdateFilter(object item, string filter)
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
