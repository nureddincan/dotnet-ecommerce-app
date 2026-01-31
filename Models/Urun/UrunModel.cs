using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UrunModel
{
    [Display(Name = "Ürün Adı")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
    public string Ad { get; set; } = null!;

    [Display(Name = "Fiyat")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "{0} {1}'dan büyük olmalıdır.")]
    public double? Fiyat { get; set; }

    [Display(Name = "Resim")]
    public IFormFile? Resim { get; set; }

    [Display(Name = "Açıklama")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
    public string? Aciklama { get; set; } = null!;

    [Display(Name = "Aktif")]
    public bool AktifMi { get; set; }

    [Display(Name = "Anasayfa")]
    public bool Anasayfa { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    public int? KategoriId { get; set; }
}

