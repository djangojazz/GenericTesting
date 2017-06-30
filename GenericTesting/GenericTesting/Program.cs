using System;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace GenericTesting
{
  [Serializable]
  public class Test
  {
    public int Id { get; set; }
    public string BadThing { get; set; }
  }

  [Serializable]
  public class POC : BasePOC
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public POC() { }

    public POC(int id, string name)
    {
      Id = id;
      Name = name;
    }
  }

  [Serializable]
  public class BasePOC
  {
    public int BaseId { get; set; }
    public int BaseDesc { get; set; }
  }

  [Serializable]
  public class POC2
  {
    public int Id2 { get; set; }
    public string Name2 { get; set; }
    public string Extra { get; set; }

    public POC2() { }
    public POC2(int id, string name, string extra)
    {
      Id2 = id;
      Name2 = name;
      Extra = extra;
    }
  }

  [Serializable]
  public class Holdr
  {
    public int Id { get; set; }
    public List<POC> POCs { get; set; } = new List<POC>();
  }

  class Program
  {
    static void Main(string[] args)
    {
      var p = new POC(1, "Brett");
      var ls = new Holdr();
      ls.POCs.Add(p);
      var xDoc = XDocument.Parse(ls.SerializeToXml());
      var item = xDoc.Descendants("POC").Descendants("Id").First().Value;
      Console.WriteLine(item);

      //var demandTrend = new DemandTrendInput("1", 111, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 1, 2, 3 });
      //var demandTrend2 = new DemandTrendInput("2", 222, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 4, 5, 6 });

      //var d = new SerializableDictionary<string, DemandTrendInput> { { "1", demandTrend }, { "2", demandTrend2 } };

      //var serialized = d.SerializeToXml();
      //var deserialized = serialized.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();
      ////var vals = deserialized.ToList();
      ////var data = new List<DemandTrendInput>();

      //foreach (var item in deserialized.ToList())
      //{
      //  item.Value.DemandTrendName = item.Key;
      //  //data.Add(new DemandTrendInput(item.Key, item.Value.FIKey, item.Value.StartDate, item.Value.EndDate, (TrendChoices)Enum.Parse(typeof(TrendChoices), item.Value.Grouping), item.Value.DemandLocations));
      //}

      //deserialized.Values.ToList().ForEach(x => Console.WriteLine($"{x.DemandTrendName} {x.StartDate} {x.EndDate}"));

      //var change = serialized.Substring(1, 200);

      //serialized.SaveXMLToAppResources(4, 1, 2, 744);

      //var sqlTalker = new SQLTalker("DEV-ENTERPRISE", "AppResources", "sqluser", "pa55word");
      //var data = sqlTalker.GetData("EXEC dbo.AppXmlRecords_Select");

      //var items = serialized.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();      

      Console.ReadLine();
    }
  }
}
