using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Sub x = new Sub();
            Sub y = new Sub("second way");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("-------------");
            sb.AppendLine("First Way");
            sb.AppendLine("-------------");
            sb.AppendLine();

            sb.AppendLine(x.Output);

            sb.AppendLine("-------------");
            sb.AppendLine("Second Way");
            sb.AppendLine("-------------");
            sb.AppendLine();

            sb.AppendLine(y.Output);

            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
}
