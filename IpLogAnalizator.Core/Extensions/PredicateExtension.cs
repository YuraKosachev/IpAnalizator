namespace IpLogAnalizator.Core.Extensions
{
    public static class PredicateExtension
    {
        public static Func<T, bool> And<T>(this Func<T, bool> src, Func<T, bool> target)
        {
            return delegate (T item)
            {
                return src(item) && target(item);
            };
        }

        public static Func<T, bool> Or<T>(this Func<T, bool> src, Func<T, bool> target)
        {
            return delegate (T item)
            {
                return src(item) || target(item);
            };
        }
    }
}