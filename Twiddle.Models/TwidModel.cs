﻿namespace Twiddle.Models;

public class TwidModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; } 

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}