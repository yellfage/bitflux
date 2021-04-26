using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal static class IListExtensions
    {
        public static void RemoveRange<T>(this IList<T> list, int index)
        {
            RemoveRange(list, index, list.Count - index);
        }

        public static void RemoveRange<T>(this IList<T> list, int index, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.RemoveAt(index);
            }
        }
    }
}
