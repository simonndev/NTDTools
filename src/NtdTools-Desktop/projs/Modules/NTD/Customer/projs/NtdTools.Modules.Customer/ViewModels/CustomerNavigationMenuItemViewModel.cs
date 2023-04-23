using NtdTools.Presentation.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.Customer.ViewModels
{
    public class CustomerNavigationMenuItemViewModel : NavigationMenuItemModel
    {
        public CustomerNavigationMenuItemViewModel()
        {
            Heading = "Customer";
            Kind = NavKind.Default;
            Icon = NavIcons.Default;
            Selectable = true;
            ModuleName = nameof(CustomerModule);
        }
    }
}
