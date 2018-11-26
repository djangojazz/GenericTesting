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
            var ls = new List<Color>
            {
               Color.FromArgb(42, 69, 89),
               Color.FromArgb(25, 35, 6),
               Color.FromArgb(39, 24, 44),
               Color.FromArgb(104, 73, 42),
               Color.FromArgb(30, 86, 79)
            };

            var newListing = ls.CreateColorsFromBaseColors(4);

            newListing.ForEach(color =>
            {
                Console.WriteLine($"Color: {color.R} { color.G} {color.B} {color.Name}");
            });


            Console.ReadLine();
        }
    }
}
