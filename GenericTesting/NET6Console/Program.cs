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
        //Try to get default for value types and primitives
        var value = p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;

        if (value != null)
            p.SetValue(obj, value);

        if (value == null)
        {
            var propertyName = p.PropertyType.FullName;

            if (propertyName == "System.String")
            {
                p.SetValue(obj, "Abc");
            }
            else
            {
                p.SetValue(obj, MakeComplexMember(p.PropertyType));
            }
        }
    }

    return obj ?? string.Empty;
}

public class POCO
{
    public int Id { get; set; }
    public string Desc { get; set; }
    //public Dictionary<string, string> Data { get; set; }
    public MiniPoco Mini { get; set; }
}

public class MiniPoco
{
    public string details { get; set; }
}