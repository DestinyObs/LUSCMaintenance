using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class newrt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceIssueCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceIssues_MaintenanceIssueCategories_MaintenanceIssueCategoryId",
                        column: x => x.MaintenanceIssueCategoryId,
                        principalTable: "MaintenanceIssueCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceIssueCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Others" });

            migrationBuilder.InsertData(
                table: "MaintenanceIssues",
                columns: new[] { "Id", "Description", "MaintenanceIssueCategoryId" },
                values: new object[,]
                {
                    { 1, "Faulty Socket", 1 },
                    { 2, "Broken Door", 2 },
                    { 3, "Bad Window", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_MaintenanceIssueCategoryId",
                table: "MaintenanceIssues",
                column: "MaintenanceIssueCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceIssues");

            migrationBuilder.DeleteData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
