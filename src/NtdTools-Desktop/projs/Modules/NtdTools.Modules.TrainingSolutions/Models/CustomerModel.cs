using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.TrainingSolutions.Models
{
    public class CustomerModel : BindableBase
    {
		private Guid _id;
		public Guid Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		private string _companyName;
		public string CompanyName
		{
			get { return _companyName; }
			set { SetProperty( ref _companyName , value); }
		}

        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set { SetProperty(ref _postalCode, value); }
        }
    }
}
