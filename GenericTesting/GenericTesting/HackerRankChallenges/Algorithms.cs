using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.HackerRankChallenges
{
  public static class Algorithms
  {
    public static void TheBeastChallenge()
    {
      Func<string, bool> IsValid = (input) =>
      {
        var cs = input.Count();
        var fives = input.ToCharArray().Where(c => c == '5').Count();
        var threes = input.ToCharArray().Where(c => c == '3').Count();

        if (fives % 3 == 0)
          cs -= fives;
        if (threes % 5 == 0)
          cs -= threes;

        if (cs == 0) return true; else return false;
      };
      
      Func<IEnumerable<IEnumerable<string>>, IEnumerable<IEnumerable<string>>> CartesianProduct = (sequences) =>
      {
        IEnumerable<IEnumerable<string>> emptyProduct = new[] { Enumerable.Empty<string>() };
        return sequences.Aggregate(emptyProduct, (accumulator, sequence) => from accseq in accumulator from item in sequence select accseq.Concat(new[] { item }));
      };

      Func<int, string> MakeString = (len) =>
      {
        var fives = (len / 3);
        var result = string.Empty;

        if (len % 3 == 0) for (int i = 0; i < fives; i++) { result += "555"; }
        //else if (len % 5 == 0) for (int i = 0; i < (len / 5); i++) { result += "33333"; }
        else
        {
          for (int i = 1; i <= fives; i++)
          {
            if (len % 3 == 0)
            {
              result += "555";
              len -= 3;
            }
            else if(len % 5 == 0)
            {
              result += "33333";
              len -= 5;
            }
          }
          return !String.IsNullOrEmpty(result) ? result : "-1";
        }
       

        return result;
      };

      for (int i = 11; i <= 12; i++)
      {
        var x = MakeString(i);

        //var combs = CartesianProduct(Enumerable.Repeat(new[] { "5", "3" }, i)).ToList();
        //decimal x = -1;
        //foreach (var item in combs)
        //{
        //  var num = String.Join("", item);
        //  if (IsValid(num))
        //  {
        //    Decimal.TryParse(num, out x);  
        //    break;
        //  }
        //  else x = -1;
        //}

        Console.WriteLine($"{i} {x}");
      }
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
