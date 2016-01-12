using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public class JoesChallenge
  {
    public delegate void Zoner(int amount, string zone, ref string result);
    
    static void Rate(int amount, string zone, ref string result)
    {
      if (zone.ToLower() == "zone1")
      {
        result = (amount * 0.25).ToString();
      }
      if (zone.ToLower() == "zone2")
      {
        result = (amount * 0.12).ToString();
      }
      if (zone.ToLower() == "zone3")
      {
        result = (amount * 0.08).ToString();
      }
      if (zone.ToLower() == "zone4")
      {
        result = (amount * 0.04).ToString();
      }
    }

    public void ReturnData()
    {
      int amount;
      bool success;
      string amountIn, zoneIn, result = string.Empty;

      Console.WriteLine("What is the amount?");
      amountIn = Console.ReadLine();
      success = Int32.TryParse(amountIn, out amount);
      if(!success)
      {
        Console.WriteLine("Enter a valid amount!");
        return; 
      }
      Console.WriteLine("What is the zone?");
      zoneIn = Console.ReadLine();
      if(zoneIn.Substring(0,4).ToLower() != "zone")
      {
        Console.WriteLine("Zone must start with 'Zone' + 1,2,3,4");
      }
      
      Zoner z = Rate;
      z += delegate (int amountNew, string zoneNew, ref string resultNew)
      {
        if (zoneIn.ToLower() == "zone2" || zoneIn.ToLower() == "zone4")
        {
          double amountH = 0;
          Double.TryParse(resultNew, out amountH);
          amountH += 25;

          resultNew = $"{amountH}, is high risk";
        }
      };

      z(amount, zoneIn, ref result);

      Console.WriteLine(result);
      Console.WriteLine("\nPress Enter to Continue...");
      Console.ReadLine();
    }
  }
}
