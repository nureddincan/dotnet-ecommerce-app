using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class OrderCreateModel
{

    public int Id { get; set; }

    [Display(Name = "Ad Soyad")]
    public string AdSoyad { get; set; } = null!;

    [Display(Name = "Şehir")]
    public string City { get; set; } = null!;

    [Display(Name = "Adres")]
    public string Address { get; set; } = null!;

    [Display(Name = "Posta Kodu")]
    public string PostCode { get; set; } = null!;

    [Display(Name = "Telefon Numarası")]
    public string TelNo { get; set; } = null!;

    [Display(Name = "Sipariş Notu")]
    public string? OrderNote { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();

}