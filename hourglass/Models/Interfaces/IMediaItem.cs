using System;
using System.Collections.Generic;
using hourglass.Models.Enums;
using hourglass.Models.InfoModels;

namespace hourglass.Models.Interfaces;

public interface IMediaItem
{
    int Id { get; }
    string Title { get; set; }
    MediaType Type { get; set; }
    MediaStatus Status { get; set; }
    int CurrentProgress { get; set; }
    int TotalDurationOrPages { get; set; }
    int? Rating { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
    DateTime? FinishedAt { get; set; }
    List<MediaGenre> Genres { get; set; }
    List<MediaTag> Tags { get; set; }
}