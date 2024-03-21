using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class eoeoe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b882fb5a-0734-4253-9918-6a2079756cba", "$2a$10$vu7o85fHwvARcn8tKoDiB.CXCNdbRmS/Lbp3JiDO1ZWIjxCgYSiby" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d5dd771-78b3-472b-8c66-f82b5adea4c4", "$2a$10$vu7o85fHwvARcn8tKoDiB.JUemCOAPpCQathDYUm2d2C0hRwYOSgK" });
        }
    }
}
