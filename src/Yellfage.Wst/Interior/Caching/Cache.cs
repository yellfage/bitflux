using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal abstract class Cache : ICache
    {
        protected IDictionary<string, byte[]> Dictionary { get; }

        public Cache()
        {
            Dictionary = new ConcurrentDictionary<string, byte[]>();
        }

        public async Task<byte[]> GetAsync(string key)
        {
            return Dictionary[key];
        }

        public async Task<string> GetStringAsync(string key)
        {
            return Encoding.UTF8.GetString(await GetAsync(key));
        }

        public async Task<byte[]?> FindAsync(string key)
        {
            if (Dictionary.TryGetValue(key, out byte[]? value))
            {
                return value;
            }

            return default;
        }

        public async Task<string?> FindStringAsync(string key)
        {
            byte[]? value = await FindAsync(key);

            if (value is null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(value);
        }

        public async Task SetAsync(string key, byte[] value)
        {
            Dictionary[key] = value;
        }

        public async Task SetStringAsync(string key, string value)
        {
            await SetAsync(key, Encoding.UTF8.GetBytes(value));
        }

        public async Task RemoveAsync(string key)
        {
            Dictionary.Remove(key);
        }

        public async Task<bool> ContainsAsync(string key)
        {
            return Dictionary.ContainsKey(key);
        }
    }
}
