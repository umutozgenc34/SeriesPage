using Microsoft.Extensions.Caching.Distributed;
using SeriesPage.Model.Episodes.Entites;
using SeriesPage.Repository.Episodes.Abstracts;
using System.Linq.Expressions;
using System.Text.Json;

namespace SeriesPage.Repository.Episodes.Concretes;

public class EpisodeRepositoryWithCache : IEpisodeRepository
{
    private readonly IEpisodeRepository _innerRepository;
    private readonly IDistributedCache _distributedCache;
    private const string CacheKeyPrefix = "episode_";

    public EpisodeRepositoryWithCache(IEpisodeRepository innerRepository, IDistributedCache distributedCache)
    {
        _innerRepository = innerRepository;
        _distributedCache = distributedCache;
    }

    public async Task<List<Episode>> GetAllAsync()
    {
        var cacheKey = $"{CacheKeyPrefix}all_episodes";

        var cachedData = await _distributedCache.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            var cachedEpisodes = JsonSerializer.Deserialize<List<Episode>>(cachedData);
            return cachedEpisodes!;
        }

        var episodes = await _innerRepository.GetAllAsync();

        await _distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(episodes), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        });

        return episodes;
    }

    public async Task<Episode?> GetByIdAsync(int id) 
    {
        var cacheKey = $"{CacheKeyPrefix}{id}";

        var cachedData = await _distributedCache.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            return JsonSerializer.Deserialize<Episode>(cachedData);
        }

        var episode = await _innerRepository.GetByIdAsync(id);

        if (episode != null)
        {
            await _distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(episode), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }
        return episode;
    }

    public IQueryable<Episode> Where(Expression<Func<Episode, bool>>? predicate = null)
    {
        return _innerRepository.Where(predicate);
    }

    public async Task AddAsync(Episode entity) 
    {
        await _innerRepository.AddAsync(entity);
        await _distributedCache.RemoveAsync($"{CacheKeyPrefix}{entity.Id}");
        await _distributedCache.RemoveAsync($"{CacheKeyPrefix}all_episodes");
    }

    public void Update(Episode entity)
    {
        _innerRepository.Update(entity);
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}{entity.Id}");
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}all_episodes");
    }

    public void Delete(Episode entity)
    {
        _innerRepository.Delete(entity);
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}{entity.Id}");
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}all_episodes");
    }
}