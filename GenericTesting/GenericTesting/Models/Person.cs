using System;       
using System.Xml;           
using System.Xml.Serialization;

namespace GenericTesting.Models
{
  [Serializable]
  public class Person
  {       
    [XmlAttribute]
    public string PersonName { get; set; }

    public Person(string name)
    {
      PersonName = name;
    }

    public Person()  {}                   
  }
}
