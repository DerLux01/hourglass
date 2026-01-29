using hourglass.Models.InfoModels;

namespace hourglass.Models.ItemModels;

public class Book : MediaItem
{
    public int? WordCount { get; set; }
    public int? PageCount { get; set; }
}