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
using GenericTesting.DataAccess;

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
                    
      var d = new SerializableDictionary<string, DemandTrendInput>{ {"A", demandTrend }, {"B", demandTrend2} };

      var serialized = d.SerializeToXml();
      serialized.SaveXMLToAppResources(4, 1, 2, 744);

      var sqlTalker = new SQLTalker("DEV-ENTERPRISE", "AppResources", "sqluser", "pa55word");
      var data = sqlTalker.GetData("EXEC dbo.AppXmlRecords_Select");

      //var items = serialized.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();      

      Console.ReadLine();
    }
  }                                                                  
}
