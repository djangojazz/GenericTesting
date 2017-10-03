using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericTesting
{
  public static class ParallelExamples
  {
    public static void PlinqExample(Dictionary<double, double> inputs) => inputs.AsParallel().ForAll(x => Console.WriteLine(DoPower(x.Key, x.Value)));

    public static void ParallelInvokeExample(Dictionary<double, double> inputs)
    {
      try
      {
        ParallelOptions po = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
        var results = new List<double>();

        inputs.ToList().ForEach(t =>
        {
          Parallel.Invoke(po, new Action(() => results.Add(DoPower(t.Key, t.Value))));
        });

        results.ForEach(x => Console.WriteLine(x));
      }
      catch (OperationCanceledException e) { Console.WriteLine(e.Message); }
    }

    public static void MSDNReturnArray()
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

    private static double DoPower(double input, double power) => Math.Pow(input, power);
  }
}
