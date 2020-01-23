using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core22Test
{
    public static class GenericExtensions
    {
        public static IList<IList<T>> PartitionList<T>(this IList<T> source, int size = 1000)
        {
            var d = new List<IList<T>>();

            for (int i = 0; i < Math.Ceiling(source.Count / (double)size); i++)
                d.Add(source.Skip(size * i).Take(size).ToList());

            return d;
        }
    }
}
