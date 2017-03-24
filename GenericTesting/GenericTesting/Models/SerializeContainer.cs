using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericTesting.Models
{
  [Serializable]
  public class SerializeContainer<T> where T : class, new()
  {                 
    [XmlAttribute]
    public string Name { get; set; }
                   
    public T Setting { get; set; }                                                                                          

    public SerializeContainer() { }

    public SerializeContainer(string name, T setting)
    {
      if (!typeof(T).IsSerializable && !(typeof(ISerializable).IsAssignableFrom(typeof(T)))) 
      {
        throw new InvalidOperationException("A Serializable Type is required.  Please ensure that the class used has the proper Serializable Attribute set.");
      }

      var thing = typeof(T).ToString(); 
      Name = name;
      Setting = setting;
    }
  }
}
