using System.Collections.Generic;
using System.Threading.Tasks;
using hourglass.Data;
using hourglass.Models;
using hourglass.Models.InfoModels;
using Microsoft.EntityFrameworkCore;

namespace hourglass.Services;

public class MediaService(AppDbContext dbContext) : IMediaService
{
    public async Task<List<MediaItem>> GetAllMediaItemsAsync()
    {
        return await dbContext.MediaItem.Include(x => x.Genres).ToListAsync();
    }

    public async Task AddItemAsync(MediaItem item)
    {
        dbContext.MediaItem.Add(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveItemAsync(MediaItem item)
    {
        dbContext.MediaItem.Remove(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(MediaItem item)
    {
        dbContext.MediaItem.Update(item);
        await dbContext.SaveChangesAsync();
    }
}