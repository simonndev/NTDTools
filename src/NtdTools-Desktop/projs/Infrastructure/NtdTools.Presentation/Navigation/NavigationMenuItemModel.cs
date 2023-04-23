using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Presentation.Navigation
{
    public enum NavIcons
    {
        Default = 0,
        Home
    }

    public enum NavKind
    {
        /// <summary>
        /// Icon and Text
        /// </summary>
        Default = 0,
        Input,
        TextOnly
    }

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

        private string? _moduleName;
        public string? ModuleName
        {
            get => _moduleName;
            set => SetProperty(ref _moduleName, value);
        }

        private NavKind _kind;
        public NavKind Kind
        {
            get { return _kind; }
            set
            {
                if (value != _kind)
                {
                    SetProperty(ref _kind, value);
                }
            }
        }

        private NavIcons _icon;
        public NavIcons Icon
        {
            get { return _icon; }
            set
            {
                if (value != _icon)
                {
                    SetProperty(ref _icon, value);
                }
            }
        }

        private string? _inputText;
        public string? InputText
        {
            get { return _inputText; }
            set
            {
                if (value is not null)
                {
                    SetProperty(ref _inputText, value);
                }
            }
        }

        public bool Selectable { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (Selectable)
                {
                    SetProperty(ref _isSelected, value);

                    if (value) OnItemSelected();
                }
            }
        }

        /// <summary>
        /// Notify the container that this item has been selected.
        /// </summary>
        /// <remarks>
        /// The container will listen to this event when raised,
        /// and call the <see cref="Prism.Events.IEventAggregator"/> to publish an event to display the associate content view accordingly. 
        /// </remarks>
        public event EventHandler ItemSelected;

        protected void OnItemSelected()
        {
            var handler = ItemSelected;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
