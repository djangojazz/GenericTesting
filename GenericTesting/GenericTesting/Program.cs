using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;

namespace GenericTesting
{
  [Serializable]
  public class SubTest
  {
    public SubTest() {}
    public SubTest(int id, string name)
    {
      Id = id;
      Name = name;
    }
    [XmlAttribute]
    public int Id { get; set; }
    [XmlAttribute]
    public string Name { get; set; }
  }

  [Serializable]
  public sealed class GenericHolder<T> where T : class
  {
    public GenericHolder() { }

    [XmlElement("A", typeof(List<SubTest>))]
    public T Value { get; set; }
  }

  [Serializable]
  public class Test
  {
    public Test() { }
    public Test(int testId, string name, List<SubTest> subs)
    {
      TestId = testId;
      Name = name;
      Shipments = new GenericHolder<List<SubTest>> { Value = subs }; ;
    }

    public int TestId { get; set; }
    public string Name { get; set; }
    
    
    public GenericHolder<List<SubTest>> Shipments { get; set; }
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      var tester = new Test(1, "Test", new List<SubTest> { new SubTest(10, "SubTest"), new SubTest(20, "SubTest2") });
      var xDoc = XDocument.Parse(tester.SerializeToXml());
      Console.WriteLine(xDoc);

      Console.ReadLine();
    }
  }
}
