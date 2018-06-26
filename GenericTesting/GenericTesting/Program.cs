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
        static Assembly _assembly;

        public abstract class Piece
        {
            public string Name { get; set; }
            public Point Location { get; set; }
            public abstract bool CheckHit(Point pointOther);
        }

        public class Queen : Piece
        {
            public override bool CheckHit(Point otherPieceLocation) =>
                (Location.X == otherPieceLocation.X
                    || Location.Y == otherPieceLocation.Y
                    || Math.Abs(otherPieceLocation.Y - Location.Y) == Math.Abs(otherPieceLocation.X - Location.X));
            public Queen(Point location, string name)
            {
                Location = location;
                Name = name;
            }
        }

      

        public static class Board
        {
            public static List<Piece> Pieces { get; set; } = new List<Piece>();
            public static List<Point> AvailableLocations { get; set; } = new List<Point>();

            static Board()
            {
                for (int i = 1; i <= 4; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        AvailableLocations.Add(new Point(i, j));
                    }
                }
            }
            
            public static void MovePieceIfHit(Piece piece)
            {
                var ind = AvailableLocations.FindIndex(x => x == piece.Location);
                piece.Location = (ind != (AvailableLocations.Count - 1)) ? AvailableLocations[ind+1] : AvailableLocations[0];
            }
        }

        private static void RunChessProgram()
        {
            int upperLimit = 3;
            Dictionary<Point, bool> possibleHitCombos = new Dictionary<Point, bool>();
            for (int i = 1; i < upperLimit; i++)
            {
                for (int j = i + 1; j <= upperLimit; j++)
                {
                    possibleHitCombos.Add(new Point(i, j), false);
                }
            }

            possibleHitCombos.ToList().ForEach(x => Console.WriteLine($"{x.Key.X} {x.Key.Y} {x.Value}"));

            Action<Piece> writeOutLocation = x => Console.WriteLine($"{x.Name}'s location X: {x.Location.X} Y: {x.Location.Y}");

            //for (int i = 1; i <= 3; i++)
            //{
            //    var q = new Queen(Board.AvailableLocations[i-1], $"q{i}");
            //    Board.Pieces.Add(q);
            //    if (i == 1) continue;
            //    var p = Board.Pieces.Single(x => x.Name == $"q{i-1}");

            //    while (q.CheckHit(p.Location))
            //    {
            //        Board.MovePieceIfHit(q);
            //    }
            //}

            Board.Pieces.ForEach(x => writeOutLocation(x));
        }

        public class Part
        {
            public int Id { get; set; }
            public string Val { get; set; }

            public override string ToString() => $"{Id} {Val}";
            public override bool Equals(object obj) => (obj as Part).Id == Id && (obj as Part).Val == Val;
            public override int GetHashCode() => $"{Id} {Val}".GetHashCode();
        }

        private static string GetXSLTransformedData(string xslName, XDocument xmlResponse)
        {
            using (var stream = _assembly.GetManifestResourceStream($"GenericTesting.{xslName}.xsl"))
            using (var xmlReader = new XmlTextReader(stream))
            {
                var xslt = new XslCompiledTransform();
                xslt.Load(xmlReader);
                using (var stm = new MemoryStream())
                {
                    xslt.Transform(xmlResponse.CreateReader(), null, stm);
                    stm.Position = 0;
                    using (var sr = new StreamReader(stm))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        static void Main(String[] args)
        {
            Console.WriteLine("Running as {0}", Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            using (HttpListener s = new HttpListener())
            {
                s.Prefixes.Add("http://localhost:49154/vshub/418f29b9cebf4d6bae64d16162f56832/");
                s.Start();
                Console.WriteLine("Server started");
            }

            Console.WriteLine("Server stopped");
            //// _assembly = Assembly.GetAssembly(this.GetType());
            //_assembly = Assembly.GetAssembly(typeof(Program));
            //using (var stream = _assembly.GetManifestResourceStream($"GenericTesting.SegmentTerrainRptNew.xml"))
            //using (var reader = new StreamReader(stream))
            //{
            //    var file = reader.ReadToEnd();
            //    var xdoc = XDocument.Parse(file);
            //    var result = GetXSLTransformedData("SegmentTerrainRpt", xdoc);
            //}

            //var listMain = new List<Part>
            //{
            //    new Part { Id = 1, Val = "A"},
            //    new Part { Id = 2, Val = "B"},
            //    new Part { Id = 3, Val = "C"},
            //};

            //var listPart = new List<Part>
            //{
            //    new Part { Val = "C"}
            //};

            //listMain.ForEach(Console.WriteLine);
            //listPart.ForEach(Console.WriteLine);


            //Console.WriteLine(!listMain.Where(x => listPart.Select(y => y.Val).Contains(x.Val)).Any());

            //listMain.Where(x => listPart.Select(y => y.Val).Contains(x.Val)).ToList().ForEach(Console.WriteLine);

            //.Select(x => new { x.Val }).Where(x => listPart.Select(y => new { y.Val }).Contains(x)).Any());


            Console.ReadLine();
        }
    }
}
