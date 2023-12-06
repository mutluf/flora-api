using FloraAPI.Application.Abstractions.Cache;
using StackExchange.Redis;
using System.Text.Json;

namespace FloraAPI.Persistence.Services
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redisCon;
        private readonly IDatabase _cache;

        public CacheService(IConnectionMultiplexer redisCon)
        {
            _redisCon = redisCon;
            _cache = redisCon.GetDatabase();
        }

        public void ClearAll()
        {
            var endpoints = _redisCon.GetEndPoints(true);

            foreach (var endpoint in endpoints)
            {
                var server = _redisCon.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }

        public async Task ClearAsync(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> method) where T : class
        {
            var result = await _cache.StringGetAsync(key);

            if (result.IsNull)
            {
                result = JsonSerializer.SerializeToUtf8Bytes(await method());
                await _cache.StringSetAsync(key, result);
            }


            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _cache.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _cache.StringSetAsync(key, value);
        }
    }
}
