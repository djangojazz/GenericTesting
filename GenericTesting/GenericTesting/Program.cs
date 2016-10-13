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
      int n = 5;
      var ls = new int[]{ 3, 9, 2, 15, 3 };

      GiveResultNonDegenerateTriangles(ls.ToList());

      Console.ReadLine();
    }
  }
  
}
