using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Caching
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _distributedCacheEntryOptions;
        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _distributedCacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };
            
        }

        public async Task<string> getAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task setAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value, _distributedCacheEntryOptions);
        }
    }
}
