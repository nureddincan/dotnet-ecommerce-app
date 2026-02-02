namespace dotnet_store.Models;

public class Cart
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    public void AddItem(Urun urun, int miktar)
    {
        var addedItem = CartItems.FirstOrDefault(cartItem => cartItem.UrunId == urun.Id);

        // Ürün daha önce eklenmediyse
        if (addedItem == null)
        {
            CartItems.Add(new CartItem { Urun = urun, Miktar = miktar });
        }
        else
        {
            addedItem.Miktar += miktar;
        }
    }

    public void DeleteItem(int urunId, int miktar)
    {
        var addedItem = CartItems.FirstOrDefault(cartItem => cartItem.UrunId == urunId);

        if (addedItem != null)
        {
            addedItem.Miktar -= miktar;

            if (addedItem.Miktar == 0)
            {
                CartItems.Remove(addedItem);
            }
        }
    }
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