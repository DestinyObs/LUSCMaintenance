using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class rtj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccbe6af6-2721-49c0-b8ed-9e5c3cd2c4f4", "$2a$10$FBIfI0XvOaB1Bsdg5NiAcuIclpJ0q8TAwA1fmPRmd13yPJPEsfmcC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e14b23a-e06d-4c86-9fa9-bca8747517fa", "$2a$10$Hd.E/BuwjR3T6OVcnfC2Vu5I4wS.8JVTh0IvdTCUtD1vdVFg5sMOW" });
        }
    }
}
