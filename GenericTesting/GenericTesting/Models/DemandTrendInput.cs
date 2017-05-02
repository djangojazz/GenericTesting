using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GenericTesting.Models
{
  [Serializable]
  [XmlRoot]
  public class DemandTrendInput 
  {
    [XmlIgnore]
    public string DemandTrendName { get; set; }
    [XmlAttribute]
    public string Grouping { get; set; }
    [XmlAttribute]
    public int FIKey { get; set; }
    [XmlAttribute]
    public DateTime StartDate { get; set; }
    [XmlAttribute]
    public DateTime EndDate { get; set; }
    public List<int> DemandLocations { get; set; }

    public DemandTrendInput()
    {
    }

    public DemandTrendInput(string demandTrendName, int fiKey, System.DateTime startDate, System.DateTime endDate, TrendChoices grouping, List<int> demandLocations)
    {
      DemandTrendName = demandTrendName;
      FIKey = fiKey;
      StartDate = startDate;
      EndDate = endDate;
      Grouping = grouping.ToString();
      DemandLocations = demandLocations;
    }                               
  }
}
