using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class RoleCreateModel
{
    [Required(ErrorMessage = "{0} zorunludur.")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
    [Display(Name = "Role Adı")]
    public string RoleAdi { get; set; } = null!;
}



