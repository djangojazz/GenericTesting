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

  public class POC
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
    public static List<POC> GetPOCOs()
    {
      return new List<POC>
      {
          new POC { Id = 1, Desc = "John"},
          new POC { Id = 2, Desc = "Jane" },
          new POC { Id = 3, Desc = "Joey" }
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

    public static List<POC> GetPOCOsAndOrders()
    {
      return new List<POC>
      {
          new POC { Id = 1, Desc = "John", Orders = GetOrders(1)},
          new POC { Id = 2, Desc = "Jane", Orders = GetOrders(2) },
          new POC { Id = 3, Desc = "Joey" , Orders = GetOrders(3)}
      };
    }
  }
}
