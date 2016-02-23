using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenericTesting
{
    public class POCO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

  [XmlRoot]
  public class StatusDocumentItem
  {
    [XmlElement]
    public string DataUrl;
    [XmlElement]
    public string LastUpdated;
    [XmlElement]
    public string Message;
    [XmlElement]
    public int State;
    [XmlElement]
    public string StateName;
  }
}
