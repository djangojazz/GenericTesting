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

        Parallel.ForEach(inputs, po, (t) => results.Add(DoPower(t.Key, t.Value)));
        
        results.ForEach(x => Console.WriteLine(x));
      }
      catch (OperationCanceledException e) { Console.WriteLine(e.Message); }
    }
    
    private static double DoPower(double input, double power) => Math.Pow(input, power);
  }
}
