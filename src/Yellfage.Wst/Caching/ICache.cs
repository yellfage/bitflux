using System.Threading.Tasks;

namespace Yellfage.Wst.Caching
{
    public interface ICache
    {
        Task<TValue> GetAsync<TValue>(object key);
        Task<TValue?> FindAsync<TValue>(object key);
        Task SetAsync(object key, object value);
        Task RemoveAsync(object key);
        Task<bool> ContainsAsync(object key);
    }
}
