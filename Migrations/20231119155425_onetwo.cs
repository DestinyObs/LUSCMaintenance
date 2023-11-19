using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSC_e_Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class onetwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserVerificationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVerifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserVerificationId",
                table: "Users",
                column: "UserVerificationId",
                unique: true,
                filter: "[UserVerificationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserVerifications_UserVerificationId",
                table: "Users",
                column: "UserVerificationId",
                principalTable: "UserVerifications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserVerifications_UserVerificationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserVerifications");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserVerificationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserVerificationId",
                table: "Users");
        }
    }
}
