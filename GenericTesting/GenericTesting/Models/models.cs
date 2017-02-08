using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenericTesting.Models
{
  [Serializable()]
  public class Location
  {                                                                                
    [XmlAttribute()]
    public int Id { get; set; }
    [XmlElement]
    public double PercentUsed { get; set; }
    [XmlElement]
    public string ExtraGarbage { get; set; }
    [XmlElement]
    public string UsedOnceInTheUniverse { get; set; }
  }

  [Serializable()]
  [XmlRoot("locations")]
  public class Locations
  {                                             
    [XmlAttribute()]
    public DateTime DateFrom { get; set; }
    [XmlAttribute()]
    public DateTime DateTo { get; set; }

    [XmlElement("location")]
    public List<Location> locations { get; set; }
  }
                                           
                        
    [XmlRoot(ElementName = "column")]
    public class QADailyXValueCalCheck
    {
      [XmlElement]
      public string Regs { get; set; }
      [XmlElement]
      public string BasisTStamp { get; set; }
      [XmlElement]
      public string DAsWriteTStamp { get; set; }
      [XmlElement]
      public string InjEndTime { get; set; }
      [XmlElement]
      public int Manual { get; set; }
      [XmlElement]
      public decimal RefValue { get; set; }
      [XmlElement]
      public decimal MeasValue { get; set; }
      [XmlElement]
      public int Online { get; set; }
      [XmlElement]
      public decimal AllowableDrift { get; set; }
      [XmlElement]
      public bool FailOoc { get; set; } = false;
      [XmlElement]
      public int FailAbove { get; set; }
      [XmlElement]
      public int FailBelow { get; set; }
      [XmlElement]
      public bool FailOoc5Day { get; set; }
      [XmlElement]
      public decimal InstSpan { get; set; }
      [XmlElement]
      public string GasLevel { get; set; }
      [XmlElement]
      public string CId { get; set; }
      [XmlElement]
      public string MId { get; set; }
      [XmlElement]
      public string CylinderId { get; set; }
      [XmlElement]
      public string CylinderExpDate { get; set; }
      [XmlElement]
      public string CylinderVendorId { get; set; }
      [XmlElement]
      public string CylinderGasTypeCode { get; set; }
    }
  
}
