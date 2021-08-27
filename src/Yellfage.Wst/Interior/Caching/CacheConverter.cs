using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class CacheConverter : IHubCacheConverter, IClientCacheConverter
    {
        public TValue? Deserialize<TValue>(object value)
        {
            return (TValue)value;
        }

        public object Serialize(object value)
        {
            return value;
        }
    }
}
