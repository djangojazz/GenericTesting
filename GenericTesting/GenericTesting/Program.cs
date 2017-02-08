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
      using (var context = new EntityTesting.TesterEntities())
      {
        var nPerson = new tePerson { FirstName = "Test", LastName = "Tester" };

        context.tePerson.Add(nPerson);
        context.SaveChanges();
      }


        //    var thingie = new QADailyXValueCalCheck
        //    {
        //      Regs = "40CFR75",
        //      BasisTStamp = "2016-02-15 05:18",
        //      DAsWriteTStamp = "2016-02-15 05:40",
        //      InjEndTime = "2016-02-15 05:23",
        //      Manual = 0,       //Boolean This will probably mess up  Changed to Int
        //      RefValue = 169.7M,
        //      MeasValue = 169.27M,
        //      Online = 14,  //Mismatch Type?  Change to Int
        //      AllowableDrift = 15,
        //      FailAbove = 0,     //Boolean This will probably mess up   Changed to Int
        //      FailBelow = 0,     //Boolean This will probably mess up    Changed to Int
        //      InstSpan = 300,
        //      GasLevel = "MID",     //This is marked as a decimal?                                                     
        //      CId = "111",             
        //      MId =  "N10",
        //      CylinderId= "CC357464",
        //      CylinderExpDate ="2022-08-12",
        //      CylinderVendorId = "B22014",
        //      CylinderGasTypeCode = "BALN,SO2,NO,CO2"
        //};

        //  var serialized = thingie.SerializeToXml();

        //  var deserialized = serialized.DeserializeXml<QADailyXValueCalCheck>();

        Console.ReadLine();
    }
  }

}
