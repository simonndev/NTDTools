using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.NtdAdmin.Models
{
	public class CountryModel : BindableBase
	{
		private int _id;
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

        private string _iso2;
        public string Iso2
        {
            get { return _iso2; }
            set { SetProperty(ref _iso2, value); }
        }

        private string? _iso3;
        public string? Iso3
        {
            get { return _iso3; }
            set { SetProperty(ref _iso3, value); }
        }

        private string? _nativeName;
		public string? NativeName
		{
			get { return _nativeName; }
			set { SetProperty(ref _nativeName, value); }
		}

		private string? _fullNativeName;
		public string? FullNativeName
		{
			get { return _fullNativeName; }
			set { SetProperty(ref _fullNativeName, value); }
		}

        private string _englishName;
        public string EnglishName
        {
            get { return _englishName; }
            set { SetProperty(ref _englishName, value); }
        }

        private string? _fullEnglishName;
        public string? FullEnglishName
        {
            get { return _fullEnglishName; }
            set { SetProperty(ref _fullEnglishName, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }
    }
}
