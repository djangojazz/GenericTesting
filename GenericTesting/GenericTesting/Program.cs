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
using Controls.Charting;
using GenericTesting.DataAccess.Enterprise;
using System.Collections;
using System.Xml.Linq;

namespace GenericTesting
{
  [Serializable]
  public class POC
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public POC() {}

    public POC(int id, string name)
    {
      Id = id;
      Name = name;
    }
  }

  [Serializable]
  public class POC2
  {
    [XmlElement("ID")]
    public int Id { get; set; }
    public string Name { get; set; }

    public POC2() { }
    public POC2(int id, string name)
    {
      Id = id;
      Name = name;
    }
  }

  public class ChildPOC
  {
    public int ParentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ChildPOC(int parentId, string firstName, string lastName)
    {
      ParentId = parentId;
      FirstName = firstName;
      LastName = lastName;
    }
  }
  public class ChildPOCAlter
  {
    public int ParentId { get; set; }
    public string Name { get; set; }

    public ChildPOCAlter(string first, string last, int parentId)
    {
      ParentId = parentId;
      Name = $"{first} {last}";
    }
  }
  

  class Program
  {
    //public static Converter<ChildPOC, ChildPOCAlter> ChildPOCOAlter()
    //{
    //  return new Converter<ChildPOC, ChildPOCAlter>((x) => { return new ChildPOCAlter(x.FirstName, x.LastName, x.ParentId); });
    //}
    
    static bool?[] ReturnIt(string input)
    {
      bool?[] aBool = new bool?[8];

      for (int i = 0; i <= input.Length - 1; i++)
      {
        switch (input[i])
        {
          case '0':
            aBool[i] = false;
            break;

          case '1':
            aBool[i] = true;
            break;

          case '.':
            aBool[i] = null;
            break;

          default:
            break;
        }

      }
      return aBool;
    }

    static void Main(string[] args)
    {
      var input = "000.1100";

      var result = ReturnIt(input);
      var result2 = input.Select(c => c == '.' ? (bool?)null : c == '1').ToArray();

      Console.WriteLine(result);

      //var someParents = new List<POC> { new POC(1, "A"), new POC(2, "B") };
      //var somechildren = new List<ChildPOC> { new ChildPOC(1, "Brett", "x"), new ChildPOC(1, "Emily", "X"), new ChildPOC(2, "John", "Y") };

      //var relationships = someParents.Select(x => new
      //{
      //  Id = x.Id,
      //  Name = x.Name,
      //  Children = somechildren.Where(y => y.ParentId == x.Id).ToList().ConvertAll(ChildPOCOAlter())
      //});

      //var i = "Thing";
      //var current = DateTime.Now.Date;

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
