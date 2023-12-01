using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class jujuju : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Roles" },
                values: new object[] { "008329ca-b911-484f-b229-0610760a1a2e", "$2a$10$NhXI2scJhVxg/mWp5.JXOeUy7uTZOtw60ZQzgoc7O/Tqgtzi2h.Ra", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Roles" },
                values: new object[] { "edb972d8-223c-4055-a095-c53c8bbbb977", "$2a$10$SONI/8V4EkK2grmhbEfnyecczOK2OKU5UBXgatny/33mNt9KvUTTu", "Student" });
        }
    }
}
