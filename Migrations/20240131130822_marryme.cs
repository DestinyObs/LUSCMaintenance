using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class marryme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceProblems_MaintenanceIssues_MaintenanceIssueId",
                table: "MaintenanceProblems");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceProblems_MaintenanceIssueId",
                table: "MaintenanceProblems");

            migrationBuilder.DropColumn(
                name: "MaintenanceIssueId",
                table: "MaintenanceProblems");

            migrationBuilder.AlterColumn<string>(
                name: "Block",
                table: "MaintenanceProblems",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldMaxLength: 1)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceProblemId",
                table: "MaintenanceIssues",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abd06e72-ce97-45b6-8eb6-81e3a521ad07", "$2a$10$aL/zm/GNb.u8r0FW0q8waeeaOfSEWMlTspAlwbfMHzjx8.r1KGFXm" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2289bc0a-551f-4a35-a3fe-ff5a56fd3ec8", "$2a$10$aL/zm/GNb.u8r0FW0q8waeUTXzVWUbWq2oU7rQDmPC49x83sAVQx." });

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 5,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 6,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 7,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 8,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 9,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 10,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 11,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 12,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 13,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 14,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 15,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 16,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 17,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 18,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 19,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 20,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 21,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 22,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 23,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 24,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 25,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 26,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 27,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 28,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 29,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 30,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 31,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 32,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 33,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 34,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 35,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceIssues",
                keyColumn: "Id",
                keyValue: 36,
                column: "MaintenanceProblemId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_MaintenanceProblemId",
                table: "MaintenanceIssues",
                column: "MaintenanceProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceIssues_MaintenanceProblems_MaintenanceProblemId",
                table: "MaintenanceIssues",
                column: "MaintenanceProblemId",
                principalTable: "MaintenanceProblems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceIssues_MaintenanceProblems_MaintenanceProblemId",
                table: "MaintenanceIssues");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceIssues_MaintenanceProblemId",
                table: "MaintenanceIssues");

            migrationBuilder.DropColumn(
                name: "MaintenanceProblemId",
                table: "MaintenanceIssues");

            migrationBuilder.AlterColumn<string>(
                name: "Block",
                table: "MaintenanceProblems",
                type: "varchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceIssueId",
                table: "MaintenanceProblems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1a1daa0-a2ab-4edb-857c-d906a68954c1", "$2a$10$MEA6e64RRt27guXKeHkCR.prY7tKW3Ic0Yyx6lAhBLM6CDj1HoOxa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40273e92-e50b-40ad-b5cd-0c18abe0aaa1", "$2a$10$MEA6e64RRt27guXKeHkCR.llYxsZuLgw3WMnStk8y.v9sD2rXrK/q" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceProblems_MaintenanceIssueId",
                table: "MaintenanceProblems",
                column: "MaintenanceIssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceProblems_MaintenanceIssues_MaintenanceIssueId",
                table: "MaintenanceProblems",
                column: "MaintenanceIssueId",
                principalTable: "MaintenanceIssues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
