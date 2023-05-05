using NtdTools.Modules.TrainingSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtdTools.Modules.TrainingSolutions.Services
{
    public class CustomerService
    {
        public Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            return Task.FromResult(Enumerable.Empty<CustomerModel>());
        }
    }
}
