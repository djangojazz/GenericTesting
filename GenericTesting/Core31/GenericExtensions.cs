using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core31
{
    public static class GenericExtensions
    {
        public static bool ListCheck<T>(this IEnumerable<T> l1, IEnumerable<T> l2) => l1.Intersect(l2).Count() != l1.Count();
    }
}
