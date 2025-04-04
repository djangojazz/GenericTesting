﻿using System;
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
          if (len == 0) break;

          if (len % 3 == 0)
          {
            //result.Insert(0, "555");
            result.Append("555");
            len -= 3;
            if (len > 0 && len < 3) return "-1";
          }
          else if ((len - 5) > 0 || len % 5 == 0)
          {
            //result.Insert(0, "33333");
            result.Append("33333");
            len -= 5;
          }
          else
          {
            if (len >= 1) return "-1";
          }
        }
      }
      
      var array = result.ToString().ToArray();
      Array.Reverse(array);
      var output = new string(array);

      return !String.IsNullOrEmpty(output) ? output : "-1";
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

    public static void GiveResultNonDegenerateTriangles(List<int> ls)
    {
      if(ls.Count < 3)
      {
        Console.WriteLine("-1");
      }
      else
      {
        var subset = ls.OrderByDescending(x => x).Take(3).ToList();

        if (subset[0] < (subset[1] + subset[2]))
          Console.WriteLine($"{subset[2]} {subset[1]} {subset[0]}");
        else
          GiveResultNonDegenerateTriangles(ls.OrderBy(x => x).Take(ls.Count - 1).ToList());
      }
    }

        public static int[] BreakingRecords(int[] score)
        {
            int low = 0;
            int high = 0;
            int lowCount = 0;
            int highCount = 0;

            for (int i = 0; i < score.Length; i++)
            {
                if (i == 0)
                {
                    low = score[i];
                    high = score[i];
                    continue;
                }

                var currentScore = score[i];

                if (currentScore > high)
                {
                    high = currentScore;
                    highCount++;
                }
                if (currentScore < low)
                {
                    low = currentScore;
                    lowCount++;
                }
            }

            return new int[] { highCount, lowCount };
        }

        static int ChocolateSolve(int[] s, int d, int m)
        {
            int r = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 >= m)
                {
                    int score = 0;
                    var cCount = 0;
                    while (cCount < m)
                    {
                        score += s[i - cCount];
                        cCount++;
                    }
                    if (score == d) { r++; }
                }
            }
            return r;
        }

        static int DivisibleSumPairs(int k, int[] ar)
        {
            int r = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                ar.Select((j, x) => new { ind = j, v = x })
                   .Skip(i + 1)
                   .ToList()
                   .ForEach(x =>
                   {
                       var comb = ar[i] + x.v;
                       r += (comb % k == 0) ? 1 : 0;
                   });
            }

            return r;
        }

        static string Stones(int n, int a, int b)
        {
            int f = Math.Min(a, b) * (n - 1);
            int d = Math.Abs(b - a);
            return String.Join(" ", Enumerable.Range(0, n).Select(i => f + d * i).Distinct());
        }
    }
}
