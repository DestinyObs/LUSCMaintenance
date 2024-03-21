using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class eoeoef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0d80944-6f6f-4e15-b29b-18d0676f28f0", "$2a$10$HX9XfOyEpr5TIlg/dnN8e.w4fsW9koxoqxfTxk1Wu9OFeCkCArbcq" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccec19cd-4809-4b28-a92d-0cf50bd751eb", "$2a$10$HX9XfOyEpr5TIlg/dnN8e.tlBVlOmqCSMBGjcgGSw3uj6yte2OIWO" });
        }
    }
}
