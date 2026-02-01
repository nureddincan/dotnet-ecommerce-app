namespace dotnet_store.Models;

public class Kategori
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public string Url { get; set; } = null!;
    public List<Urun> Uruns { get; set; } = new(); // navigation property
}