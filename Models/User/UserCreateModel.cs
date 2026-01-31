using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UserCreateModel
{
    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    public string AdSoyad { get; set; } = null!;

    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [EmailAddress]
    public string Email { get; set; } = null!;
}


