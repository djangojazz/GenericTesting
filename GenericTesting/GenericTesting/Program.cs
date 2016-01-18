using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericTesting
{
  class Program
  {
    static List<POCO> GetPOCOs()
    {
      return new List<POCO>
      {
          new POCO { Id = 1, Name = "John", Description = "basic" },
          new POCO { Id = 2, Name = "Jane", Description = "more" },
          new POCO { Id = 3, Name = "Joey", Description = "advanced" }
      };
    }
    
    public class Poc { public int Id { get; set; } public string Value { get; set; }}

    static void Main(string[] args)
    {
      var pocs = new List<Poc>
      {
        new Poc { Id = 1, Value = "A" },
        new Poc { Id = 2, Value = "B" },
        new Poc { Id = 3, Value = "C" },
      };

      pocs.ForEach(x => Console.WriteLine($"{x.Id} {x.Value}"));

      //new Lambdas.LambdaEvents().DoIt();

      Console.ReadLine();
    }
  }
}
