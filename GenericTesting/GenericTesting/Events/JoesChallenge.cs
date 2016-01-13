using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.Events
{
  public class JoesChallenge 
  {
    public delegate void BalanceEventHandler(decimal theValue);

    class PiggyBank
    {
      private decimal m_bankBalance;
      public event BalanceEventHandler balanceChanged;

      public decimal theBalance
      {
        set
        {
          m_bankBalance = value;
          balanceChanged(value);
        }
        get
        {
          return m_bankBalance;
        }
      }
    }
    
    public void balanceLog(decimal amount)
    {
      Console.WriteLine("The balance amount is {0}", amount);
    }

    public void balanceWatch(decimal amount)
    {
      if (amount > 500.0m)
        Console.WriteLine("You reached your savings goal! You have {0}", amount);
    }
    
    public void DoIt()
    {
      PiggyBank pb = new PiggyBank();

      pb.balanceChanged += balanceLog;
      pb.balanceChanged += balanceWatch;

      string theStr;
      do
      {
        Console.WriteLine("How much to deposit?");

        theStr = Console.ReadLine();
        if (!theStr.Equals("exit"))
        {
          decimal newVal = decimal.Parse(theStr);

          pb.theBalance += newVal;
        }
      } while (!theStr.Equals("exit"));
    }
  }
}
