using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Presentation.Events
{
    public class NavigationMenuItemSelectedEvent : PubSubEvent<NavigationMenuItemSelectedEventPayload>
    {
    }

    public class NavigationMenuItemSelectedEventPayload
    {
        public string? ModuleName { get; set; }
    }
}
