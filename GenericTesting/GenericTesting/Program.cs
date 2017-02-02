using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Text;
using static GenericTesting.HackerRankChallenges.Algorithms;
using EntityTesting;
using GenericTesting.Models;

namespace GenericTesting
{
  public class Student
  {
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<StudentTestScore> Scores { get; set; }
  }

  public class StudentTestScore
  {
    public int StudentID { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
  }

  class Program
  {                                                                           
    static void Main(string[] args)
    {
      var locations = new List<Location>
        {
          new Location { Id = 1, PercentUsed = 0.5, ExtraGarbage = "really important I'm sure"},
          new Location { Id = 2, PercentUsed = 0.6},
          new Location { Id = 3, PercentUsed = 0.7},
        };

      var serialized = locations.SerializeToXml();

      var deserialized = serialized.DeserializeXml<List<Location>>();

      Console.ReadLine();
    }
  }

}
