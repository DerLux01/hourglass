using System.Collections.Generic;

namespace hourglass.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<MediaGenre> MediaGenres { get; set; } = [];
}