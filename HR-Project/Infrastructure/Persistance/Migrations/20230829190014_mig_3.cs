using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Jobs_jobsId",
                table: "EmployeeJob");

            migrationBuilder.RenameColumn(
                name: "jobsId",
                table: "EmployeeJob",
                newName: "JobsId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJob_jobsId",
                table: "EmployeeJob",
                newName: "IX_EmployeeJob_JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJob_Jobs_JobsId",
                table: "EmployeeJob",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Jobs_JobsId",
                table: "EmployeeJob");

            migrationBuilder.RenameColumn(
                name: "JobsId",
                table: "EmployeeJob",
                newName: "jobsId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJob_JobsId",
                table: "EmployeeJob",
                newName: "IX_EmployeeJob_jobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJob_Jobs_jobsId",
                table: "EmployeeJob",
                column: "jobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
