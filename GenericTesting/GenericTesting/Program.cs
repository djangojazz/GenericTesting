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
using GenericTesting.Business;

namespace GenericTesting
{   
  public class POC
  {
    public string Name { get; set; }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var current = DateTime.Now.Date;

      var demandTrend = new DemandTrendInput(111, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 1, 2, 3 });
      var demandTrend2 = new DemandTrendInput(222, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 4, 5, 6 });

      var person = new Person("Brett");
      var person2 = new Person("Mark");

      var d = new SerializableDictionary<string, Person> { { "A", person }, { "B", person2 } };
      var test = d.SerializeToXml();
      var d2 = new SerializableDictionary<string, DemandTrendInput>{ {"A", demandTrend }, {"B", demandTrend2} };

      var test2 = d2.SerializeToXml();
      var items = test2.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();      

      Console.ReadLine();
    }
  }

}
