using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftServeTestTask_DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedRolesToRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "987069e7-ab37-4037-a089-776988026705", null, "Student", "Student" },
                    { "f78899f3-c215-427b-9ff3-818bc71870fb", null, "Teacher", "Teacher" },
                    { "fd3963d2-8bf2-4eff-8ba5-d5bba14660a3", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "987069e7-ab37-4037-a089-776988026705");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f78899f3-c215-427b-9ff3-818bc71870fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd3963d2-8bf2-4eff-8ba5-d5bba14660a3");
        }
    }
}
