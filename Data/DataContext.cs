using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
    public DbSet<Slider> Sliderlar { get; set; }
    public DbSet<Cart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Slider>().HasData(
            new List<Slider>
            {
                new Slider { Id=1, Baslik="Slider 1 Başlık", Aciklama="Slider 1 Açıklama", Resim="slider-1.jpeg", AktifMi=true, Index=0 },
                new Slider { Id=2, Baslik="Slider 2 Başlık", Aciklama="Slider 2 Açıklama", Resim="slider-2.jpeg", AktifMi=true, Index=1 },
                new Slider { Id=3, Baslik="Slider 3 Başlık", Aciklama="Slider 3 Açıklama", Resim="slider-3.jpeg", AktifMi=true, Index=2 }
            }
        );

        modelBuilder.Entity<Kategori>().HasData(
            new List<Kategori>
            {
                new Kategori {Id=1, Ad="Telefon", Url="telefon"},
                new Kategori {Id=2, Ad="Elektronik", Url="elektronik"},
                new Kategori {Id=3, Ad="Beyaz Eşya", Url="beyaz-esya"},
                new Kategori {Id=4, Ad="Giyim", Url="giyim"},
                new Kategori {Id=5, Ad="Kozmetik", Url="kozmetik"},
                new Kategori {Id=6, Ad="Kategori 6", Url="kategori-6"},
                new Kategori {Id=7, Ad="Kategori 7", Url="kategori-7"},
                new Kategori {Id=8, Ad="Kategori 8", Url="kategori-8"},
                new Kategori {Id=9, Ad="Kategori 9", Url="kategori-9"},
            }
        );
        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>()
            {
                new Urun() {
                    Id = 1, Ad = "Apple Watch 7",
                    Fiyat = 10000, AktifMi = false,
                    Resim="1.jpeg", Anasayfa=true,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 1},
                new Urun() {
                    Id = 2, Ad = "Apple Watch 8",
                    Fiyat = 20000, AktifMi = true,
                    Resim="2.jpeg", Anasayfa=true,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 1},
                new Urun() {
                    Id = 3, Ad = "Apple Watch 9",
                    Fiyat = 30000, AktifMi = true,
                    Resim="3.jpeg", Anasayfa=true,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 2},
                new Urun() {
                    Id = 4, Ad = "Apple Watch 10",
                    Fiyat = 40000, AktifMi = false,
                    Resim="4.jpeg", Anasayfa=false,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 2},
                new Urun() {
                    Id = 5, Ad = "Apple Watch 11",
                    Fiyat = 50000, AktifMi = true,
                    Resim="5.jpeg", Anasayfa=true,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 2},
                new Urun() {
                    Id = 6, Ad = "Apple Watch 12",
                    Fiyat = 60000, AktifMi = true,
                    Resim="6.jpeg", Anasayfa=false,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 3},
                new Urun() {
                    Id = 7, Ad = "Apple Watch 13",
                    Fiyat = 70000, AktifMi = false,
                    Resim="7.jpeg", Anasayfa=false,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 3},
                new Urun() {
                    Id = 8, Ad = "Apple Watch 14",
                    Fiyat = 80000, AktifMi = true,
                    Resim="8.jpeg", Anasayfa=true,
                    Aciklama="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit aliquid dolores magni in unde sint fugiat nobis eveniet, culpa molestiae? Quam quasi quia nobis placeat facere hic harum unde! Facilis.",
                    KategoriId = 4},
            }
        );
    }
}