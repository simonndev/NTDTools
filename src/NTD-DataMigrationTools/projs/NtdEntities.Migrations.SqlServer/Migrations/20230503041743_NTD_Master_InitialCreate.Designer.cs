﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NtdEntities.Migrations.SqlServer;

#nullable disable

namespace NtdEntities.Migrations.SqlServer.Migrations
{
    [DbContext(typeof(NtdDbContext))]
    [Migration("20230503041743_NTD_Master_InitialCreate")]
    partial class NTD_Master_InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NtdEntities.Master.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("address");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("address2");

                    b.Property<string>("City")
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("company_name");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("country");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("MasterOfficeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("master_office_id");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Province")
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("province");

                    b.Property<string>("Region")
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("region");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("rowver");

                    b.Property<string>("State")
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("state");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.HasIndex("MasterOfficeId");

                    b.ToTable("customer", "master");
                });

            modelBuilder.Entity("NtdEntities.Master.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("first_name");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hire_date");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("job_title");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("last_name");

                    b.Property<Guid?>("OfficeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("office_id");

                    b.Property<string>("OrgUnit")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("orgunit");

                    b.Property<string>("ReportsTo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("reports_to");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("rowver");

                    b.Property<string>("Salutation")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("salutation");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("employee", "master");
                });

            modelBuilder.Entity("NtdEntities.Master.Customer", b =>
                {
                    b.HasOne("NtdEntities.Master.Customer", "MasterOffice")
                        .WithMany("BranchOffices")
                        .HasForeignKey("MasterOfficeId");

                    b.Navigation("MasterOffice");
                });

            modelBuilder.Entity("NtdEntities.Master.Employee", b =>
                {
                    b.HasOne("NtdEntities.Master.Customer", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeId");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("NtdEntities.Master.Customer", b =>
                {
                    b.Navigation("BranchOffices");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}