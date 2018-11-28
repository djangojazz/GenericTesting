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
        
        static void Main(String[] args)
        {
            var p = POCOTesting.GetListings<POCO>(10);
            var h = new List<Holder>();
            var l = new List<Lookup>();

            Action hdr = () => 
            {
                p.WriteUpListCount();
                h.WriteUpListCount();
                Console.WriteLine($"******* Lookup ******");
                Console.WriteLine();
                l.ForEach(x => Console.WriteLine($"{x.POCOId} {x.HolderId}"));
            };

            Action<int> inc = x =>
            {
                var r = p.UpdateHolderListFromPocoList(l, x);
                h.AddRange(r.holder);
                l.AddRange(r.lookup);
            };

            hdr();
            inc(3);
            hdr();
            inc(3);
            hdr();
            inc(4);
            hdr();


            Console.ReadLine();
        }
        
    }
}
