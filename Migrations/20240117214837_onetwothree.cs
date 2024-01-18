using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class onetwothree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserVerifications",
                type: "datetime(6)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserVerifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9e27d4c-a707-476b-a971-bdcc77bf5d1b", "$2a$10$LONRDeeIS/7M7JUfVPv2qOkqDd5kkCi/V83q0eoFwqS0dHhWkw/Uy" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f5dceb7-59a6-4b71-8099-3525bb5e1952", "$2a$10$LONRDeeIS/7M7JUfVPv2qOs/UYcRmh4AipIijKbTvZCxHyxl8y1/G" });
        }
    }
}
