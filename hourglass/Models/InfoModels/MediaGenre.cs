using hourglass.Models.InfoModelBases;

namespace hourglass.Models.InfoModels;

public class MediaGenre
{
    public int MediaItemId { get; init; }
    public MediaItem MediaItem { get; set; } = null!;
    
    public int GenreId { get; init; }
    public Genre Genre { get; set; } = null!;
}