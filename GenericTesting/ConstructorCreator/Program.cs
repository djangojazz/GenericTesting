using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConstructorCreator
{
    public class POCO
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }

        public POCO() { }
        public POCO(int id, string desc, DateTime date) => (Id, Desc, Date) = (id, desc, date);
    }

    public class POCO2
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }

        public POCO2() { }
        public POCO2(int id, string desc) => (Id, Desc) = (id, desc);

        public override string ToString() => $"{Id} {Desc} {Date}";
    }

    class Program
    {
        public static string MakeInstatiationFromObjectWatch(string s)
        {
            var items = s.Split(Environment.NewLine).Where(x => x != string.Empty).ToList();
            var sb = new StringBuilder();
            items.ForEach(x => sb.AppendLine(x.Substring(0, x.IndexOf('\t')) + " = " + x.Substring(x.IndexOf('\t') + 1) + ", "));
            return sb.ToString();
        }

        public static string MakeTestsFromString(string s)
        {
            var items = s.Split(Environment.NewLine).Select(x => x.Trim()).Where(x => x.StartsWith("public") && x.Contains(" To")).ToList();
            var sb = new StringBuilder();
            items.ForEach(x =>
            {
                var indexTo = x.IndexOf(" To");
                var indexP = x.IndexOf("(");
                var indexX = x.IndexOf("x)");
                if (indexTo > 0 && indexP > 0 && indexX > 0 && indexP > indexTo && x.Substring(indexP - 1, 1) != "s")
                {
                    var name = x.Substring(indexTo + 3, indexP - indexTo - 3).Trim();
                    var sigName = x.Substring(indexP + 6, indexX - indexP - 6).Trim();
                    sb.AppendLine();
                    sb.AppendLine("[Fact]");
                    sb.AppendLine("public void ShouldExtract" + name + "() => new " + sigName + "().NotBeNull(x => x.To" + name + "());");
                }

            });

            return sb.ToString();
                //[Fact]
        //public void ShouldExtractJobInfoHistory() => new JobInfo().NotBeNull(x => x.ToJobInfoHistory());
        }

        static void Main(string[] args)
        {
            ////Make or check directory
            var target = DirectoryHelper.MakeOrCreateDirectory(@"C:\Temp");
            DirectoryHelper.CreateConstruction(@"C:\AyaGit\Applications\Aya.Core.Api\Aya.Core.DTO\Shifts\PerDiem\CandidateDto.cs", target.FullName);

            //var output = ReflectorConverter.Converter<POCO, POCO2>(item);
            //Console.WriteLine(output);
        }
    }
}
