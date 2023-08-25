using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

var obj = MakeComplexMember(typeof(POCO));
var x = obj;

static object MakeComplexMember(Type type)
{
    var props = type.GetProperties();
    var obj = Activator.CreateInstance(type);

    foreach (var p in props)
    {
        var value = GetValue(p.PropertyType);

        if (value != null) //Simple type
        {
            p.SetValue(obj, value);
        }
        else //More complex Type
        {
            if (p.PropertyType.Name == "Dictionary`2")
            {
                var t1 = p.PropertyType.GenericTypeArguments[0];
                var t2 = p.PropertyType.GenericTypeArguments[1];
                var ty1 = t1.BaseType;

                var d = GetDictionary<string, string>(t1, t2);
                p.SetValue(obj, d);
            }
            else
            {
                p.SetValue(obj, MakeComplexMember(p.PropertyType));
            }
        }
    }

    return obj ?? string.Empty;
}

static Dictionary<TKey, TVal> GetDictionary<TKey, TVal>(Type type1, Type type2)
{
    var v1 = GetValueGeneric<TKey>(type1);
    var v2 = GetValueGeneric<TVal>(type2);

    return new Dictionary<TKey, TVal> { { (TKey)(object)v1, (TVal)(object)v2 } };
}

static object GetValue(Type t)
{
    if (t == typeof(string))
        return " ";

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

static T GetValueGeneric<T>(Type t)
{
    //var typeName = (t as Type).Name.ToLower();
    //var val = (T)(object)null;

    //if (typeName == "string")
    //    val = (T)(object)" ";

    if (t == typeof(string))
        return (T)(object)" ";

    //if (t == typeof(int) || t == typeof(long) || t == typeof(float) || t == typeof(decimal) )
    //    return (T)(object)0;

        //if (t == typeof(bool))
        //    return (T)(object)false;

        //if (t == typeof(DateTime) || t == typeof(DateTimeOffset)) 
        //    return (T)(object)DateTime.Now;

        //if (t == typeof(object))
        //    return (T)(object)new object();

    return (T)(object)null;
}


public class POCO
{
    public int Id { get; set; }
    public string Desc { get; set; }
    public Dictionary<string, string> Data { get; set; }
    //public Dictionary<object, DateTime> Data2 { get; set; }
    public MiniPoco Mini { get; set; }
}

public class MiniPoco
{
    public string details { get; set; }
}