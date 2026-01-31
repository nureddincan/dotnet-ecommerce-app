using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrunEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StokMiktari",
                table: "Urunler",
                newName: "Anasayfa");

            migrationBuilder.AlterColumn<double>(
                name: "Fiyat",
                table: "Urunler",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Urunler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "Urunler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Anasayfa", "Fiyat", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", true, 10000.0, "1.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Anasayfa", "Fiyat", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", true, 20000.0, "2.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Anasayfa", "Fiyat", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", true, 30000.0, "3.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Anasayfa", "Fiyat", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", false, 40000.0, "4.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Anasayfa", "Fiyat", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", true, 50000.0, "5.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Anasayfa", "Fiyat", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", false, 60000.0, "6.jpeg" });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aciklama", "Ad", "AktifMi", "Anasayfa", "Fiyat", "Resim" },
                values: new object[,]
                {
                    { 7, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", "Apple Watch 13", false, false, 70000.0, "7.jpeg" },
                    { 8, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.", "Apple Watch 14", true, true, 80000.0, "8.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Resim",
                table: "Urunler");

            migrationBuilder.RenameColumn(
                name: "Anasayfa",
                table: "Urunler",
                newName: "StokMiktari");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fiyat",
                table: "Urunler",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fiyat", "StokMiktari" },
                values: new object[] { 10000m, 10 });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fiyat", "StokMiktari" },
                values: new object[] { 20000m, 50 });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fiyat", "StokMiktari" },
                values: new object[] { 30000m, 30 });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fiyat", "StokMiktari" },
                values: new object[] { 40000m, 20 });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fiyat", "StokMiktari" },
                values: new object[] { 50000m, 0 });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fiyat", "StokMiktari" },
                values: new object[] { 60000m, 0 });
        }
    }
}
