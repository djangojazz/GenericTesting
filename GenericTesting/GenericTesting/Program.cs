﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Text;
using static GenericTesting.HackerRankChallenges.Algorithms;

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
    public int Score { get; set; }
  }

  class Program
  {
    
    static void Main(string[] args)
    {
      var ord = new teOrder { OrderId = 99, tePersons = new List<tePerson> { new tePerson { PersonId = 1, FirstName = "Test" } } };

      using (var context = new TesterEntities())
      {
        context.teOrders.Add(ord);
        context.SaveChanges();
      }

        //var studentCollection = new List<Student> { new Student { StudentID = 1, FirstName = "Brett", LastName = "X" }, new Student { StudentID = 2, FirstName = "John", LastName = "Y" } };
        ////var testResultCollection = new List<StudentTestScores> { new StudentTestScores { StudentID = 1, TestScoreGen = 94 }, new StudentTestScores { StudentID = 2, TestScoreGen = 86 } };
        //var testResultCollection = new List<StudentTestScores> { new StudentTestScores { StudentID = 1 }, new StudentTestScores { StudentID = 2 } };
        //var props = testResultCollection.First().GetType().GetProperties();

        ////Check my properties
        //props.ToList().ForEach(x => Console.WriteLine(x));

        //var testResults = from student in studentCollection
        //                  join testResult in testResultCollection
        //                    on student.StudentID equals testResult.StudentID
        //                  select new
        //                  {
        //                    student.StudentID,
        //                    student.FirstName,
        //                    student.LastName,
        //                    resultName = props.Count() > 1 ? testResult.GetType().GetProperty(props[1]?.Name)?.ToString() : "Nothing",
        //                    result = props.Count() > 1 ? testResult.GetType().GetProperty(props[1]?.Name).GetValue(testResult, null) : "0"
        //                  };

        //testResults.ToList().ForEach(x => Console.WriteLine($"{x.StudentID} {x.FirstName} {x.LastName} {x.resultName} {x.result}"));

        Console.ReadLine();
    }
  }
  
}
