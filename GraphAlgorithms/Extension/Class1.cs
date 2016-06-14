using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class Class1
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source,
     Action<TSource> action)
        {
            foreach (TSource item in source)
                action(item);

            return source;
        }

        // Foreach with index
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source,
            Action<TSource, int> action)
        {
            int index = 0;
            foreach (TSource item in source)
                action(item, index++);

            return source;
        }
    }
}
