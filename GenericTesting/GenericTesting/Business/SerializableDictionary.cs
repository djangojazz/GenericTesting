using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace GenericTesting.Business
{
  [XmlRoot("Dictionary")]
  public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
  {
    private const string _element = "Element";
    private const string _key = "Key";
    private const string _value = "Value";

    private XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty, string.Empty) });

    public SerializableDictionary()
    {
      if (  (!typeof(TKey).IsSerializable && !(typeof(ISerializable).IsAssignableFrom(typeof(TKey))))
        || (!typeof(TValue).IsSerializable && !(typeof(ISerializable).IsAssignableFrom(typeof(TValue))))
        )
      {
        throw new InvalidOperationException("A Serializable Type is required.  Please ensure that the class used has the proper [Serializable] Attribute set.");
      }
    }

    #region IXmlSerializable Members
    public System.Xml.Schema.XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      XmlSerializer keySerializer = new XmlSerializer(typeof(TKey), string.Empty);
      XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue), string.Empty);

      bool wasEmpty = reader.IsEmptyElement;
      reader.Read();

      if (wasEmpty)
        return;

      while (reader.NodeType != XmlNodeType.EndElement)
      {
        reader.ReadStartElement(_element);

        TKey key = default(TKey);

        if (typeof(TKey) == typeof(string))
        {
          key = (TKey)(object)reader.ReadElementContentAsString(_key, string.Empty);
        }
        else if (typeof(TKey) == typeof(int))
        {
          key = (TKey)(object)reader.ReadElementContentAsInt(_key, string.Empty);
        } 
        else
        {
          reader.ReadStartElement(_key);
          key = (TKey)keySerializer.Deserialize(reader);
          reader.ReadEndElement();
        }
                                  
        reader.ReadStartElement(_value);
        TValue value = (TValue)valueSerializer.Deserialize(reader);
        reader.ReadEndElement();

        this.Add(key, value);

        reader.ReadEndElement();
        reader.MoveToContent();
      }
      reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
      XmlSerializer keySerializer = new XmlSerializer(typeof(TKey), string.Empty);
      XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue), string.Empty);

      foreach (TKey key in this.Keys)
      {
        writer.WriteStartElement(_element);

        if (typeof(TKey) == typeof(string) || typeof(TKey) == typeof(int))
        {
          writer.WriteElementString(_key, key.ToString());
        }
        else
        {
          writer.WriteStartElement(_key);
          keySerializer.Serialize(writer, key, ns);
          writer.WriteEndElement();
        }                        

        writer.WriteStartElement(_value);
        TValue value = this[key];
        valueSerializer.Serialize(writer, value, ns);
        writer.WriteEndElement();

        writer.WriteEndElement();
      }
    }
    #endregion
  }
}
