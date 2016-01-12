using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        
    static void Main(string[] args)
    {
      var bd = new JoesChallenge();

      bd.ReturnData();

      Console.ReadLine();
    }
  }
}
