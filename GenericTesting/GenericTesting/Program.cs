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

  public class Hldr : IComparable<Hldr>
  {
    public int Id { get; set; }
    public int Id2 { get; set; }
    public string Name { get; set; }

    int IComparable<Hldr>.CompareTo(Hldr o)
    {
      return (Id == o.Id) && (Id2 == o.Id2) ? 0 : -1;       
    }        
  }
         
  class Program
  {
    static void Main(string[] args)
    {
      //var newDate = #1/1/2017#

      var items = new List<Hldr> {
        new Hldr { Id =  1, Id2 = 0, Name = "John"},
        new Hldr { Id =  1, Id2 = 1, Name = "Bill"},
        new Hldr { Id =  2, Id2 = 0, Name = "Jane"},
        new Hldr { Id =  2, Id2 = 1, Name = "Bob"},
      };

      items.OrderBy(x => new { x.Id2, x.Id }).ToList().ForEach(x => Console.WriteLine($"{x.Id} {x.Id2} {x.Name}"));

      Console.ReadLine();
    }
  }

}
