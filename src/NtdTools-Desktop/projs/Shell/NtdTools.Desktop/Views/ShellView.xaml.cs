using System.Windows;

namespace NtdTools.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();

            var vm = this.DataContext as ViewModels.ShellViewModel;
            this.Loaded += (s, e) => vm.OnViewLoaded();
        }
    }
}
