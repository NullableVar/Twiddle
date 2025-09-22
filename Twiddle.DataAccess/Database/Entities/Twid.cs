using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twiddle.DataAccess.Database.Entities;

public class Twid
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; } 

    [Required]
    [MaxLength(1024)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }
}