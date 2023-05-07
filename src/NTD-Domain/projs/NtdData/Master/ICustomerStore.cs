using System;
using System.Threading;
using System.Threading.Tasks;

namespace NtdData.Master
{
    public interface ICustomerStore<TCustomer> : IEntityStore<TCustomer>
        where TCustomer : class
    {
        Task<string> GetCustomerIdStringAsync(TCustomer customer, CancellationToken cancellationToken);
    }

    public interface IQueryableCustomerStore<TCustomer> : ICustomerStore<TCustomer>, IQueryableEntityStore<TCustomer>
        where TCustomer : class
    { }
}
