using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public static class ListAdditions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var i in source)
            {
                action(i);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int index = 0;
            foreach (var i in source)
            {
                action(i, index++);
            }
        }
    }
}
