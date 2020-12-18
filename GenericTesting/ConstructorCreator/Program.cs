using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConstructorCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make or check directory
            var target = new DirectoryInfo("C:\\Temp");
            if (!target.Exists)
                target.Create();
            else
                Console.WriteLine("Already exists");

            var source = new DirectoryInfo(@"C:\AyaGit\Applications\Aya.Core.Api\Aya.Core.DTO\AyaNova\BizDev");
            var files = source.GetFiles("*.cs", SearchOption.AllDirectories).ToList();
            files.AsParallel().ForAll(f =>
            {
                using (var sr = new StreamReader(f.FullName))
                {
                    string s = string.Empty;
                    s = sr.ReadToEnd();
                    var c = new ConstructorObject(s);
                    c.MakeAFile(target.FullName);
                }
            });

            //var location = @"C:\AyaGit\Applications\Aya.Core.Api\Aya.Core.DTO\AyaNova\BizDev\FacilityClientOverviewDto.cs";
            //string s = string.Empty;

            

            

            
        }
    }
}
