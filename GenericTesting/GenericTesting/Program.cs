using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;

namespace GenericTesting
{
    
    class Program
    {
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

        static void Main(String[] args)
        {
            int upperLimit = 3;
            Dictionary<Point, bool> possibleHitCombos = new Dictionary<Point, bool>();
            for (int i = 1; i < upperLimit; i++)
            {
                for (int j = i+1; j <= upperLimit; j++)
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
            

            Console.ReadLine();
        }
    }
}
