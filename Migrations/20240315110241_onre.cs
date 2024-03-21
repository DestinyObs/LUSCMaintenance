using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class onre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
