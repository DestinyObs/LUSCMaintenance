using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class Doris : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hostel",
                table: "MaintenanceProblems",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24411d34-07f3-43e8-ab4b-ec7477fe1155", "$2a$10$LzwGl3.fWu8Sg5HSFmJDMe53d/1EvUiy1nWO4TtVvHMTevgn7SJkS" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "393af675-04d7-47ee-8af1-86f9291464e5", "$2a$10$LzwGl3.fWu8Sg5HSFmJDMeHNBBnHidWRNalzA8mXEqgYUqUJ7GmEy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Hostel",
                table: "MaintenanceProblems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "480cd6c4-52ec-4f0b-ad79-af2ff6f3a860", "$2a$10$sLB0XdNLrA7pr57MGUBOSOwsQ838DGHnJSk2aF0JCoKDgx31Uvbwm" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "284c8bc6-b7f7-4d55-80eb-05f03ee1c0b7", "$2a$10$sLB0XdNLrA7pr57MGUBOSOnSW8OzxSpH6nIvIeVRozAS/.r9x/g46" });
        }
    }
}
