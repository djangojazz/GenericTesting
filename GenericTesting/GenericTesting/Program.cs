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
    public BasePOC() { }

    public BasePOC(int baseId)
    {
      BaseId = baseId;
    }

    public virtual int BaseId { get; set; }
    public virtual bool ShouldSerializeBaseId() => false;
  }

  [Serializable]
  public class POC : BasePOC
  {
    public POC() { }

    public POC(int id, int id2)
    {
      Id = id;
      Id2 = id2;
    }

    [XmlAttribute]
    public int Id { get; set; }
    [XmlAttribute]
    public int Id2 { get; set; }

    public override bool ShouldSerializeBaseId() => true;
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


  public class BaseTest
  {
    public int BaseId { get; set; }
    public DateTime Created { get; set; }

    public BaseTest() { }

    public BaseTest(int baseId, DateTime created)
    {
      BaseId = baseId;
      Created = created;
    }
  }

  public class X : BaseTest
  {
    public string Desc { get; set; }
    public int Val { get; set; }

    public X(string desc, int val, BaseTest baseValues)
    {
      Desc = desc;
      Val = val;
      BaseId = baseValues.BaseId;
      Created = baseValues.Created;
    }

    public X(string desc, int val, int baseId, DateTime created) : base(baseId, created)
    {
      Desc = desc;
      Val = val;
    }
  }
  
  
  public class Book
  {
    public int TitleId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }

    public Book(int titleId, string title, string genre)
    {
      TitleId = titleId;
      Title = title;
      Genre = genre;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var contextMock = new List<Book>
      {
        new Book(1, "Harry Potter and The Sorcerer's Stone", "Fiction"),
        new Book(2, "Harry Potter and The Secret Chamber", "Fiction"),
        new Book(3, "Dune", "Fiction"),
        new Book(4, "The Lord of The Rings The Fellowship of the Ring", "Fiction"),
        new Book(5, "The Lord of The Rings Return of the King", "Fiction"),
        new Book(6, "A Brief History of Time", "NonFiction")
      };
      
      var wrong = contextMock.Where(x => (new[]{ "harry potter", "the lord of the rings" }).Contains(x.Title.ToLower())).ToList();
      var r = contextMock.Where(x => (new List<string> { "harry potter", "the lord of the rings" }).Any(y => x.Title.ToLower().Contains(y.ToLower()))).ToList();

      Console.ReadLine();
    }
  }
}
