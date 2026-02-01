namespace dotnet_store.Models;

public class Cart
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
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