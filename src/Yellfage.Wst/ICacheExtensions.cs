using System.Threading.Tasks;
using Newtonsoft.Json;

using Yellfage.Wst.Caching;

namespace Yellfage.Wst
{
    public static class ICacheExtensions
    {
        public static async Task<TValue> GetFromJsonAsync<TValue>(
            this ICache cache,
            string key)
        {
            return JsonConvert.DeserializeObject<TValue>(await cache.GetStringAsync(key))!;
        }

        public static async Task<TValue?> FindFromJsonAsync<TValue>(
            this ICache cache,
            string key)
        {
            string? value = await cache.FindStringAsync(key);

            if (value is null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<TValue>(value);
        }

        public static async Task SetJsonAsync(
            this ICache cache,
            string key,
            object value)
        {
            await cache.SetStringAsync(key, JsonConvert.SerializeObject(value));
        }
    }
}
