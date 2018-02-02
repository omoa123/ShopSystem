using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSystem.Utils
{
    public static class StringExtension
    {
        public static int? TryParseInt(this string str)
        {
            try
            {
                var value = int.Parse(str);
                return value;
            }
            catch
            {
                return null;
            }
        }
        
    }
    public static class IEnumerablExtension
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
       
}