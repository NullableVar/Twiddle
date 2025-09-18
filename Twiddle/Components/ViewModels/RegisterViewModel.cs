using System.ComponentModel.DataAnnotations;

namespace Twiddle.Components.ViewModels;

internal class RegisterViewModel
{
    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters.")]
    [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
}