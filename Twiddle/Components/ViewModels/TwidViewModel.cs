using System.ComponentModel.DataAnnotations;

namespace Twiddle.Components.ViewModels;

public class TwidViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "UserId is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Text is required")]
    [MaxLength(1024, ErrorMessage = "Text cannot exceed 1024 characters")]
    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}