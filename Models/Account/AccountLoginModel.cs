using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class AccountLoginModel
{
    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Display(Name = "Şifre")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Beni Hatırla")]
    public bool BeniHatirla { get; set; } = true;
}

