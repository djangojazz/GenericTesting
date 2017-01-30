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
    [XmlAttribute()]
    public double PercentUsed { get; set; }
    [XmlElement]
    public string ExtraGarbage { get; set; }
    [XmlText]
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
}
