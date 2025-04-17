using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class AddCartItemAndCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserID",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CartId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CartId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "ID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Password", "UserName" },
                values: new object[] { 1, "", "1234", "Pranjali" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1,
                column: "CartId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2,
                column: "CartId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
