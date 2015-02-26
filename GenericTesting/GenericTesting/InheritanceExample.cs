using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    
    public class InheritanceOutput
    {
        Sub x = new Sub();
        Sub y = new Sub("second way");
        StringBuilder sb = new StringBuilder();

        public InheritanceOutput()
        {
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

    public class Sub : Base
    {
        public Sub() : base()
        {
            // If you are inheriting and the base object is accessible you may change it in the child class
            Resource = "Changed";  
            Output += "SUB Resource is: " + Resource + Environment.NewLine;
        }

        // Or I may overload a constructor to then overload a base class and call that.
        // I think this may be what you want as you would create a NEW constructor in the base and this would not affect existing code
        // plus this way you could pass in and inject the logic from the sub class to call the base constructor directly and then have 
        // it all pass through.  Notice the timing will always call the base first to.
        public Sub(string resource) : base(resource) 
        {
            Output += "SUB Resource is: " + Resource + Environment.NewLine;
        }
    }

    public class Base
    {
        public string Resource;
        public string Output;

        public Base()
        {
            Output += "BASE Resource is: " + Resource + Environment.NewLine;
        }

        public Base(string resource)
        {
            Resource = resource;
            Output += "BASE Overloaded Constructor Resource is: " + Resource + Environment.NewLine;
        }
    }
}
