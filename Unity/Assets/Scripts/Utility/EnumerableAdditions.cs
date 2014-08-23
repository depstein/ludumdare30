using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public static class EnumerableAdditions
    {
        public static IEnumerable<T> RandomItems<T>(this IEnumerable<T> items, Random random, int count)
        {
            return ShuffleIterator(items, random).Take(count);
        }

        public static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();

            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

    }
}