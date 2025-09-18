using System.ComponentModel.DataAnnotations;

namespace Twiddle.DataAccess.Database.Entities;

internal class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public bool RememberMe { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLogin { get; set; }
}