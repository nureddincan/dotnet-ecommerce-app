using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class OrderCreateModel
{

    public int Id { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} boş bırakılamaz.")]
    public string AdSoyad { get; set; } = null!;

    [Display(Name = "Şehir")]
    [Required(ErrorMessage = "{0} boş bırakılamaz.")]
    public string City { get; set; } = null!;

    [Display(Name = "Adres")]
    [Required(ErrorMessage = "{0} boş bırakılamaz.")]
    [StringLength(maximumLength: 50, ErrorMessage = "{0} en az {2} en çok {1} karakter olabilir.", MinimumLength = 10)]

    public string Address { get; set; } = null!;

    [Display(Name = "Posta Kodu")]
    [Required(ErrorMessage = "{0} boş bırakılamaz.")]

    public string PostCode { get; set; } = null!;

    [Display(Name = "Telefon Numarası")]
    [Required(ErrorMessage = "{0} boş bırakılamaz.")]
    public string TelNo { get; set; } = null!;

    [Display(Name = "Sipariş Notu")]
    [StringLength(maximumLength: 50, ErrorMessage = "{0} en az {2} en çok {1} karakter olabilir.", MinimumLength = 0)]
    public string? OrderNote { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();

    [Display(Name = "Kart Sahibinin Adı")]
    public string CartName { get; set; } = null!;

    [Display(Name = "Kart Numarası")]
    public string CartNumber { get; set; } = null!;

    [Display(Name = "Son Kullanma Tarihi")]
    public string CartExpirationYear { get; set; } = null!;

    public string CartExpirationMonth { get; set; } = null!;

    [Display(Name = "Kart CVV")]
    public string CartCVV { get; set; } = null!;
}