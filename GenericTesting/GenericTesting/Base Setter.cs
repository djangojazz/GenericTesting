using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public abstract class Base_Setter
  {
    public Base_Setter() { }

    public Base_Setter(string overrideValue)
    {
      foreach (var property in GetType().GetProperties())
      {
        var p = property.PropertyType;

        if(property.PropertyType == typeof(string))
        {
          property.SetValue(this, overrideValue);
        }
      }
    }
  }
}
