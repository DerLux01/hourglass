using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hourglass.Models;

public class MediaItem
{
    [Key]
    public int Id { get; init; }

    [Required] public string Title { get; set; } =  string.Empty;
    
    public MediaType Type { get; init; }
    public MediaStatus Status { get; set; }
    
    public int CurrentProgress { get; set; }
    public int TotalDurationOrPages { get; set; }
    
    public int? Rating { get; set; }
    
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    
    public List<MediaGenre>? Genres { get; set; }
}