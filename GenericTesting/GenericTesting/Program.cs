using System;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace GenericTesting
{
  [Serializable]
  public class BasePOC
  {
    public virtual int BaseId { get; set; }
    public virtual bool ShouldSerializeBaseId() => true;
  }

  [Serializable]
  public class POC : BasePOC
  {
    public int Id { get; set; }
    public override bool ShouldSerializeBaseId() => false;

    public POC() { }

    public POC(int id)
    {
      Id = id;
    }
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      var p = new POC(1);
      var xml = XElement.Parse(p.SerializeToXml());
      //xml.Elements("Id").Remove();
      //var item = xDoc.Descendants("POC").Descendants("Id").First().Value;
      Console.WriteLine(xml);

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
