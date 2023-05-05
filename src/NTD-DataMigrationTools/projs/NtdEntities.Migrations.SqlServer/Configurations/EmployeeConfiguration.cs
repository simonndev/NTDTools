using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NtdEntities.Master;

namespace NtdEntities.Migrations.SqlServer
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee", "master");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).HasColumnName("first_name").IsRequired(true).HasMaxLength(75);
            builder.HasIndex(e => e.FirstName);
            builder.Property(e => e.LastName).HasColumnName("last_name").IsRequired(true).HasMaxLength(75);
            builder.HasIndex(e => e.LastName);

            builder.Property(e => e.Salutation).HasColumnName("salutation").IsRequired(false).HasMaxLength(75);
            builder.Property(e => e.BirthDate).HasColumnName("birth_date");
            builder.Property(e => e.HireDate).HasColumnName("hire_date");
            builder.Property(e => e.ReportsTo).HasColumnName("reports_to").IsRequired(false).HasMaxLength(255);
            builder.Property(e => e.JobTitle).HasColumnName("job_title").IsRequired(false).HasMaxLength(75);
            builder.Property(e => e.OrgUnit).HasColumnName("orgunit").IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

            builder.Property(e => e.OfficeId).HasColumnName("office_id");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by").IsRequired(true).HasMaxLength(65);
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired(true).HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by").IsRequired(false).HasMaxLength(65);
            builder.Property(e => e.UpdatedOn).HasColumnName("updated_on").IsRequired(false);

            builder.Property(e => e.RowVersion).HasColumnName("rowver").IsRequired(true).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
        }
    }
}
