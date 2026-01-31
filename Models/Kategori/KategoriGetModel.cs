namespace dotnet_store.Models;

// Veri taşıyorsam model ismini veriyorum.
public class KategoriGetModel
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public string Url { get; set; } = null!;
    public int UrunSayisi { get; set; }
}
