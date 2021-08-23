using System.Threading.Tasks;

namespace Yellfage.Wst.Caching
{
    public interface ICache
    {
        Task<byte[]> GetAsync(string key);
        Task<string> GetStringAsync(string key);
        Task<byte[]?> FindAsync(string key);
        Task<string?> FindStringAsync(string key);
        Task SetAsync(string key, byte[] value);
        Task SetStringAsync(string key, string value);
        Task RemoveAsync(string key);
        Task<bool> ContainsAsync(string key);
    }
}
