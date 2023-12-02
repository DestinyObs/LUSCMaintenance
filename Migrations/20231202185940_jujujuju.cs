using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class jujujuju : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateComplaintMade",
                table: "MaintenanceProblems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d9349bc-1cb4-4214-92f8-fa82d7d4077d", "$2a$10$YGzj92pmQmHHzhvFG62pT.ZsWxBgaHeVR88yTaJDZAg29cBt982mC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateComplaintMade",
                table: "MaintenanceProblems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "008329ca-b911-484f-b229-0610760a1a2e", "$2a$10$NhXI2scJhVxg/mWp5.JXOeUy7uTZOtw60ZQzgoc7O/Tqgtzi2h.Ra" });
        }
    }
}
