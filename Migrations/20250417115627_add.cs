using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "ID",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "ID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ID", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 1 }
                });
        }
    }
}
