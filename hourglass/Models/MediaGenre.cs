namespace hourglass.Models;

public class MediaGenre
{
    public int MediaItemId { get; set; }
    public MediaItem MediaItem { get; set; } = null!;
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
}