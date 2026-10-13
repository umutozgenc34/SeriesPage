using Microsoft.Extensions.Caching.Distributed;
using SeriesPage.Model.Episodes.Entites;
using SeriesPage.Repository.Episodes.Abstracts;
using System.Linq.Expressions;
using System.Text.Json;

namespace SeriesPage.Repository.Episodes.Concretes;

public class EpisodeRepositoryWithCache(IEpisodeRepository innerRepository, IDistributedCache distributedCache) : IEpisodeRepository
{
    private const string CacheKeyPrefix = "episode_";
    private const string AllEpisodesCacheKey = $"{CacheKeyPrefix}all_episodes";

    public async Task<List<Episode>> GetAllAsync()
    {
        var cachedData = await distributedCache.GetStringAsync(AllEpisodesCacheKey);
        if (cachedData is not null)
            return JsonSerializer.Deserialize<List<Episode>>(cachedData)!;

        var episodes = await innerRepository.GetAllAsync();

        await distributedCache.SetStringAsync(AllEpisodesCacheKey, JsonSerializer.Serialize(episodes), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        });

        return episodes;
    }

    public async Task<Episode?> GetByIdAsync(int id)
    {
        var cacheKey = GetCacheKey(id);

        var cachedData = await distributedCache.GetStringAsync(cacheKey);
        if (cachedData is not null)
            return JsonSerializer.Deserialize<Episode>(cachedData);

        var episode = await innerRepository.GetByIdAsync(id);

        if (episode is not null)
        {
            await distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(episode), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }

        return episode;
    }

    public IQueryable<Episode> Where(Expression<Func<Episode, bool>>? predicate = null) => innerRepository.Where(predicate);

    public async Task AddAsync(Episode entity)
    {
        await innerRepository.AddAsync(entity);
        await distributedCache.RemoveAsync(AllEpisodesCacheKey);
    }

    public void Update(Episode entity)
    {
        innerRepository.Update(entity);
        InvalidateCache(entity.Id);
    }

    public void Delete(Episode entity)
    {
        innerRepository.Delete(entity);
        InvalidateCache(entity.Id);
    }

    private void InvalidateCache(int id)
    {
        distributedCache.Remove(GetCacheKey(id));
        distributedCache.Remove(AllEpisodesCacheKey);
    }

    private static string GetCacheKey(int id) => $"{CacheKeyPrefix}{id}";
}
