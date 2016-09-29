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
      var time = "07:05:45PM";

      Console.WriteLine(DateTime.Parse(time).ToString("HH:mm:ss"));

      Console.ReadLine();
    }
  }
  
}
