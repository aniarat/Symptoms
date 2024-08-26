using Microsoft.Extensions.Caching.Memory;

namespace Symptoms.Api.Infrastructure
{
    public class CacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetOrSet<T>(string cacheKey, Func<T> getData, TimeSpan cacheDuration)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out T cacheEntry))
            {
                cacheEntry = getData();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(cacheDuration);

                _memoryCache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
