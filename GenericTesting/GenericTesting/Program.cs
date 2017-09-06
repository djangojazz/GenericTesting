using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;
using System.Globalization;

namespace GenericTesting
{
  [Serializable]
  public class SubTest
  {
    public SubTest() { }
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
      DateTime d = new DateTime(2017, 9, 6);
      //Cool what I would expect to show the day position with two digits and the month uses one if needed else it will go to two if needed.
      Console.WriteLine(d.ToString("Mddyyyy"));

      //I can parse out an int and see it is exactly as above.
      int i = Int32.Parse(d.ToString("MMddyyyy"));
      Console.WriteLine(i.ToString());
      int i2 = Int32.Parse(d.ToString("yyyyMMdd"));
      Console.WriteLine(i2.ToString());
      
      DateTime dt = $"0{i.ToString()}".GetDateTimeFromDecimal("MMddyyyy");
      
      //string[] formats = { "Mddyyyy", "MMddyyyy" };
      //DateTime.TryParseExact(PadLeft(8, '0'), CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

      Console.WriteLine(dt);


      //Console.WriteLine(i);
      Console.ReadLine();
    }
  }
}
