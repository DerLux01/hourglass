using hourglass.Models.InfoModels;

namespace hourglass.Models.ItemModels;

public class Book : MediaItem
{
    public int? WordCount { get; init; }
    public int? PageCount { get; set; }
}