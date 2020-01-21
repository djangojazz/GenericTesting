using System;
using System.Collections.Generic;
using System.Text;

namespace Core22Test
{
    public sealed class POCO
    {
        public int Id { get; set; }
        [DynamicOrStaticDate]
        public string Date { get; set; }
        [DynamicOrStaticDate]
        public string Date2 { get; set; }
    }
}
