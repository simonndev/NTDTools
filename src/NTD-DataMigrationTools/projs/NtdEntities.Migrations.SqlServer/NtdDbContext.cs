using Microsoft.EntityFrameworkCore;
using NtdEntities.Master;
using System.Reflection;

namespace NtdEntities.Migrations.SqlServer
{
    /// <summary>
    /// Base class for the EF Core database context used for Microsoft SQL Server.
    /// </summary>
    public class NtdDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NtdDbContext"/>.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public NtdDbContext(DbContextOptions<NtdDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}