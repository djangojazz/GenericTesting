using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core22Test
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal sealed class DynamicOrStaticDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var validTypes = new List<string> { "@90DaysPrior", "@30DaysPrior", "@Now" };
            return validTypes.Contains(value.ToString());
        }
    }
}
