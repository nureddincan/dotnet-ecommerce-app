using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressRow",
                table: "Orders",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "AddressRow");
        }
    }
}
