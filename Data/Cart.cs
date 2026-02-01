namespace dotnet_store.Models;

public class Cart
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    public double AraToplam()
    {
        return CartItems.Sum(item => item.Urun.Fiyat * item.Miktar);
    }

    public double ToplamVergi()
    {
        return AraToplam() * 0.2;
    }

    public double Toplam()
    {
        return ToplamVergi() + AraToplam();
    }
}

public class CartItem
{
    public int Id { get; set; }

    public int UrunId { get; set; }
    public Urun Urun { get; set; } = null!;

    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;

    public int Miktar { get; set; }
}