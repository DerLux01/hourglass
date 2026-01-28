using System.Collections.Generic;
using System.Threading.Tasks;
using hourglass.Data;
using hourglass.Models;
using Microsoft.EntityFrameworkCore;

namespace hourglass.Services;

public class MediaService : IMediaService
{
    private readonly AppDbContext _dbContext;
    
    public MediaService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<MediaItem>> GetAllMediaItemsAsync()
    {
        return await _dbContext.MediaItem.Include(x => x.Genres).ToListAsync();
    }

    public async Task AddItemAsync(MediaItem item)
    {
        _dbContext.MediaItem.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveItemAsync(MediaItem item)
    {
        _dbContext.MediaItem.Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(MediaItem item)
    {
        _dbContext.MediaItem.Update(item);
        await _dbContext.SaveChangesAsync();
    }
}