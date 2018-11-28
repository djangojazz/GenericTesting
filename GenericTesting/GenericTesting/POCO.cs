using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenericTesting
{
    public abstract class BasePOCO
    {
        [Key]
        public int Id { get; set; }
        public string Desc { get; set; }
    }

    public class POCO : BasePOCO
    {
        public POCO() { }
        public POCO(string desc) => Desc = desc;
    }

    public class Lookup
    {
        public int POCOId { get; set; }
        [Key]
        public int HolderId { get; set; }
        public Lookup() { }
        public Lookup(int pocoId, int holderId) => (POCOId, HolderId) = (pocoId, holderId);
    }

    public class Holder : BasePOCO
    {
        public List<Order> Orders { get; set; }

        public Holder() { }
        public Holder(int id, string desc) => (Id, Desc) = (id, desc);
    }

    public class Order
    {
        public int Id { get; set; }
        public string Desc { get; set; }
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

    public class POCOTesting
    {
        public static List<T> GetListings<T>(int count) where T : BasePOCO, new()
        {
            var instance = new List<T>();
            var array = "abcdefghijklmnopqrstuvwxyz".ToArray();

            for (int i = 1; i <= count; i++)
                instance.Add(new T { Id = i, Desc = array[i - 1].ToString() });

            return instance;
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
