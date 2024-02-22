using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET8
{
    public static class Fibonacci
    {
        public static int FibonacciAtIndex(this int index)
        {
            var previous = 0;
            var twoPrevious = 0;
            var current = 0;

            for (int i = 0; i <= index; i++) 
            {
                twoPrevious = previous;
                previous = current > 0 ? current : i == 0 ? 0 : 1;  //Need to account for first non occurence.  If the value is non zero loop is successful, else observe if index is 0
                current = twoPrevious + previous;
                Console.WriteLine($"You index is {i} two values ago was {twoPrevious} previous value is {previous} and current is {current}");
            }

            return current;
        }

        public static int FibonacciAtindexRecursive(this int index) => FibonacciRecursive(index, 0, 0, 0);

        private static int FibonacciRecursive(int max, int index, int twoPrevious, int previous, int result = 0)
        {
            if (index <= max)
            {
                Console.WriteLine($"You index is {index} two values ago was {twoPrevious} previous value is {previous} and current is {twoPrevious + previous}");
                result = FibonacciRecursive(max, index + 1, previous, twoPrevious + previous > 0 ? twoPrevious + previous : 1);
            }

            return result;
        }
    }
}
