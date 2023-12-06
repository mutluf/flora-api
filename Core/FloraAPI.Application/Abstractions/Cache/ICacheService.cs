namespace FloraAPI.Application.Abstractions.Cache
{
    public interface ICacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> method) where T: class;
        Task ClearAsync(string key);
        void ClearAll();
    }
}
