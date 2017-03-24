using System;
using System.Collections.Generic;
using System.IO;        
using System.Xml;
using System.Xml.Serialization;

namespace GenericTesting
{                                   
  static class ExtensionHelper
  {
    private static HashSet<Type> ConstructedSerializers = new HashSet<Type>();

    public static string SerializeToXml<T>(this T valueToSerialize)
    {
      var ns = new XmlSerializerNamespaces(new XmlQualifiedName[]{ new XmlQualifiedName(string.Empty, string.Empty) });
      ns.Add("", "");
      using (var sw = new StringWriter())
      {
        using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { OmitXmlDeclaration = true }))
        {
          dynamic xmler = GetXmlSerializer(typeof(T));      
          xmler.Serialize(writer, valueToSerialize, ns);
        }

        return sw.ToString();
      }          
    }
                          
    public static T DeserializeXml<T>(this string xmlToDeserialize)
    {
      dynamic serializer = new XmlSerializer(typeof(T));

      using (TextReader reader = new StringReader(xmlToDeserialize))
      {
        return (T)serializer.Deserialize(reader);
      }
    }
                 
    public static XmlSerializer GetXmlSerializer(Type typeToSerialize)
    {
      if (!ConstructedSerializers.Contains(typeToSerialize))
      {
        ConstructedSerializers.Add(typeToSerialize);
        return XmlSerializer.FromTypes(new Type[] { typeToSerialize })[0];
      }
      else
      {
        return new XmlSerializer(typeToSerialize);
      }
    }               
  }
}
