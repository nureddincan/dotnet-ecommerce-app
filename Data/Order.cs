namespace dotnet_store.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string AdSoyad { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostCode { get; set; } = null!;
    public string TelNo { get; set; } = null!;
    public double TotalPrice { get; set; }
    public string? OrderNote { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();

      public double AraToplam()
    {
        return OrderItems.Sum(item => item.Price * item.Count);
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

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int UrunId { get; set; }
    public Urun Urun { get; set; } = null!;
    public double Price { get; set; }
    public int Count { get; set; }
}