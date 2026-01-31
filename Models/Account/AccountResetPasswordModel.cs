using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class AccountResetPasswordModel
{
    public string Token { get; set; } = null!;
    public string Email { get; set; } = null!;

    [Display(Name = "Yeni Parola")]
    [Required(ErrorMessage = "{0} zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Tekrar Yeni Parola")]
    [Required(ErrorMessage = "{0} alanı zorunludur.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")]
    public string PasswordConfirm { get; set; } = null!;
}