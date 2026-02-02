using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UserEditModel
{
    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    public string AdSoyad { get; set; } = null!;

    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    public string? Password { get; set; } = null!;

    [Display(Name = "Tekrar Parola")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")]
    public string? PasswordConfirm { get; set; } = null!;

    public IList<string>? SelectedRoles { get; set; }
}