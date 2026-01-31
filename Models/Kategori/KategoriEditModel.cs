
using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class KategoriEditModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Kategori adı en az 3 en fazla 30 karakter olabilir.")]
    [Display(Name = "Kategori Adı")]
    public string Ad { get; set; } = null!;


    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Kategori adı en az 3 en fazla 30 karakter olabilir.")]
    [Display(Name = "Kategori URL")]
    public string Url { get; set; } = null!;
}