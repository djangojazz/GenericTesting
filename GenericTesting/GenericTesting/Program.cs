using System;
using System.Xml.Serialization;
using System.Xml;

namespace GenericTesting
{
  [Serializable]
  public class Test<TypeOfDefinition>
  {
    public int Id { get; set; }
    public TypeOfDefinition Thing { get; set; }
  }
  
  [Serializable]
  public class POC
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
  
  class Program
  {

    static void Main(string[] args)
    {
      var poc1 = new POC(1, "Brett");
      var poc2 = new POC2(2, "Mark", "More Stuff");

      var s1 = poc1.SerializeToXml();
      var s2 = poc2.SerializeToXml();

      //synthesizing a serialization
      Console.WriteLine($"{s1}{Environment.NewLine}{s2}");

      //problem area is when a serialization is inside another serialization
      var choice = poc1;
      string s = string.Empty;
      
      Console.WriteLine(choice.DynamicSerializer());

      
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
