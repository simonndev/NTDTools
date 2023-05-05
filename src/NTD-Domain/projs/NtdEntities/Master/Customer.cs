using System;
using System.Collections.Generic;
using System.Text;

namespace NtdEntities.Master
{
    public class Customer : NtdEntityBase<Guid>
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Province { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        /// <summary>
        /// Country ISO-2 code.
        /// </summary>
        public string Country { get; set; }

        public virtual Guid? MasterOfficeId { get; set; }
        public virtual Customer MasterOffice { get; set; }
        public virtual ICollection<Customer> BranchOffices { get; set; } = new HashSet<Customer>();

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
