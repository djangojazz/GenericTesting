using System;

namespace Core22Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new POCO { Id = 1, Date = "@90DaysPrior", Date2 = "1-2-2019" };

            var validator = new DynamicOrStaticDate();
            Console.WriteLine(validator.IsValid(n.Date) && validator.IsValid(n.Date2));

            Console.ReadLine();
        }
    }
}
