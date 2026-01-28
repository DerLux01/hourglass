using System.Collections.Generic;
using System.Threading.Tasks;
using hourglass.Models;

namespace hourglass.Services;

public interface IMediaService
{
    Task<List<MediaItem>> GetAllMediaItemsAsync();
    Task AddItemAsync(MediaItem item);
    Task RemoveItemAsync(MediaItem item);
    Task UpdateItemAsync(MediaItem item);
}