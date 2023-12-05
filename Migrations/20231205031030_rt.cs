using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class rt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "MaintenanceProblems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e14b23a-e06d-4c86-9fa9-bca8747517fa", "$2a$10$Hd.E/BuwjR3T6OVcnfC2Vu5I4wS.8JVTh0IvdTCUtD1vdVFg5sMOW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "MaintenanceProblems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d9349bc-1cb4-4214-92f8-fa82d7d4077d", "$2a$10$YGzj92pmQmHHzhvFG62pT.ZsWxBgaHeVR88yTaJDZAg29cBt982mC" });
        }
    }
}
