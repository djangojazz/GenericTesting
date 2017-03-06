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

  public class Holder
  {
    public int Id { get; set; }
    public string Desc { get; set; }
    public List<Order> Orders { get; set; }
  }

  public class Order
  {
    public int Id { get; set; }
    public string Desc { get; set; }
  }

  public class POCOTesting
  {
    public static List<Holder> GetPOCOs()
    {
      return new List<Holder>
      {
          new Holder { Id = 1, Desc = "John"},
          new Holder { Id = 2, Desc = "Jane" },
          new Holder { Id = 3, Desc = "Joey" }
      };
    }

    public static List<Order> GetOrders(int numberOfOrders)
    {
      var orders = new List<Order>();

      for (int i = 1; i <= numberOfOrders; i++)
      {
        orders.Add(new Order { Id = i, Desc = $"{i} Order" });
      }

      return orders;
    }

    public static List<Holder> GetPOCOsAndOrders()
    {
      return new List<Holder>
      {
          new Holder { Id = 1, Desc = "John", Orders = GetOrders(1)},
          new Holder { Id = 2, Desc = "Jane", Orders = GetOrders(2) },
          new Holder { Id = 3, Desc = "Joey" , Orders = GetOrders(3)}
      };
    }
  }
}
