using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50866300-3ba8-4447-8d4a-51245dd1afd2", "$2a$10$3NLr3293p4lW3Rf2.By7T.vHtvNmp2yKhLSqx4.yoSpJSiSq2nKDW" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "593cd62d-f9da-4db3-85a5-6b356f1aade1", "$2a$10$3NLr3293p4lW3Rf2.By7T.qenfkDUPwQl8HfDdGPG9BNI3E9qn6xG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd6685a3-13ff-4856-a744-d761accfeb76", "$2a$10$Bi5B4EhwvMMRLVg2ZW1KIunloEu15WLah2.nzcwugnihEIXXkNGRi" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "200cac78-71e4-4b04-b7b5-df4b1776b8ac", "$2a$10$Bi5B4EhwvMMRLVg2ZW1KIu7ST1zD2ZsTq6QKhYSBAXwvV8XMTHneK" });
        }
    }
}
