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
using EntityTesting;
using GenericTesting.Models;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace GenericTesting
{   
  class Program
  {
    static void Main(string[] args)
    {
      var current = DateTime.Now.Date;

      var demandTrend = new DemandTrendInput(111, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 1, 2, 3 });
      var demandTrend2 = new DemandTrendInput(222, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 4, 5, 6 });

      var person = new Person("Brett");
      var serialized = person.SerializeToXml();
      var container = new SerializeContainer<Person>("Test", person);
      var serialized2 = container.SerializeToXml();
      
      //var demandTrends = new List<DemandTrendInput> { demandTrend, demandTrend2 };
                                           
      //Console.WriteLine(serialized);

      Console.ReadLine();
    }
  }

}
