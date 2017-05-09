using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.HackerRankChallenges
{
  public static class HourGlasses
  {
    public static void DoIt()
    {
      string[] arrStrings = { "1 1 1 0 0 0", "0 1 0 0 0 0", "1 1 1 0 0 0", "0 0 2 4 4 0", "0 0 0 2 0 0", "0 0 1 2 4 0" };

      int[][] arr = new int[6][];
      for (int arr_i = 0; arr_i < 6; arr_i++)
      {
        string[] arr_temp = arrStrings[arr_i].Split(' ');
        arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
      }

      var ls = new List<int>();

      for (int i = 0; i < arr.Length - 2; i++)
      {
        for (int j = 0; j < arr[i].Length - 2; j++)
        {
          ls.Add(arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2]);
        }
      }

      Console.WriteLine(ls.OrderByDescending(x => x).First());
    }
  }
}
