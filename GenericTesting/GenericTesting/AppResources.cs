using GenericTesting.Business;
using GenericTesting.DataAccess;
using GenericTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTesting
{
  public static class AppResources
  {
    private static void AppResourcesSavingExample()
    {
      var current = DateTime.Now.Date;

      var demandTrend = new DemandTrendInput("1", 111, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 1, 2, 3 });
      var demandTrend2 = new DemandTrendInput("2", 222, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 4, 5, 6 });

      var d = new SerializableDictionary<string, DemandTrendInput> { { "1", demandTrend }, { "2", demandTrend2 } };

      var serialized = d.SerializeToXml();
      var deserialized = serialized.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();
      //var vals = deserialized.ToList();
      //var data = new List<DemandTrendInput>();

      foreach (var item in deserialized.ToList())
      {
        item.Value.DemandTrendName = item.Key;
        //data.Add(new DemandTrendInput(item.Key, item.Value.FIKey, item.Value.StartDate, item.Value.EndDate, (TrendChoices)Enum.Parse(typeof(TrendChoices), item.Value.Grouping), item.Value.DemandLocations));
      }

      deserialized.Values.ToList().ForEach(x => Console.WriteLine($"{x.DemandTrendName} {x.StartDate} {x.EndDate}"));

      var change = serialized.Substring(1, 200);

      serialized.SaveXMLToAppResources(4, 1, 2, 744);

      var sqlTalker = new SQLTalker("DEV-ENTERPRISE", "AppResources", "sqluser", "pa55word");
      var data = sqlTalker.GetData("EXEC dbo.AppXmlRecords_Select");

      var items = serialized.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();
    }
  }
}
