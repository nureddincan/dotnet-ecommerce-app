namespace dotnet_store.Models;

public class Urun
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public double Fiyat { get; set; }
    public string? Resim { get; set; }
    public string? Aciklama { get; set; }
    public bool AktifMi { get; set; }
    public bool Anasayfa { get; set; }
    public int KategoriId { get; set; }
    public Kategori Kategori { get; set; } = null!;
}
