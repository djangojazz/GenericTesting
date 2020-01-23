using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core22Test
{
    class Program
    {
        private static async Task DoIt(int id)
        {
            Console.WriteLine($"Id {id.ToString()}");
            await Task.Factory.StartNew(() => Thread.Sleep(800));
        }

        static void Main(string[] args)
        {
            var listings = Enumerable.Range(1, 64).ToList();

            //listings.ForEach(DoIt);
            var partitionSize = listings.Count() / 8;
            listings.ToList().PartitionList(partitionSize >= 1 ? partitionSize : 1).ToList().ForEach(x =>
            {
                Parallel.ForEach(x, async y =>
                {
                    await DoIt(y);
                });

                Console.WriteLine("Done Series");
            });

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
