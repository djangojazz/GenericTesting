using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.HackerRankChallenges
{
  public static class Algorithms
  {
    public static void TheBeastChallenge()
    {
      
      var sp = new Stopwatch();
      sp.Start();
      Console.WriteLine($"Stopwatch started at {DateTime.Now.ToString()}");

      for (int i = 1; i <= 1000; i++)
      {

        Console.WriteLine($"{i} {MakeString(i)}");
      }

      sp.Stop();
      Console.WriteLine($"Stopwatch stopped at {DateTime.Now.ToString()}");
      Console.WriteLine($"Stopwatch elapsed {sp.Elapsed}");
    }

    public static string MakeString(int len)
    {
      var fives = (len / 3);
      StringBuilder result = new StringBuilder();

      if (len <= 2) return "-1";
      if (len % 3 == 0) for (int i = 0; i < fives; i++) { result.Append("555"); }
      else
      {
        for (int i = 1; i <= fives; i++)
        {
          if (len == 0) return result.ToString();

          if (len % 3 == 0)
          {
            result.Insert(0, "555");
            len -= 3;
            if (len > 0 && len < 3) return "-1";
          }
          else if ((len - 5) > 0 || len % 5 == 0)
          {
            result.Insert(0, "33333");
            len -= 5;
          }
          else
          {
            if (len >= 1) return "-1";
          }
        }
      }

      return !String.IsNullOrEmpty(result.ToString()) ? result.ToString() : "-1";
    }

    public static void WriteDiagonals()
    {
      Func<int[][], bool, int> CalculateDiagonal = (mtrx, leftOrRight) =>
      {
        var result = 0;
        var startBackwards = mtrx.Select(x => x.Count()).First();
        for (int i = 0; i < mtrx.Count(); i++) { startBackwards -= 1; if (!leftOrRight) result += mtrx[i][startBackwards]; else result += mtrx[i][i]; }
        return result;
      };

      var matrix = new int[][] { new int[] { 11, 2, 4 }, new int[] { 4, 5, 6 }, new int[] { 10, 8, -12 } };

      var lr = CalculateDiagonal(matrix, true);
      var rl = CalculateDiagonal(matrix, false);

      Console.WriteLine(Math.Abs(lr - rl));
    }
  }
}
