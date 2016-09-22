﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public static class CartesianHelper
  {
    public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
    {
      IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
      return sequences.Aggregate(
          emptyProduct,
          (accumulator, sequence) =>
              from accseq in accumulator
              from item in sequence
              select accseq.Concat(new[] { item })
          );
    }
  }
}
