using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    class Program
    {
        public class Thing
        {
            // THis was me
            public string Name { get; set; }
            public string Code { get; set; }
        }

        public static List<Thing> CreateThings()
        {
            return new List<Thing>
            {
                new Thing { Name = "First", Code = "1" },
                new Thing { Name = "Second", Code = "24" },
                new Thing { Name = "Third", Code = "30" },
                new Thing { Name = "Fourth", Code = "98" },
            };
        }

        static void Main(string[] args)
        {
            var things = CreateThings();
            string s = "";

            var first = things.Where(x => (new string[] { "1", "30" }).Contains(x.Code)).Select(x => new KeyValuePair<int, Thing>(1, x)).ToList();
            var second = things.Where(x => !(new string[] { "1", "30" }).Contains(x.Code)).Select(x => new KeyValuePair<int, Thing>(2, x)).ToList();

            var combined = first.Union(second);

            combined
                .OrderByDescending(x => x.Key)
                .ThenByDescending(x => x.Value.Code)
                .ToList()
                .ForEach(x => s += "Key: " + x.Key + "\tName: " + x.Value.Name + "\tCode: " + x.Value.Code + Environment.NewLine);

            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
