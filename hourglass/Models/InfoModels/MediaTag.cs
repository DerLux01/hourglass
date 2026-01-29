using hourglass.Models.InfoModelBases;

namespace hourglass.Models.InfoModels;

public class MediaTag
{
    public int MediaItemId { get; set; }
    public MediaItem MediaItem { get; set; } = null!;
    
    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}