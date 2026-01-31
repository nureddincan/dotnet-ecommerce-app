using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class SliderModel
{

    [Display(Name = "Başlık")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
    public string? Baslik { get; set; }

    [Display(Name = "Açıklama")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
    public string? Aciklama { get; set; }

    [Display(Name = "Resim")]
    public IFormFile? Resim { get; set; } = null!;

    [Display(Name = "Index")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [Range(0, int.MaxValue, ErrorMessage = "{0} {1}'a eşit veya daha büyük olmalıdır.")]
    public int Index { get; set; }

    [Display(Name = "Aktif")]
    public bool AktifMi { get; set; }
}