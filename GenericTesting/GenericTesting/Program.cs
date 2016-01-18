using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericTesting
{
  class Program
  {
    static List<POCO> GetPOCOs()
    {
      return new List<POCO>
      {
          new POCO { Id = 1, Name = "John", Description = "basic" },
          new POCO { Id = 2, Name = "Jane", Description = "more" },
          new POCO { Id = 3, Name = "Joey", Description = "advanced" }
      };
    }

    
//It's not, if you understand what it means :) Basically you've applied a default namespace URI of "http://schemas.microsoft.com/developer/msbuild/2003" to all elements.So when querying, you need to specify that namespace too.Fortunately, LINQ to XML makes that really simple:

//XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
//  XDocument doc = XDocument.Parse(xml2);
//foreach (XElement element in doc.Descendants(ns + "ItemGroup"))
//{
//    Console.WriteLine(element);
//}

  static void Main(string[] args)
    {
      new Lambdas.LambdaEvents().DoIt();

      Console.ReadLine();
    }
  }
}
