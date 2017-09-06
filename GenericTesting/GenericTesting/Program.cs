using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;

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
    
    [XmlElement("SubTests", typeof(List<SubTest>))]
    public T Value { get; set; }
    [XmlAttribute]
    public string lineNumber { get; set; }
  }

  [Serializable]
  public class Test
  {
    public Test() { }
    public Test(int testId, string name, List<SubTest> subs)
    {
      TestId = testId;
      Name = name;
      Shipments = new GenericHolder<List<SubTest>> { Value = subs };
      LineItem = new GenericHolder<SubTest> { lineNumber = "Test" };
    }

    public int TestId { get; set; }
    public string Name { get; set; }
    public GenericHolder<List<SubTest>> Shipments { get; set; }
    public GenericHolder<SubTest> LineItem { get; set; }
  }
  
  public enum EnumTest
  {
    Dev,
    QA,
    PROD
  }

  public struct Testerr
  {
    public int Id { get; set; }
  }

  class Program
  {

    static void Main(string[] args)
    {
      var env = "Environment".GetEnumFromAppSetting<EnumTest>();
    
      Console.WriteLine(env);
      //Console.WriteLine(i);
      Console.ReadLine();
    }
  }
}
