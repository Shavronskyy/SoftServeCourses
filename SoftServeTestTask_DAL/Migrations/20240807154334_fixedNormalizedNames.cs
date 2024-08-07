using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftServeTestTask_DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixedNormalizedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fb0c7b9-c7f6-4877-a914-01a26492282c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "314c5cda-85e6-46cb-9fdf-4d0ab835b0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af043be-e09f-4ab8-852c-606f9473714a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "374893ca-9077-4681-98d6-92f731c8fed4", null, "Teacher", "Teacher" },
                    { "4a4caeec-def2-4a4c-9635-72e39af35fe6", null, "admin", "admin" },
                    { "749a047e-6862-4486-bcb2-73236f25838a", null, "Student", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "374893ca-9077-4681-98d6-92f731c8fed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a4caeec-def2-4a4c-9635-72e39af35fe6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "749a047e-6862-4486-bcb2-73236f25838a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fb0c7b9-c7f6-4877-a914-01a26492282c", null, "Teacher", null },
                    { "314c5cda-85e6-46cb-9fdf-4d0ab835b0c1", null, "Student", null },
                    { "7af043be-e09f-4ab8-852c-606f9473714a", null, "admin", "Teacher" }
                });
        }
    }
}
