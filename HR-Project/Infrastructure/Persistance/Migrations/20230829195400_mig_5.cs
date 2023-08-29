using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Employees_EmployeesId",
                table: "EmployeeJob");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Jobs_JobsId",
                table: "EmployeeJob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob");

            migrationBuilder.RenameColumn(
                name: "JobsId",
                table: "EmployeeJob",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeJob",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJob_JobsId",
                table: "EmployeeJob",
                newName: "IX_EmployeeJob_JobId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "EmployeeJob",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJob_EmployeeId",
                table: "EmployeeJob",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJob_Employees_EmployeeId",
                table: "EmployeeJob",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJob_Jobs_JobId",
                table: "EmployeeJob",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Employees_EmployeeId",
                table: "EmployeeJob");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Jobs_JobId",
                table: "EmployeeJob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJob_EmployeeId",
                table: "EmployeeJob");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeJob");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "EmployeeJob",
                newName: "JobsId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeJob",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJob_JobId",
                table: "EmployeeJob",
                newName: "IX_EmployeeJob_JobsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeJob",
                table: "EmployeeJob",
                columns: new[] { "EmployeesId", "JobsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJob_Employees_EmployeesId",
                table: "EmployeeJob",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJob_Jobs_JobsId",
                table: "EmployeeJob",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
