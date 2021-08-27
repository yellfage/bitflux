namespace Yellfage.Wst.Caching
{
    public interface ICacheConverter
    {
        object Serialize(object value);
        TValue? Deserialize<TValue>(object value);
    }
}
