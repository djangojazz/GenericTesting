using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.TPLExamples
{
  public static class TaskFactory
  {
    public static void ReturnList()
    {
      Task<Double>[] taskArray = { Task<Double>.Factory.StartNew(() => DoComputation(1.0)),
                                     Task<Double>.Factory.StartNew(() => DoComputation(100.0)),
                                     Task<Double>.Factory.StartNew(() => DoComputation(1000.0)) };
      
      Double sum = 0;
      var results = new Double[taskArray.Length];
      for (int i = 0; i < taskArray.Length; i++)
      {
        results[i] = taskArray[i].Result;
        Console.Write("{0:N1} {1}", results[i],
                          i == taskArray.Length - 1 ? "= " : "+ ");
        sum += results[i];
      }
      Console.WriteLine("{0:N1}", sum);
    }

    private static Double DoComputation(Double start)
    {
      Double sum = 0;
      for (var value = start; value <= start + 10; value += .1)
        sum += value;

      return sum;
    }
  }
}
