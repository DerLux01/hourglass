using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hourglass.Models.Enums;
using hourglass.Models.Interfaces;

namespace hourglass.Models.InfoModels;

public abstract class MediaItem : IMediaItem
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(128)]
    public string Title { get; set; } =  string.Empty;
    
    public MediaType Type { get; set; }
    public MediaStatus Status { get; set; }
    
    public int CurrentProgress { get; set; }
    public int TotalDurationOrPages { get; set; }
    
    public int? Rating { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    
    public List<MediaGenre> Genres { get; set; }
    public List<MediaTag> Tags { get; set; }
}