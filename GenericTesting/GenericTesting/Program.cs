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
    public int Id { get; set; }
    public override bool ShouldSerializeBaseId() => true;

    public POC() { }

    public POC(int id)
    {
      Id = id;
    }
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      var items = DataAccess.Enterprise.Selects.GetTestDefintion2(50, DateTime.Now.Date);

      Console.ReadLine();
    }

    
  }
}
