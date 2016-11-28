using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  public static class StringExtensions
  {
    public static TEnum ParseEnum<TEnum>(this string value) where TEnum : struct
    {
      return (TEnum)Enum.Parse(typeof(TEnum), value);
    }
  }
}
