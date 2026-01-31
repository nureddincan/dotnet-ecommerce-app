using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class AccountCreateModel
{
    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    // [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Sadece sayı ve harf giriniz.")]
    public string AdSoyad { get; set; } = null!;

    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [EmailAddress]
    public string Email { get; set; } = null!;


    [Display(Name = "Şifre")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Tekrar Şifre")]
    [Required(ErrorMessage = "{0} alanı zorunludur.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")]
    public string PasswordConfirm { get; set; } = null!;
}

