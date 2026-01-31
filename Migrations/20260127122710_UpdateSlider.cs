using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: "slider-1.jpeg");

            migrationBuilder.UpdateData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: "slider-2.jpeg");

            migrationBuilder.UpdateData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "Resim",
                value: "slider-3.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: "slider-1-jpeg");

            migrationBuilder.UpdateData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: "slider-2-jpeg");

            migrationBuilder.UpdateData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "Resim",
                value: "slider-3-jpeg");
        }
    }
}
