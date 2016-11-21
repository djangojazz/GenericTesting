using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  public static class BufferExtensions
  {
    public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
    {
      var converter = TypeDescriptor.GetConverter(typeof(T));
      foreach (var item in buffer)
      {
        TOutput result = (TOutput)converter.ConvertTo(item, typeof(TOutput));
        yield return result;
      }
    }

    public static void Dump<T>(this IBuffer<T> buffer)
    {
      foreach (var item in buffer)
      {
        Console.WriteLine(item);
      }
    }
  }
}
