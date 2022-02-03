using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yellfage.Bitflux.Caching;

namespace Yellfage.Bitflux.Interior.Caching
{
    internal abstract class Cache : ICache
    {
        private IDictionary<object, object> Dictionary { get; } = new ConcurrentDictionary<object, object>();

        public async Task<TValue> GetAsync<TValue>(object key)
        {
            return (TValue)Dictionary[key];
        }

        public async Task<TValue?> FindAsync<TValue>(object key)
        {
            if (Dictionary.TryGetValue(key, out object? value))
            {
                return (TValue)value;
            }

            return default;
        }

        public async Task SetAsync(object key, object value)
        {
            Dictionary[key] = value;
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
