using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class wewe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
