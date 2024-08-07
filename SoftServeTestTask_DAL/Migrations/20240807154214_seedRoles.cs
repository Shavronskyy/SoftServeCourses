using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftServeTestTask_DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
