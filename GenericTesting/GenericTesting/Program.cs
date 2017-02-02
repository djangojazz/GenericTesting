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
      var students = new List<Student>
        {
        new Student { StudentID = 1, FirstName = "Brett", LastName = "X" },
        new Student { StudentID = 2, FirstName = "John", LastName = "X" }
        };
      var grades = new List<StudentTestScore> {
        new StudentTestScore { StudentID = 1, Subject = "Math", Score = 98 },
        new StudentTestScore { StudentID = 1, Subject = "Science", Score = 92 },
        new StudentTestScore { StudentID = 1, Subject = "History", Score = 86 },
        new StudentTestScore { StudentID = 2, Subject = "Math", Score = 80 },
        new StudentTestScore { StudentID = 2, Subject = "Science", Score = 88 },
        new StudentTestScore { StudentID = 2, Subject = "History", Score = 91 }
      };

      var index = 1;
     
      Console.ReadLine();
    }
  }

}
