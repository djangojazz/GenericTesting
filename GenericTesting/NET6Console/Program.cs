using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;


static void GetPropertyValues(Object obj)
{
    Type t = obj.GetType();
    Console.WriteLine("Type is: {0}", t.Name);
    PropertyInfo[] props = t.GetProperties();
    Console.WriteLine("Properties (N = {0}):",
                      props.Length);
    foreach (var prop in props)
    {
        if (prop.GetIndexParameters().Length == 0)
        {
            var val = prop.GetValue(obj, null);
            Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name}): {val}");
        }
        else
        {
            Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name}): <Indexed>");
        }
    }
}

var obj = MakeComplexMember(typeof(POCO));
var x = obj;

static object MakeComplexMember(Type type)
{
    var props = type.GetProperties();
    var obj = Activator.CreateInstance(type);

    foreach (var p in props)
    {
        var value = GetObject(p.PropertyType);

        if (value != null) //Simple type
        {
            p.SetValue(obj, value);
        }
        else //More complex Type
        {
            var name = p.PropertyType.Name;

            if (name == "Dictionary`2")
            {
                MakeADictionaryWithARow(p, obj);
            }
            else if (name == "List`1" || name == "IEnumerable`1" || name == "IList`1" || name == "Collection`1")
            {
                MakeAList(p, obj);
            }
            else if (name.Contains("[]"))
            {
                MakeAnArray(p, obj);
            }
            else
            {
                p.SetValue(obj, MakeComplexMember(p.PropertyType));
            }
        }
    }

    return obj ?? string.Empty;
}

static void MakeAnArray(PropertyInfo p, object obj)
{
    var o = p.PropertyType;
    var t = o.GetElementType();
    var a = Array.CreateInstance(t, 1);
    a.SetValue(GetObject(t) ?? MakeComplexMember(t), 0);
    p.SetValue(obj, a);
}

static void MakeADictionaryWithARow(PropertyInfo p, object obj)
{
    //get key pair types
    var t = p.PropertyType.GenericTypeArguments[0];
    var t2 = p.PropertyType.GenericTypeArguments[1];

    //Make a generic dictionary
    var d1 = typeof(Dictionary<,>);
    Type[] typeArgs = { t, t2 };
    var dType = d1.MakeGenericType(typeArgs);
    var d = Activator.CreateInstance(dType) ?? new object();

    //Add a row and then add the dictionary to the parent
    d?.GetType().GetMethod("Add", new[] { t, t2 })?.Invoke(d, new object[] { GetObject(t) ?? MakeComplexMember(t), GetObject(t2) ?? MakeComplexMember(t) });
    p.SetValue(obj, d);
}

static void MakeAList(PropertyInfo p, object obj)
{
    var t = p.PropertyType.GenericTypeArguments[0];
    var listType = typeof(List<>);
    var constructedListType = listType.MakeGenericType(t);

    var l = Activator.CreateInstance(constructedListType);

    l?.GetType().GetMethod("Add", new[] { t })?.Invoke(l, new object[] { GetObject(t) ?? MakeComplexMember(t) });
    p.SetValue(obj, l);
}


static object GetObject(Type t, string defaultString = "x")
{
    if (t == typeof(string))
        return defaultString;

    if (t == typeof(int) || t == typeof(long) || t == typeof(float) || t == typeof(decimal))
        return 0;

    if (t == typeof(bool))
        return false;

    if (t == typeof(DateTime) || t == typeof(DateTimeOffset))
        return DateTime.Now;

    if (t == typeof(object))
        return new object();

    return null;
}


public class POCO
{
    public int Id { get; set; }
    public string Desc { get; set; }
    public int[] Numbers { get; set; }
    public Dictionary<string, string> Data { get; set; }
    public Dictionary<object, DateTime> Data2 { get; set; }
    public MiniPoco Mini { get; set; }
}

public class MiniPoco
{
    public string details { get; set; }
    public int[] numbers { get; set; }
    public KeyPairIt KeyP { get; set; }
}

public class KeyPairIt
{
    public string Name { get; set; }
    public int Value { get; set; }
}