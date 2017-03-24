using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenericTesting.Models
{
  public interface ISerializeContainer<T> where T : class, new()
  {
    string Name { get; set; }       
    T Setting { get; set; } 
  }
}
