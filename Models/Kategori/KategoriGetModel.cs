namespace dotnet_store.Models;

public class KategoriGetModel
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public string Url { get; set; } = null!;
    public int UrunSayisi { get; set; }
}