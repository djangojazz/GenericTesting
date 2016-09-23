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
      Func<decimal, bool> IsValid = (inputNumber) => Decimal.Remainder((inputNumber / 3), 1) == 0 && Decimal.Remainder((inputNumber / 5), 1) == 0 ? true : false;
      Func<IEnumerable<IEnumerable<string>>, IEnumerable<IEnumerable<string>>> CartesianProduct = (sequences) =>
      {
        IEnumerable<IEnumerable<string>> emptyProduct = new[] { Enumerable.Empty<string>() };
        return sequences.Aggregate(emptyProduct, (accumulator, sequence) => from accseq in accumulator from item in sequence select accseq.Concat(new[] { item }));
      };

      for (int i = 1; i <= 20; i++)
      {
        var combs = CartesianProduct(Enumerable.Repeat(new[] { "5", "3" }, i)).ToList();
        decimal x = -1;
        foreach (var item in combs) { Decimal.TryParse(String.Join("", item), out x); if (IsValid(x)) break; else x = -1; }

        Console.WriteLine($"{i} {x}");
      }
    }
  }
}
