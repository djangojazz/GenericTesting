using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Text;
using static GenericTesting.HackerRankChallenges.Algorithms;

namespace GenericTesting
{
  
  class Program
  {
    
    static void Main(string[] args)
    {
      var groups = new Dictionary<string, int> { { "A", 10 }, { "B", 12 }, { "C", 13 }, { "D", 9 } };
      var topThreeGroups = groups.OrderByDescending(x => x.Value).Take(3).ToList();
      
      Console.ReadLine();
    }
  }
  
}
