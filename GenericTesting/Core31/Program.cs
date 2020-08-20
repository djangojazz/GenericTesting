using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Core31
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<int> { 1, 2, 3 };
            var truth = new List<int> { 1, 2 };

            Console.WriteLine(truth.ListCheck(test));
            Console.WriteLine(test.ListCheck(truth));

            Console.ReadLine();
        }
    }
}
