namespace Restaurant.Auth.Core.Extensions
{
    public static class IEnumerableExtension
    {
        public static bool Contains<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
