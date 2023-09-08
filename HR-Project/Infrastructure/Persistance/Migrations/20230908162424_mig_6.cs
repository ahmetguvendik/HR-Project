using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOk",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "IsOk",
                table: "EmployeeJob",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOk",
                table: "EmployeeJob");

            migrationBuilder.AddColumn<bool>(
                name: "IsOk",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
