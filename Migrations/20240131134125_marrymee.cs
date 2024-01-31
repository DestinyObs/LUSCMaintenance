using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class marrymee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e9ee1d1-0630-4f97-a8a0-bb285f03bb91", "$2a$10$hffZ7DSetMeZzelL.ezkRezcdH5nxT/xDa/knIe/VTDD8eIVMMMx6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73723371-f898-427c-a82d-954da9858eb8", "$2a$10$hffZ7DSetMeZzelL.ezkReBXJwI22buuhng1HTT5Lt3uBs8NerbR2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abd06e72-ce97-45b6-8eb6-81e3a521ad07", "$2a$10$aL/zm/GNb.u8r0FW0q8waeeaOfSEWMlTspAlwbfMHzjx8.r1KGFXm" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2289bc0a-551f-4a35-a3fe-ff5a56fd3ec8", "$2a$10$aL/zm/GNb.u8r0FW0q8waeUTXzVWUbWq2oU7rQDmPC49x83sAVQx." });
        }
    }
}
