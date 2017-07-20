using System;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using GenericTesting.Models;
using GenericTesting.Business;
using GenericTesting.DataAccess;

namespace GenericTesting
{
  [Serializable]
  public class BasePOC
  {
    
    public virtual int BaseId { get; set; }
    public virtual bool ShouldSerializeBaseId() => false;
  }

  [Serializable]
  public class POC : BasePOC
  {
    [XmlAttribute]
    public int Id { get; set; }
    [XmlAttribute]
    public int Id2 { get; set; }

    public override bool ShouldSerializeBaseId() => true;

    public POC() { }

    public POC(int id, int id2)
    {
      Id = id;
      Id2 = id2;
    }
  }

  [Serializable]
  public class HoldTest 
  {
    public int HolderId { get; set; }
    public string Name { get; set; }
    public POC POC { get; set; }
    public int TrueFalse { get; set; }

    public HoldTest() { }

    public HoldTest(int holderId, string name, POC poco, int trueFalse)
    {
      HolderId = holderId;
      Name = name;
      POC = poco;
      TrueFalse = trueFalse;
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      var xml = "<root><a><b Id=\"100\">Text</b><b Id=\"200\">Some</b><b Id=\"300\">More</b></a></root>";
      var xDoc = XDocument.Parse(xml);

      var nodeA = xDoc.Root.Element("a");
      var nodeB = nodeA.Element("b");
      var attributeOfB = (int)nodeB.Attribute("Id");
      var textOfB = (string)nodeB.Value;

      //Simple
      Console.WriteLine($"Xml as is {Environment.NewLine} {xDoc} {Environment.NewLine}{Environment.NewLine}Xml values I want{Environment.NewLine}  Attribute: {attributeOfB}{Environment.NewLine}  Text: {textOfB}");

      //Node Series
      string s = String.Empty;
      nodeA.Descendants("b").ToList().ForEach(nodeB2 => s += $"Attribute:  {nodeB2.Attribute("Id")}  Text: {nodeB2.Value}{Environment.NewLine}");

      Console.WriteLine(s);

      Console.ReadLine();
    }
  }
}
