using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class newoneonw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceIssueCategory",
                table: "MaintenanceIssueCategory");

            migrationBuilder.RenameTable(
                name: "MaintenanceIssueCategory",
                newName: "MaintenanceIssueCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceIssueCategories",
                table: "MaintenanceIssueCategories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceIssueCategories",
                table: "MaintenanceIssueCategories");

            migrationBuilder.RenameTable(
                name: "MaintenanceIssueCategories",
                newName: "MaintenanceIssueCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceIssueCategory",
                table: "MaintenanceIssueCategory",
                column: "Id");
        }
    }
}
