namespace NetCoreWithRedis.Services.Redis;

public interface IRedisService
{
    Task<List<T>> GetData<T>(string key);
    Task<bool> SetData<T>(string key, List<T> value);
    Task RemoveData(string key);
}