using System;
using System.Collections.Generic;
using System.Text;

namespace NtdEntities.Master
{
    public class Employee : NtdEntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }
        public string ReportsTo { get; set; }
        public string JobTitle { get; set; }
        public string OrgUnit { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Guid? OfficeId { get; set; }
        public virtual Customer Office { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
