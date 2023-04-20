using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Presentation.Navigation
{
    public class NavigationMenuItemModel : BindableBase
    {
        private string? _heading;
        public string? Heading
        {
            get => _heading;
            set => SetProperty(ref _heading, value);
        }

        private string? _subHeading;
        public string? SubHeading
        {
            get => _subHeading;
            set => SetProperty(ref _subHeading, value);
        }
    }
}
