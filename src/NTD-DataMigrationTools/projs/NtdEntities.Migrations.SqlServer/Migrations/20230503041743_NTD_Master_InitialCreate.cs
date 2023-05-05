using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NtdEntities.Migrations.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class NTD_Master_InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "master",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    state = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    province = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    region = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    master_office_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_by = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_by = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowver = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_customer_master_office_id",
                        column: x => x.master_office_id,
                        principalSchema: "master",
                        principalTable: "customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "master",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    salutation = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hire_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reports_to = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    job_title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    orgunit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    office_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_by = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowver = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_customer_office_id",
                        column: x => x.office_id,
                        principalSchema: "master",
                        principalTable: "customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_master_office_id",
                schema: "master",
                table: "customer",
                column: "master_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_office_id",
                schema: "master",
                table: "employee",
                column: "office_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee",
                schema: "master");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "master");
        }
    }
}
