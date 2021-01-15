using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorCreator
{
    public class ConstructorObject
    {
        public string Name { get; set; }
        public List<Line> Lines { get; set; }
        public string OriginalStrings { get; set; }
        public string SignatureStrings { get; set; }
        public string CamelStrings { get; set; }

        public ConstructorObject(string input)
        {
            var lines = input.Split(Environment.NewLine);

            string GetUpdatedName(string s)
            {
                var firstLetter = s.ToCharArray().First();
                return (char.IsUpper(firstLetter)) ? $"{s.Substring(0, 1).ToLower()}{s.Substring(1, s.Length - 1)}" : $"a{s}";
            }
            

            var hdr = lines.FirstOrDefault(x => x.Contains("class"));
            hdr = hdr.Substring(hdr.IndexOf("class"));
            Name = hdr.Substring(hdr.IndexOf(' ')).Trim();
            if (Name.Contains(":"))
                Name = Name.Substring(0, Name.IndexOf(":")).Trim();

            Lines = lines
                .Where(x => x.Contains("get;"))
                .Select((x, i) => new { Ind = i + 1, Strings = x.Replace(" virtual", string.Empty).Substring(x.IndexOf("public")).Split(" ") })
                .Select(x => new Line(x.Ind, x.Strings[2].Trim(), GetUpdatedName(x.Strings[2].Trim()), x.Strings[1].Trim()))
                .ToList();

            OriginalStrings = string.Join(", ", Lines.Select(x => $"{x.Name}"));
            SignatureStrings = string.Join(", ", Lines.Select(x => $"{x.Type} {x.SigName}"));
            CamelStrings = string.Join(", ", Lines.Select(x => $"{x.SigName}"));
        }

        public string MakeConstructor() => $"public {Name}({SignatureStrings}) =>{Environment.NewLine}\t({OriginalStrings}) ={Environment.NewLine}\t({CamelStrings});";
        public string MakeStaticMapper() => $"public static {Name} To{Name}(this object x) =>{Environment.NewLine}\tnew {Name}(x.{OriginalStrings.Replace(", ", ", x.")});";
        public string MakeExpressionMapper() => $"public static Expression<Func<x,{Name}>> Select{Name} = x =>{Environment.NewLine}\tnew {Name}(x.{OriginalStrings.Replace(", ", ", x.")});";
        public void MakeAFile(string location)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine("Constructor");
            sb.Append(MakeConstructor());
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Static");
            sb.Append(MakeStaticMapper());
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Expression");
            sb.Append(MakeExpressionMapper());

            using (var sw = new StreamWriter($"{location}\\{Name}.txt"))
                sw.Write(sb.ToString());
        }
    }

    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SigName { get; set; }
        public string Type { get; set; }

        public Line(int id, string name, string sigName, string type) => (Id, Name, SigName, Type) = (id, name, sigName, type);
    }
}
