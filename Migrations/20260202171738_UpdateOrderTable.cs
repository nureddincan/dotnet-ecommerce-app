using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Orders",
                newName: "AdSoyad");

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "AdSoyad",
                table: "Orders",
                newName: "Email");
        }
    }
}
