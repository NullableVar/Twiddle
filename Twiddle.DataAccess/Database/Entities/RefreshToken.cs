using System.ComponentModel.DataAnnotations;

namespace Twiddle.DataAccess.Database.Entities;

internal class RefreshToken
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Token { get; set; } = string.Empty;

    [Required]
    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}