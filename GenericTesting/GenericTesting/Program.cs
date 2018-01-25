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
            public Point Location { get; set; }
            public abstract bool Hit(Point pointOther);
        }

        public class Queen : Piece
        {
            public override bool Hit(Point otherPieceLocation) => (Location.X == otherPieceLocation.X || Location.Y == otherPieceLocation.Y);
            public Queen(Point location) => Location = location;
        }

        public static class Board
        {
            public static List<Piece> Pieces { get; set; }
            public static List<Point> AvailableLocations { get; set; }

            static Board()
            {
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        AvailableLocations.Add(new Point(i, j));
                    }
                }
            }

            public static bool IsAHit(Piece a, Piece b) => a.Hit(b.Location);
            public static void MovePieceIfHit(Piece piece) => piece.Location = AvailableLocations[AvailableLocations.FindIndex(x => x == piece.Location) + 1];
        }

        static void Main(String[] args)
        {
            var queen1 = new Queen(Board.AvailableLocations[0]);
            var queen2 = new Queen(Board.AvailableLocations[1]);
            
            

            Console.ReadLine();
        }
    }
}
