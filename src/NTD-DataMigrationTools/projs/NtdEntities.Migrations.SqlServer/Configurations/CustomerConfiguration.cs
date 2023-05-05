using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NtdEntities.Master;

namespace NtdEntities.Migrations.SqlServer
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer", "master");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(c => c.MasterOfficeId).HasColumnName("master_office_id");
            builder.HasOne(c => c.MasterOffice)
                .WithMany(c => c.BranchOffices)
                .HasForeignKey(c => c.MasterOfficeId)
                .IsRequired(required: false);

            builder.HasMany(c => c.Employees)
                .WithOne(e => e.Office)
                .HasForeignKey(e => e.OfficeId)
                .IsRequired(required: false);

            builder.Property(c => c.CompanyName).HasColumnName("company_name").IsRequired(true).HasMaxLength(100);
            builder.HasIndex(c => c.CompanyName);

            builder.Property(c => c.Address).HasColumnName("address").IsRequired(false).HasMaxLength(100);
            builder.Property(c => c.Address2).HasColumnName("address2").IsRequired(false).HasMaxLength(100);
            builder.Property(c => c.City).HasColumnName("city").IsRequired(false).HasMaxLength(65);
            builder.Property(c => c.State).HasColumnName("state").IsRequired(false).HasMaxLength(65);
            builder.Property(c => c.Province).HasColumnName("province").IsRequired(false).HasMaxLength(65);
            builder.Property(c => c.Region).HasColumnName("region").IsRequired(false).HasMaxLength(65);
            builder.Property(c => c.PostalCode).HasColumnName("postal_code").IsRequired(false).HasMaxLength(10);

            builder.Property(c => c.Country).HasColumnName("country").IsRequired(true).HasMaxLength(2);
            builder.HasIndex(c => c.Country);
            
            builder.Property(c => c.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(c => c.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            
            builder.Property(c => c.CreatedBy).HasColumnName("created_by").IsRequired(true).HasMaxLength(65);
            builder.Property(c => c.CreatedOn).HasColumnName("created_on").IsRequired(true).HasDefaultValueSql("getutcdate()");
            builder.Property(c => c.UpdatedBy).HasColumnName("updated_by").IsRequired(false).HasMaxLength(65);
            builder.Property(c => c.UpdatedOn).HasColumnName("updated_on").IsRequired(false);

            builder.Property(c => c.RowVersion).HasColumnName("rowver").IsRequired(true).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
        }
    }
}
