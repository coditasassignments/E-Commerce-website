using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Cotton Shirt for comfort", "download.jfif", "Shirt", 599.0 },
                    { 2, "Cotton Shirt for comfort", "download.jfif", "Shirt", 599.0 },
                    { 3, "Cotton Shirt for comfort", "download.jfif", "Shirt", 599.0 },
                    { 4, "Cotton Shirt for comfort", "download.jfif", "Shirt", 599.0 },
                    { 5, "Cotton Shirt for comfort", "download.jfif", "Shirt", 599.0 },
                    { 6, "Cotton Shirt for comfort", "download.jfif", "Shirt", 599.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
