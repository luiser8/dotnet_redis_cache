using Newtonsoft.Json;
using StackExchange.Redis;

namespace NetCoreWithRedis.Services.Redis;

public class RedisService : IRedisService
{
    private readonly IDatabase _cache;

    public RedisService()
    {
        var redis = ConnectionMultiplexer.Connect("localhost:6379");
        _cache = redis.GetDatabase();
    }

    public async Task<List<T>?> GetData<T>(string key)
    {
        var redisList = await _cache.StringGetAsync(key);

        if (!string.IsNullOrEmpty(redisList))
        {
            return JsonConvert.DeserializeObject<List<T>>(redisList);
        }
        return default;
    }

    public async Task<bool> SetData<T>(string key, List<T> value, DateTimeOffset dateTimeOffset)
    {
        var expirtyTime = dateTimeOffset.DateTime.Subtract(DateTime.Now);
        return await _cache.StringSetAsync(key, JsonConvert.SerializeObject(value), expirtyTime);
    }

    public async Task RemoveData(string key)
    {
        var _isKeyExist = await _cache.KeyExistsAsync(key);
        if (_isKeyExist)
        {
            await _cache.KeyDeleteAsync(key);
        }
    }
}
