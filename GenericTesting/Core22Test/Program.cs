using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core22Test
{
    class Program
    {
        private static async Task DoIt(int id) => Console.WriteLine($"Id {id.ToString()}");

        public class POCO
        {
            public int Id { get; set; }
            public int Id2 { get; set; }
            public int Id3 { get; set; }
            public string Desc { get; set; }
        }

        public class POCO2
        {
            public int Id { get; set; }
            public int Id2 { get; set; }
            public int Id3 { get; set; }
            public string SomethingElse { get; set; }
        }


        static void Main(string[] args)
        {
            var listingsPoco = new List<POCO>
            {
                new POCO { Id = 1, Id2 = 1, Id3 = 1, Desc = "A"},
                new POCO { Id = 1, Id2 = 2, Id3 = 1, Desc = "B"},
                new POCO { Id = 1, Id2 = 2, Id3 = 2, Desc = "C"}
            };

            var listingsPoco2 = new List<POCO2>
            {
                new POCO2 { Id = 1, Id2 = 2, Id3 = 2, SomethingElse = "C"}
            };

            var toFind = listingsPoco2.Select(x => new { x.Id, x.Id2, x.Id3 }).ToList();
            var found = listingsPoco.Where(x => toFind.Contains(new { x.Id, x.Id2, x.Id3 })).ToList();

            found.ForEach(x => Console.WriteLine($"{x.Id} {x.Id2} {x.Id3}"));

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
