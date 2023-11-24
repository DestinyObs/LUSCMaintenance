using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class newoneonww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MaintenanceIssueCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electrical Maintenance" },
                    { 2, "Carpentry" },
                    { 3, "Plumbing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
