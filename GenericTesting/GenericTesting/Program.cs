using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Xsl;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;

namespace GenericTesting
{

    class Program
    {
        public class Part
        {
            public int Id { get; set; }
            public string Val { get; set; }
            public DateTime DateTimeUTDC { get; set; }

            public Part() { }

            public Part(int id, string val, DateTime pstDate)
            {
                Id = id;
                Val = val;
                DateTimeUTDC = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(pstDate, DateTimeKind.Unspecified), TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
            }
            
            public override string ToString() => $"{Id} {Val} {DateTimeUTDC}";
            public override bool Equals(object obj) => (obj as Part).Id == Id && (obj as Part).Val == Val;
            public override int GetHashCode() => $"{Id} {Val}".GetHashCode();
        }
        
        private static string ReturnDesc(int i)
        {
            var array = "abcdefghijklmnopqrstuvwxyz".ToArray();
            var sb = new StringBuilder();
            
            if (i >= 26)
            {
               sb.Append(array[(i / 26) -1]);
               i -= (i / 26) * 26;
            }
            
            sb.Append(array[i]);

            return sb.ToString();
        }

        public class Hold
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static (int Id, string Name) ReturnNamedTuple(int id, string name) => (id, name);
        public static List<(int Id, string Name)> ReturnNamedTuplesFromHolder(List<Hold> holds) => holds.Select(x => (x.Id, x.Name)).ToList();

        public static void DoSomethingWithNamedTuplesInput(List<(int id, string name)> inputs) => inputs.ForEach(x => Console.WriteLine($"Doing work with {x.id} for {x.name}"));

        private static List<(int id, string name)> DeDeduper(List<(int id, string name)> list)
        {
            list.GroupBy(x => x.name).ToDictionary(x => x.Key, x => x.Count()).OrderByDescending(x => x.Value).Where(x => x.Value >= 2).ToList()
           .ForEach(x =>
           {
               Console.WriteLine($"duplicate of {x} to remove.");
               list.Remove(list.Last(y => y.name == x.Key));
           });

           return list;
        }

        
        static void Main(String[] args)
        {
            var start = "https://localhost/admin/";

            var d = new Dictionary<string, string>
            {
                { "CourseEnrollmentTotalsReport", $"{start}university/reporting/ClassEnrollmentTotals.aspx" },
                { "CoursePaymentReport", $"{start}university/reporting/CoursePayment.aspx" },
                { "ScheduleResources", $"{start}ResourceManagement" },
                { "BadgeManagement", $"{start}Badge" },
                { "AggregatedQuizResults", $"{start}university/reporting/AggregatedTestResults.aspx" }
            };

            var node = d.GetNodesFromDictionary(start);
            Console.WriteLine(node);

            Console.ReadLine();
        }
        
    }
}
