using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hourglass.Models.InfoModels;

namespace hourglass.Models.InfoModelBases;

public class Genre
{
    public int Id { get; init; }
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public List<MediaGenre> MediaGenres { get; set; } = [];
}