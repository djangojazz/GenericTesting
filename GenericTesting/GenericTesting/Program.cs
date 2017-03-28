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

      //var input = new DemandTrendInput(2278, new DateTime(2017, 2, 25), new DateTime(2017, 3, 1), TrendChoices.FiscalWeek, new List<int> { 2, 25 });
      //var serializedInput = input.SerializeToXml();
      //var demands = Selects.GetDemandTrends(serializedInput);

      //var demand = demands.Select(x => new PlotPoints(new PlotPoint<double>(x.Grouping), new PlotPoint<decimal>(x.DemandQty)));
      //var ad = demands.Select(x => new PlotPoints(new PlotPoint<double>(x.Grouping), new PlotPoint<decimal>(x.DemandAdQty)));


      PlotPoints plotPoints = new PlotPoints(new PlotPoint<DateTime>(new DateTime(2017, 2, 5)), new PlotPoint<decimal>((decimal)10004.8000));
      var o = "Hello";
      //  new ObservableCollection<PlotPoints>(new List<PlotPoints>{ plotPoints,
      //new PlotPoints(new PlotPoint<DateTime>(new DateTime(2017, 2, 11)), new PlotPoint<decimal>(800)) });

      //var sqlTalker = new SQLTalker();
      //var test = "<Input Start=\"2-21-2017\" End=\"3-27-2017\" Grouping = \"Dt\" ><Categories><int>1</int><int>4</int></Categories></Input>";
      ////var items = sqlTalker.GetData($"EXEC pDynamicGroupTest '{test}'");

      //using (var context = new TesterEntities())
      //{
      //  var items = context.pDynamicGroupTest(test).ToList();
      //  var itemsg = items.GroupBy(x => x.CategoryId).Select(x => x);
      //}

      //var demandTrend = new DemandTrendInput(111, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 1, 2, 3 });
      //var demandTrend2 = new DemandTrendInput(222, current, current.AddDays(5), TrendChoices.FiscalWeek, new List<int> { 4, 5, 6 });

      //var d = new SerializableDictionary<string, DemandTrendInput>{ {"A", demandTrend }, {"B", demandTrend2} };

      //var serialized = d.SerializeToXml();
      //serialized.SaveXMLToAppResources(4, 1, 2, 744);

      //var sqlTalker = new SQLTalker("DEV-ENTERPRISE", "AppResources", "sqluser", "pa55word");
      //var data = sqlTalker.GetData("EXEC dbo.AppXmlRecords_Select");

      //var items = serialized.DeserializeXml<SerializableDictionary<string, DemandTrendInput>>();      

      Console.ReadLine();
    }
  }                                                                  
}
