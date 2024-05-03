using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class inite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e70e5107-5904-41ea-98b3-793a8926254d", "$2a$10$Y.nyRFC.BTVZlwTbpH6kx.xwbMy/E1vce3Ms2IR.FbIjDqR5irUBW" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "311e638b-ee86-416d-bb99-987ad0cfb77a", "$2a$10$Y.nyRFC.BTVZlwTbpH6kx.fL2mp2fOvBfOtpl6cPX0b84BErcLs6K" });

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Electrical");

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Carpentry");

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Plumbing");

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Others");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Electrical Maintenance");

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Carpentry Maintenance");

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Plumbing Maintenance");

            migrationBuilder.UpdateData(
                table: "MaintenanceIssueCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Others Maintenance");
        }
    }
}
