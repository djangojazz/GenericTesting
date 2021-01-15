using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConstructorCreator
{
    public class POCO
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }

        public POCO() { }
        public POCO(int id, string desc, DateTime date) => (Id, Desc, Date) = (id, desc, date);
    }

    public class POCO2
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }

        public POCO2() { }
        public POCO2(int id, string desc) => (Id, Desc) = (id, desc);

        public override string ToString() => $"{Id} {Desc} {Date}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Make or check directory
            //var target = DirectoryHelper.MakeOrCreateDirectory(@"C:\Temp");
            var item = new POCO(1, "Abc", DateTime.Now);
            var item2 = new POCO(2, "Def", DateTime.Now.AddDays(2));
            var items = new List<POCO> { item, item2 };
            items.Select(x => ReflectorConverter.Converter<POCO, POCO2>(x)).ToList().ForEach(Console.WriteLine);

            //var output = ReflectorConverter.Converter<POCO, POCO2>(item);
            //Console.WriteLine(output);
        }
    }
}
