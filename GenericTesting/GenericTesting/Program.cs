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
            StringBoxingAndUnboxingToADictionary boxer = new StringBoxingAndUnboxingToADictionary();
            var str = boxer.ReturnAStringFromADictionary(boxer.DictionaryBoxing);

            //var items = strToWorkWith.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            Console.ReadLine();
        }
    }
}
