using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using GenericTesting.DataAccess;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace GenericTesting
{
  static class ExtensionHelper
  {
    public static int Squared(this int number)
    {
      return number * number;
    }

    public static bool SaveXMLToAppResources<TKey,TValue>(this string xmlInput, int appxmlRecordsId, int appDefinitionId, int appSystemId, int userId)
    {
      if (!(xmlInput.ValidateXml()))
        return false;

      var sqlTalker = new SQLTalker("DEV-ENTERPRISE", "AppResources", "sqluser", "pa55word");

      return sqlTalker.ProcerWithSuccess($"EXEC dbo.AppXmlRecords_InsertOrUpdate {appxmlRecordsId}, {appDefinitionId}, {appSystemId}, {userId}, '{xmlInput}'");
    }

    public static bool SaveXMLToAppResources(this string xmlInput, int appxmlRecordsId, int appDefinitionId, int appSystemId, int userId)
    {
      if (!(xmlInput.ValidateXml()))
        return false;

      var sqlTalker = new SQLTalker("DEV-ENTERPRISE", "AppResources", "sqluser", "pa55word");

      return sqlTalker.ProcerWithSuccess($"EXEC dbo.AppXmlRecords_InsertOrUpdate {appxmlRecordsId}, {appDefinitionId}, {appSystemId}, {userId}, '{xmlInput}'");
    }


    public static bool ValidateXml(this string xmlInput)
    {
      try
      {
        XElement.Parse(xmlInput);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    private static HashSet<Type> ConstructedSerializers = new HashSet<Type>();

    public static string SerializeToXml<T>(this T valueToSerialize)
    {
      var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty, string.Empty) });
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

    public static string SerializeToXmlUpper<T>(this T valueToSerialize)
    {
      var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty, string.Empty) });
      ns.Add("", "");
      using (var sw = new StringWriter())
      {
        using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { OmitXmlDeclaration = true }))
        {
          dynamic xmler = GetXmlSerializer(typeof(T));
          xmler.Serialize(writer, valueToSerialize, ns);
        }

        return sw.ToString().ToUpper();
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

    public static void ClearAndAddRange<T>(this IList<T> input, IEnumerable<T> array)
    {
      if (input == null) return;
      input.Clear();
      foreach (var x in array) input.Add(x);
    }

    public static bool IsDictionary(this object input)
    {
      return (input is IDictionary) ? true : false;
    }

    public static string GetStringListings(this IDictionary dictionary)
    {
      string s = string.Empty;
      foreach (DictionaryEntry o in dictionary) { s += $"{o.Key.ToString()} {o.Value.ToString()} {Environment.NewLine}"; }
      return s;
    }

    public static string DynamicSerializer<TypeOfDefinition>(this TypeOfDefinition typ)
    {
      if (typ.GetType() == typeof(POC)) { return (new Test<POC> { Id = 1, Thing = (POC)(object)typ }).SerializeToXml(); }
      else { return (new Test<POC2> { Id = 1, Thing = (POC2)(object)typ }).SerializeToXml(); }
    }
  }
}
