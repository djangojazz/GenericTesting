using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorCreator
{
    public static class ReflectorConverter
    {
        public static TOut Converter<TIn, TOut>(TIn input) where TIn : class where TOut : class, new()
        {
            var output = new TOut();
            var propertiesIn = input.GetType().GetProperties().ToList();
            var propertiesOut = output.GetType().GetProperties().ToList();
            foreach (var prop in propertiesIn)
            {
                var match = propertiesOut.SingleOrDefault(x => x?.Name == prop?.Name && x?.PropertyType == prop?.PropertyType);
                if (match != null)
                    match.SetValue(output, GetPropValue(input, prop.Name));
            }

            return output;
        }

        private static object GetPropValue(object src, string propName) => src.GetType().GetProperty(propName).GetValue(src, null);
    }
}
