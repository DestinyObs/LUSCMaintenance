using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class marrymeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MaintenanceProblemIssue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaintenanceProblemId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceIssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceProblemIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceProblemIssue_MaintenanceIssues_MaintenanceIssueId",
                        column: x => x.MaintenanceIssueId,
                        principalTable: "MaintenanceIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceProblemIssue_MaintenanceProblems_MaintenanceProbl~",
                        column: x => x.MaintenanceProblemId,
                        principalTable: "MaintenanceProblems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bc2b471-4b12-4408-8384-928c765bd290", "$2a$10$dsFG3LreqzY8qtO8QZ5ru.JQY/hB/4eqDk2IksIKRjJt0YOlWeyrq" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acb96e68-49df-4a37-b3ad-6aa3c95b8a79", "$2a$10$dsFG3LreqzY8qtO8QZ5ru.2vBMiKggO7tc4..Qn4CdaV7IuPfHZxK" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceProblemIssue_MaintenanceIssueId",
                table: "MaintenanceProblemIssue",
                column: "MaintenanceIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceProblemIssue_MaintenanceProblemId",
                table: "MaintenanceProblemIssue",
                column: "MaintenanceProblemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceProblemIssue");

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
                values: new object[] { "2e9ee1d1-0630-4f97-a8a0-bb285f03bb91", "$2a$10$hffZ7DSetMeZzelL.ezkRezcdH5nxT/xDa/knIe/VTDD8eIVMMMx6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73723371-f898-427c-a82d-954da9858eb8", "$2a$10$hffZ7DSetMeZzelL.ezkReBXJwI22buuhng1HTT5Lt3uBs8NerbR2" });

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
    }
}
