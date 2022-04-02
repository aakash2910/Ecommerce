using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "Slug", "Sorting", "Title" },
                values: new object[] { 1, "Home Page", "Home", 0, "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "Slug", "Sorting", "Title" },
                values: new object[] { 2, "About Us Page", "about-us", 100, "About Us" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Content", "Slug", "Sorting", "Title" },
                values: new object[] { 3, "Services Page", "services", 100, "Services" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
