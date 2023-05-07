using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NtdData.Master
{
    public interface ICustomerOrganizationStore<TCustomer> : ICustomerStore<TCustomer>
        where TCustomer : class
    {
        Task<IList<TCustomer>> GetBranchOfficesAsync(TCustomer customer, CancellationToken cancellationToken);
        Task<TCustomer> GetMasterOfficeAsync(TCustomer customer, CancellationToken cancellationToken);
    }
}
