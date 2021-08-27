using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal abstract class Cache : ICache
    {
        protected IDictionary<object, object> Dictionary { get; }

        private ICacheConverter CacheConverter { get; }

        public Cache(ICacheConverter cacheConverter)
        {
            Dictionary = new ConcurrentDictionary<object, object>();
            CacheConverter = cacheConverter;
        }

        public async Task<TValue> GetAsync<TValue>(object key)
        {
            return CacheConverter.Deserialize<TValue>(Dictionary[key])!;
        }

        public async Task<TValue?> FindAsync<TValue>(object key)
        {
            if (Dictionary.TryGetValue(key, out object? value))
            {
                return CacheConverter.Deserialize<TValue>(value);
            }

            return default;
        }

        public async Task SetAsync(object key, object value)
        {
            Dictionary[key] = CacheConverter.Serialize(value);
        }

        public async Task RemoveAsync(object key)
        {
            Dictionary.Remove(key);
        }

        public async Task<bool> ContainsAsync(object key)
        {
            return Dictionary.ContainsKey(key);
        }
    }
}
