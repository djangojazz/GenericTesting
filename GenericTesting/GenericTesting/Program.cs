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

        static void Main(String[] args)
        {
            //var p = POCOTesting.GetListings<POCO>(27);
            //var h = new List<Holder>();
            //var l = new List<Lookup>();
            
            for (int i = 1; i <= 330; i++)
            {
                //Console.WriteLine($"{i % 26} {i / 26}");
                Console.WriteLine(ReturnDesc(i));
            }

            //Action hdr = () => 
            //{
            //    p.WriteUpListCount();
            //    h.WriteUpListCount();
            //    Console.WriteLine($"******* Lookup ******");
            //    Console.WriteLine();
            //    l.ForEach(x => Console.WriteLine($"{x.POCOId} {x.HolderId}"));
            //};

            //Action<int> inc = x =>
            //{
            //    var r = p.UpdateHolderListFromPocoList(l, x);
            //    h.AddRange(r.holder);
            //    l.AddRange(r.lookup);
            //};

            //hdr();
            //inc(3);
            //hdr();
            //inc(3);
            //hdr();
            //inc(4);
            //hdr();


            Console.ReadLine();
        }
        
    }
}
