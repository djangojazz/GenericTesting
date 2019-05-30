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
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GenericTesting
{
    static class ExtensionHelper
    {
        public static int Squared(this int number)
        {
            return number * number;
        }

        public static bool SaveXMLToAppResources<TKey, TValue>(this string xmlInput, int appxmlRecordsId, int appDefinitionId, int appSystemId, int userId)
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

        public static string SerializeToXml<T>(this T valueToSerialize, string namespaceUsed = null)
        {
            var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty, (namespaceUsed != null) ? namespaceUsed : string.Empty) });
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { OmitXmlDeclaration = true }))
                {
                    dynamic xmler = new XmlSerializer(typeof(T));
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

        public static T GetEnum<T>(this string input) => (T)Enum.Parse(typeof(T), input);

        public static T GetAppSetting<T>(this string key)
        {
            decimal d = 0;
            int i = 0;

            var input = (ConfigurationManager.AppSettings[key] ?? "Not Found");
            if (typeof(T) == typeof(int))
            {
                Int32.TryParse(input, out i);
                return (T)(object)i;
            }
            else if (typeof(T) == typeof(decimal))
            {
                Decimal.TryParse(input, out d);
                return (T)(object)d;
            }
            else if (typeof(T) == typeof(string))
            {
                return (T)(object)input;
            }

            return (T)new object();
        }

        public static T GetEnumFromAppSetting<T>(this string key) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var value = key.GetAppSetting<string>();

            try
            {
                return value.GetEnum<T>();
            }
            catch (Exception)
            {
                throw new InvalidDataException("Value used is not found in the enum of T");
            }
        }

        public static DateTime GetDateTimeFromString(this string input, string format)
        {
            DateTime dt;
            DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            return dt;
        }

        public static void AddorUpdate<TKey, TValue>(this Dictionary<TKey, TValue> d, TKey key, TValue value) => d[key] = value;

        public static void AddOrUpdateItemInCollection<TKey, TValue>(this Dictionary<TKey, List<TValue>> d, TKey key, TValue value)
        {
            if (d.ContainsKey(key)) { d[key].Add(value); }
            else { d[key] = new List<TValue> { value }; }
        }


        public static void WriteUpListCount<T>(this List<T> list) where T : BasePOCO
        {
            Console.WriteLine($"******* {typeof(T)} ******");
            Console.WriteLine();
            list.ForEach(x => Console.WriteLine($"{x.Id} {x.Desc}"));
        }

        public static (List<Lookup> lookup, List<Holder> holder) UpdateHolderListFromPocoList(this List<POCO> originatingList, List<Lookup> d, int count)
        {
            var toAdd = originatingList.Where(x => !d.Any(y => y.POCOId == x.Id)).Take(count).Select(x => (PocoId: x.Id, Desc: x.Desc, HolderId: x.Id + 100));
            return (new List<Lookup>(toAdd.Select(x => new Lookup(x.PocoId, x.HolderId))), new List<Holder>(toAdd.Select(x => new Holder(x.HolderId, x.Desc))));
        }

        public static string GetSectionsSeparatedByCaps(this string input)
        {
            var matches = Regex.Matches(input, "[A-Z]");
            StringBuilder sb = new StringBuilder();

            if (matches.Count == 0)
                return $"{input.Substring(0, 1).ToUpper()}{input.Substring(1, input.Length - 1).ToLower()}";

            if (matches.Count == 1 && matches[0].Index != 0)
                return $"{input.Substring(0, 1).ToUpper()}{input.Substring(1, matches[0].Index - 1).ToLower()} {input.Substring(matches[0].Index, input.Length - matches[0].Index)}";

            for (int i = 0; i < matches.Count; i++)
                if (i == matches.Count - 1)
                    sb.Append(input.Substring(matches[i].Index, input.Length - matches[i].Index));
                else
                    sb.Append($"{input.Substring(matches[i].Index, matches[i + 1].Index - matches[i].Index)} ");
            

            return sb.ToString();
        }
    }

}
