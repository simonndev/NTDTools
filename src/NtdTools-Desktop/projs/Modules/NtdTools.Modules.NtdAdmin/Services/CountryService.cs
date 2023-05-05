using NtdTools.Modules.NtdAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NtdTools.Modules.NtdAdmin.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryModel>> GetCountriesAsync(CancellationToken cancellationToken);
    }

    public class CountryService : ICountryService
    {
        public Task<IEnumerable<CountryModel>> GetCountriesAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Enumerable.Empty<CountryModel>());
        }
    }
}
