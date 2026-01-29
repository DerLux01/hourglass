using hourglass.Models.InfoModelBases;

namespace hourglass.Models.InfoModels;

public class MediaTag
{
    public int MediaItemId { get; init; }
    public MediaItem MediaItem { get; set; } = null!;
    
    public int TagId { get; init; }
    public Tag Tag { get; set; } = null!;
}